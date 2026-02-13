namespace InventoryService.Models;

public class InventoryItem
{
    public int Id { get; set; }
    public string ProductId { get; set; }
    public int QuantityAvailable { get; set; }
}
