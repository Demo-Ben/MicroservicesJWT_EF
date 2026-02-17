using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderService.Models;

//public class Order
//{
//    public int Id { get; set; }
//    public string ProductId { get; set; }
//    public int Quantity { get; set; }
//    public decimal Amount { get; set; }
//}

public class Order
{
    [Key]
    public int Id { get; set; }
    public string ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Amount { get; set; }
    public required string Status { get; set; } = "Pending";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}
