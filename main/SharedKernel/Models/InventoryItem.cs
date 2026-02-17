using System.ComponentModel.DataAnnotations;

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