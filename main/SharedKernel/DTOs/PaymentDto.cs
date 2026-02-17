using System.ComponentModel.DataAnnotations;

namespace SharedKernel.DTOs;

public class PaymentDto
{

    [Key] 
    public int Id { get; set; }
    public int OrderId { get; set; }
    public decimal Amount { get; set; }
    public string Status { get; set; }
}
