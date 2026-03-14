namespace SharedKernel.DTOs
{
    public class InventoryResultDto
    {
        public string Status { get; set; }          // e.g., "Reserved", "OutOfStock"
        public int AvailableQuantity { get; set; }  // Remaining stock after reservation
        public string Message { get; set; }         // Optional: "Stock reserved"
    }

}
