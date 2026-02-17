using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentService.Data;
using SharedKernel.DTOs;
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


    [HttpPost]
    public IActionResult ProcessPayment(Payment request)
    {
        var payment = new Payment
        {
            TransactionId = Guid.NewGuid().ToString(), // ← generated here
            OrderId = request.OrderId, 
            Amount = request.Amount, 
            Status = "Success" 
        }; 
        _db.Payments.Add(payment); 
        _db.SaveChanges();

        // Simulate payment success
        return Ok(new { Status = "Success", transactionId = payment.TransactionId });
    }


    [HttpPost("refund")]
    public async Task<IActionResult> Refund([FromBody] RefundRequestDto request)
    {
        // 1. Validate input
        if (string.IsNullOrWhiteSpace(request.TransactionId))
        {
            return BadRequest(new RefundResultDto
            {
                Status = "Failed",
                Message = "TransactionId is required"
            });
        }

        // 2. Lookup the payment record (simulate DB lookup)
        var payment = await _db.Payments
            .FirstOrDefaultAsync(p => p.TransactionId == request.TransactionId);

        if (payment == null)
        {
            return NotFound(new RefundResultDto
            {
                Status = "Failed",
                Message = "Transaction not found"
            });
        }

        // 3. Check if already refunded
        if (payment.Status == "Refunded")
        {
            return Ok(new RefundResultDto
            {
                Status = "Refunded",
                Message = "Payment already refunded"
            });
        }

        // 4. Perform refund logic (simulate)
        payment.Status = "Refunded";
        payment.RefundedAt = DateTime.UtcNow;
        await _db.SaveChangesAsync();

        // 5. Return result
        return Ok(new RefundResultDto
        {
            Status = "Refunded",
            Message = "Payment refunded successfully"
        });
    }



    public object Payments { get; private set; }

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
}
