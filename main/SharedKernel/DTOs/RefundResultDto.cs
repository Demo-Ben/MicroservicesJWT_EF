using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.DTOs
{
    public class RefundResultDto
    {
        public string Status { get; set; }          // "Refunded" or "Failed"
        public string Message { get; set; }         // Optional message
    }
}
