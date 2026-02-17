namespace OrderService.DTOs
{
    public class OrderDetailDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public string PaymentStatus { get; set; }
        public string InventoryStatus { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
