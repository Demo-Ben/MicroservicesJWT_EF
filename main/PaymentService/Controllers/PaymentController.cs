using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentService.Data;
using PaymentService.Models;
using SharedKernel.Models;

namespace PaymentService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly PaymentDbContext _db;
    public PaymentController(PaymentDbContext db) 
    { 
        _db = db; 
    }

    // ---------------------------------------
    // GET: api/payment
    // ---------------------------------------
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var payments = await _db.Payments.ToListAsync();
        return Ok(payments);
    }

    // ---------------------------------------
    // GET: api/payment/{id}
    // ---------------------------------------
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var payment = await _db.Payments.FindAsync(id);

        if (payment == null)
            return NotFound($"Payment with ID {id} not found");

        return Ok(payment);
    }

    [HttpPost]
    public IActionResult ProcessPayment(Payment request)
    {
        var payment = new Payment
        {
            OrderId = request.OrderId, 
            Amount = request.Amount, 
            Status = "Success" 
        }; 
        _db.Payments.Add(payment); 
        _db.SaveChanges();

        // Simulate payment success
        return Ok(new { Status = "Payment Successful" });
    }
}
