using Microsoft.AspNetCore.Mvc;
using Models; // For Item model
using Services;

namespace Controllers
{
    [Route("api/v2/items")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        // GET: api/v2/items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            var items = await _itemService.GetAllItemsAsync();
            return Ok(items); // Return the list of DTOs
        }

        // GET: api/v2/items/{uid}
        [HttpGet("{uid}")]
        public async Task<ActionResult<Item>> GetItemById(string uid)
        {
            var item = await _itemService.GetItemByIdAsync(uid);
            if (item == null)
            {
                return NotFound(); // Return 404 if item not found
            }
            return Ok(item); // Return the item
        }

        // POST: api/v2/items
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return a 400 Bad Request if invalid
            }

            var createdItem = await _itemService.AddItemAsync(item);

            return CreatedAtAction(nameof(GetItems), new { id = createdItem.Uid }, createdItem);
        }

        // PUT: api/v2/items/{id}
        [HttpPut("{uid}")]
        public async Task<IActionResult> UpdateItem(string uid, Item item)
        {
            if (uid != item.Uid)
            {
                return BadRequest("Item UID mismatch.");
            }

            // // Map DTO to Model
            // var warehouse = MapDTOToWarehouse(warehouseDTO);

            var updatedItem = await _itemService.UpdateItemAsync(uid, item);

            if (updatedItem == null)
            {
                return NotFound();
            }

            // Map Model back to DTO for the response
            // var updatedWarehouseDTO = MapWarehouseToDTO(updatedWarehouse);
            return Ok(updatedItem);
        }

        // DELETE: api/v2/items/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(string id)
        {
            var item = await _itemService.GetItemByIdAsync(id);
            if (item == null)
            {
                return NotFound(); // Return 404 if the item is not found
            }

            var result = await _itemService.DeleteItemAsync(id);
            if (!result)
            {
                return StatusCode(500, "Error deleting the item."); // Return 500 if deletion fails
            }

            return NoContent(); // Return 204 No Content on successful deletion
        }
    }
}