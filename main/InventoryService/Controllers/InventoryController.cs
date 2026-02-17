using InventoryService.Data;
//using InventoryService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Models;

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

    // ---------------------------------------
    // GET: api/inventory
    // ---------------------------------------
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _db.Inventory.ToListAsync();
        return Ok(items);
    }

    // ---------------------------------------
    // GET: api/inventory/{id}
    // ---------------------------------------
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _db.Inventory.FindAsync(id);

        if (item == null)
            return NotFound($"Inventory item with ID {id} not found");

        return Ok(item);
    }


    // ---------------------------------------
    // POST: api/inventory/update
    // ---------------------------------------
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
