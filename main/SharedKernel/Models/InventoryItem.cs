using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Models
{
    public class InventoryItem
    {
        [Key]
        public int Id { get; set; }
        public string ProductId { get; set; }
        public int QuantityAvailable { get; set; }
    }

}
