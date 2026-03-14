namespace SharedKernel.DTOs
{
    public class RefundResultDto
    {
        public string Status { get; set; }          // "Refunded" or "Failed"
        public string Message { get; set; }         // Optional message
    }
}
