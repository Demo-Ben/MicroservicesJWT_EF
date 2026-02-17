using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Models
{
    public class Payment
    {

        [Key]
        public int Id { get; set; }
        public string TransactionId { get; set; } // ← THIS is the one you use
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } // "Success", "Failed", "Refunded"
        public DateTime PaidAt { get; set; } = DateTime.UtcNow;
        public DateTime? RefundedAt { get; set; } =  DateTime.UtcNow;
    }
}
