using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.DTOs
{
    public class ReleaseInventoryRequest
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

