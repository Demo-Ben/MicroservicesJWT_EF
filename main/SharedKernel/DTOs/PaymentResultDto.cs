using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.DTOs
{
    public class PaymentResultDto
    {
        public string Status { get; set; }          // e.g., "Success", "Failed"
        public string TransactionId { get; set; }   // Unique payment transaction ID
        public string Message { get; set; }         // Optional: "Payment approved"
    }

}
