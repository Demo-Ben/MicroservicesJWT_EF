using Microsoft.AspNetCore.Mvc;
using InventoryService.Models;

namespace InventoryService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    [HttpPost("update")]
    public IActionResult UpdateInventory(InventoryUpdate update)
    {
        // Simulate inventory update
        return Ok(new { Status = "Inventory Updated" });
    }
}
