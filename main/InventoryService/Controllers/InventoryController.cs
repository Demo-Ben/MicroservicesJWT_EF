using InventoryService.Data;
using InventoryService.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly InventoryDbContext _db; 
    public InventoryController(InventoryDbContext db)
    { 
        _db = db; 
    }

    [HttpPost("update")]
    public IActionResult UpdateInventory(InventoryUpdate update)
    {
        var item = _db.Inventory.FirstOrDefault(x => x.ProductId == update.ProductId);

        if (item == null) 
        { 
            item = new InventoryItem
            { 
                ProductId = update.ProductId, 
                QuantityAvailable = 0 
            }; 
            _db.Inventory.Add(item); 
        }

        item.QuantityAvailable -= update.Quantity; 
        _db.SaveChanges();

        // Simulate inventory update
        return Ok(new { Status = "Inventory Updated" });
    }
}
