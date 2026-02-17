using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.DTOs;
using OrderService.Models;
using System.Net.Http.Json;


namespace OrderService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly HttpClient _http;
    private readonly OrderDbContext _db;
	private readonly IMapper _mapper;

	public OrderController(IHttpClientFactory httpClientFactory, OrderDbContext db, IMapper mapper)
	{
		_http = httpClientFactory.CreateClient();
		_db = db;
		_mapper = mapper;
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


	// -------------------------------
	// POST: api/order
	// -------------------------------
	[HttpPost]
    public async Task<IActionResult> CreateOrder(Order order)
    {
        _db.Orders.Add(order);
        await _db.SaveChangesAsync();


		// 1. Call PaymentService
		//https://localhost:5002/api/Payment
		var paymentResponse = await _http.PostAsJsonAsync(
							"http://localhost:5002/api/payment",
							new { order.Id, order.Amount });


        if (!paymentResponse.IsSuccessStatusCode)
            return BadRequest("Payment failed");


		// 2. Call InventoryService
		//https://localhost:5003/api/Inventory/update
		var inventoryResponse = await _http.PostAsJsonAsync(
							"http://localhost:5003/api/inventory/update",
							new { order.ProductId, order.Quantity });
	

		if (!inventoryResponse.IsSuccessStatusCode)
            return BadRequest("Inventory update failed");

        return Ok("Order processed successfully");
    }
}
