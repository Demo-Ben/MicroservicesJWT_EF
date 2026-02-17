namespace OrderService.DTOs
{
    public class OrderResultDto
    {
        public int OrderId { get; set; }
        public string PaymentStatus { get; set; }
        public string InventoryStatus { get; set; }
        public string Message { get; set; }
    }

}
