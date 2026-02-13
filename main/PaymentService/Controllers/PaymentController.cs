using Microsoft.AspNetCore.Mvc;
using PaymentService.Data;
using PaymentService.Models;

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
            OrderId = request.OrderId, 
            Amount = request.Amount, 
            Status = "Success" 
        }; 
        _db.Payments.Add(payment); _db.SaveChanges();

        // Simulate payment success
        return Ok(new { Status = "Payment Successful" });
    }
}
