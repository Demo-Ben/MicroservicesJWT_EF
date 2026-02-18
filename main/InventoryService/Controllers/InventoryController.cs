using InventoryService.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedKernel.DTOs;
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
    // POST: api/inventory/update
    // ---------------------------------------
    [HttpPost("update")]
    public IActionResult UpdateInventory(InventoryUpdate update)
    {
        var item = _db.Inventory.FirstOrDefault(x => x.ProductId == update.ProductId 
                                                && x.QuantityAvailable >= update.Quantity);

        // If item doesn't exist, treat as zero stock
        if (item == null)
        {
            return Ok(new
            {
                Status = "OutOfStock",
                AvailableQuantity = 0,
                Message = "Product not found in inventory"
            });
        }

        // Check if enough stock exists
        if (item.QuantityAvailable < update.Quantity)
        {
            return Ok(new
            {
                Status = "OutOfStock",
                AvailableQuantity = item.QuantityAvailable,
                Message = "Not enough inventory available"
            });
        }

        // Deduct stock
        item.QuantityAvailable -= update.Quantity; 
        _db.SaveChanges();

        // Simulate inventory update
        return Ok(new
        {
            Status = "Reserved",
            AvailableQuantity = item.QuantityAvailable,
            Message = "Inventory reserved successfully"
        });
    }



    [HttpPost("release")]
    public IActionResult ReleaseInventory([FromBody] ReleaseInventoryRequest request)
    {
        var item = _db.Inventory.FirstOrDefault(x => x.ProductId == request.ProductId);

        // If item doesn't exist, nothing to release
        if (item == null)
        {
            return Ok(new
            {
                Status = "Ignored",
                Message = "No inventory record found. Nothing to release."
            });
        }

        // Add stock back
        item.QuantityAvailable += request.Quantity;
        _db.SaveChanges();

        return Ok(new
        {
            Status = "Released",
            AvailableQuantity = item.QuantityAvailable,
            Message = "Inventory released successfully"
        });
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


}
