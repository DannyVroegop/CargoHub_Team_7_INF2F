using Microsoft.AspNetCore.Mvc;
using Models; // For Inventory
using Services; // For IInventoryService

namespace Controllers
{
    [Route("api/v2/inventories")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        // GET: api/v2/inventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetInventories()
        {
            var inventories = await _inventoryService.GetAllInventoriesAsync();
            return Ok(inventories);
        }

        // GET: api/v2/inventories/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Inventory>> GetInventoryById(int id)
        {
            var inventory = await _inventoryService.GetInventoryByIdAsync(id);
            if (inventory == null)
            {
                return NotFound(); // Return 404 if Inventory not found
            }
            return Ok(inventory); // Return the Inventory 
        }

        // POST: api/v2/inventories
        [HttpPost]
        public async Task<ActionResult<Inventory>> PostInventory(Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return a 400 Bad Request if invalid
            }
            var createdInventory = await _inventoryService.AddInventoryAsync(inventory);
            return CreatedAtAction(nameof(GetInventories), new { id = createdInventory.Id }, createdInventory);
        }

        // PUT: api/v2/inventories/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInventory(int id, Inventory inventory)
        {
            if (id != inventory.Id)
            {
                return BadRequest("Inventory ID mismatch.");
            }

            var updatedInventory = await _inventoryService.UpdateInventoryAsync(id, inventory);

            if (updatedInventory == null)
            {
                return NotFound();
            }
            return Ok(updatedInventory);
        }

        // DELETE: api/v2/inventories/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventory(int id)
        {
            var inventory = await _inventoryService.GetInventoryByIdAsync(id);
            if (inventory == null)
            {
                return NotFound(); // Return 404 if the inventory is not found
            }

            var result = await _inventoryService.DeleteInventoryAsync(id);
            if (!result)
            {
                return StatusCode(500, "Error deleting the inventory."); // Return 500 if deletion fails
            }

            return NoContent(); // Return 204 No Content on successful deletion
        }
    }
}
