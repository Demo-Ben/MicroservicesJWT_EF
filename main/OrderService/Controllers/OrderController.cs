using Microsoft.AspNetCore.Mvc;
using OrderService.Data;
using OrderService.Models;
using System.Net.Http.Json;

namespace OrderService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly HttpClient _http;
    private readonly OrderDbContext _db;

    public OrderController(IHttpClientFactory httpClientFactory, OrderDbContext db)
    {
        _http = httpClientFactory.CreateClient();
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(Order order)
    {
        _db.Orders.Add(order);
        await _db.SaveChangesAsync();



        // 1. Call PaymentService
        var paymentResponse = await _http.PostAsJsonAsync(
            "http://localhost:5002/api/payment",
            new { order.Id, order.Amount });

        if (!paymentResponse.IsSuccessStatusCode)
            return BadRequest("Payment failed");

        // 2. Call InventoryService
        var inventoryResponse = await _http.PostAsJsonAsync(
            "http://localhost:5003/api/inventory/update",
            new { order.ProductId, order.Quantity });

        if (!inventoryResponse.IsSuccessStatusCode)
            return BadRequest("Inventory update failed");

        return Ok("Order processed successfully");
    }
}
