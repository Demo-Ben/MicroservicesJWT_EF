using Microsoft.AspNetCore.Mvc;
using PaymentService.Models;

namespace PaymentService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    [HttpPost]
    public IActionResult ProcessPayment(PaymentRequest request)
    {
        // Simulate payment success
        return Ok(new { Status = "Payment Successful" });
    }
}
