using System.ComponentModel.DataAnnotations;

namespace SharedKernel.Models
{
    public class InventoryItem
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int QuantityAvailable { get; set; }

        public DateTime LastUpdated { get; set; }
    }

}