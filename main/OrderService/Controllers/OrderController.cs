using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using SharedKernel.Models;
using System.Net.Http.Json;
using SharedKernel.DTOs;

namespace OrderService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    //private readonly HttpClient _http;
    private readonly IHttpClientFactory _httpClientFactory;

    private readonly OrderDbContext _db;
	private readonly IMapper _mapper;

    public OrderController(IHttpClientFactory httpClientFactory, OrderDbContext db, IMapper mapper)
	{
        //_http = httpClientFactory.CreateClient();
        _httpClientFactory = httpClientFactory;
        _db = db;
		_mapper = mapper;
	}

	// -------------------------------
	// POST: api/order
	// -------------------------------
	[HttpPost]
    public async Task<IActionResult> CreateOrder(Order order)
    {
        order.Status = "Pending";
        _db.Orders.Add(order);
        await _db.SaveChangesAsync();


        // 1. Call PaymentService
        //https://localhost:5002/api/Payment
        var paymentRequest = new Payment 
        {
            TransactionId = Guid.NewGuid().ToString(), // Generate a unique transaction ID
            OrderId = order.Id, 
            Amount = order.Amount, 
            Status= "Pending", //order.Status
        };

        //var paymentResponse = await _http.PostAsJsonAsync("http://localhost:5002/api/payment", new { order.Id, order.Amount });
        var _paymentClient = _httpClientFactory.CreateClient("PaymentService");
        var paymentResponse = await _paymentClient.PostAsJsonAsync("api/payment", paymentRequest);

        if (!paymentResponse.IsSuccessStatusCode)
            return BadRequest("Payment failed");


        var paymentResult = await paymentResponse.Content.ReadFromJsonAsync<PaymentResultDto>();
        if (paymentResult.Status != "Success")
        {
            order.Status = "PaymentFailed";
            await _db.SaveChangesAsync();
            return BadRequest("Payment failed");
        }

        // 2. Call InventoryService
        //https://localhost:5003/api/Inventory/update
        var inventoryUpdate = new InventoryUpdate 
        {
            ProductId= order.ProductId, 
            Quantity = order.Quantity 
        };

        //var inventoryResponse = await _http.PostAsJsonAsync("http://localhost:5003/api/inventory/update",new { order.ProductId, order.Quantity });
        var _inventoryClient = _httpClientFactory.CreateClient("InventoryService");
        var inventoryResponse = await _inventoryClient.PostAsJsonAsync("api/inventory/update", inventoryUpdate);

        if (!inventoryResponse.IsSuccessStatusCode)
            return BadRequest("Inventory reservation failed");

        var inventoryResult = await inventoryResponse.Content.ReadFromJsonAsync<InventoryResultDto>();
        if (inventoryResult.Status != "Reserved")
        {
            // COMPENSATING ACTION
            // 1. Refund payment
            var refundRequestDto = new RefundRequestDto
            {
                TransactionId = paymentResult.TransactionId
            };
            await _paymentClient.PostAsJsonAsync("api/payment/refund", refundRequestDto);


            // 2. Release inventory (if any was reserved earlier)
            //var releaseInventoryRequest = new ReleaseInventoryRequest
            //{
            //    ProductId = order.ProductId,
            //    Quantity = order.Quantity
            //};
            //await _inventoryClient.PostAsJsonAsync("api/inventory/release", releaseInventoryRequest);	

			order.Status = "InventoryFailed";
            await _db.SaveChangesAsync();
            return BadRequest("Inventory reservation failed");
        }

        order.Status = "Completed";
        await _db.SaveChangesAsync();

        // 3. Return combined result
        return Ok(new
        {
            OrderId = order.Id,
            PaymentStatus = paymentResult.Status,
            InventoryStatus = inventoryResult.Status
        });
    }


    // -------------------------------
    // GET: api/order
    // -------------------------------
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _db.Orders.ToListAsync();
        return Ok(_mapper.Map<List<OrderDto>>(orders));
    }

    // -------------------------------
    // GET: api/order/{id}
    // -------------------------------
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var order = await _db.Orders.FindAsync(id);
        if (order == null)
            return NotFound();

        return Ok(_mapper.Map<OrderDto>(order));
    }

}
