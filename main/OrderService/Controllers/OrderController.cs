using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using System.Net.Http.Json;

namespace OrderService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly HttpClient _http;

    public OrderController(IHttpClientFactory httpClientFactory)
    {
        _http = httpClientFactory.CreateClient();
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(Order order)
    {
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
