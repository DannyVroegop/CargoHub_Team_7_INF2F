using Microsoft.AspNetCore.Mvc;
using Models; // For ItemType
using Services;

namespace Controllers
{
    [Route("api/v2/item_types")]
    [ApiController]
    public class ItemTypeController : ControllerBase
    {
        private readonly IItemTypeService _itemTypeService;

        public ItemTypeController(IItemTypeService itemTypeService)
        {
            _itemTypeService = itemTypeService;
        }

        // GET: api/v2/item_types
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemType>>> GetItemTypes()
        {
            var itemType = await _itemTypeService.GetAllItemTypesAsync();
            return Ok(itemType);
        }

        // GET: api/v2/item_types/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemType>> GetItemTypeById(int id)
        {
            var itemType = await _itemTypeService.GetItemTypeByIdAsync(id);
            if (itemType == null)
            {
                return NotFound(); // Return 404 if ItemType not found
            }
            return Ok(itemType); // Return the ItemType 
        }

        // POST: api/v2/item_types
        [HttpPost]
        public async Task<ActionResult<ItemType>> PostItemType(ItemType itemType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return a 400 Bad Request if invalid
            }
            var createdItemType = await _itemTypeService.AddItemTypeAsync(itemType);
            return CreatedAtAction(nameof(GetItemTypes), new { id = createdItemType.Id }, createdItemType);
        }

        // PUT: api/v2/item_types/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItemType(int id, ItemType itemType)
        {
            if (id != itemType.Id)
            {
                return BadRequest("ItemType ID mismatch.");
            }

            var updatedItemType = await _itemTypeService.UpdateItemTypeAsync(id, itemType);

            if (updatedItemType == null)
            {
                return NotFound();
            }
            return Ok(updatedItemType);
        }

        // DELETE: api/v2/item_types/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemType(int id)
        {
            var itemType = await _itemTypeService.GetItemTypeByIdAsync(id);
            if (itemType == null)
            {
                return NotFound(); // Return 404 if the ItemType is not found
            }

            var result = await _itemTypeService.DeleteItemTypeAsync(id);
            if (!result)
            {
                return StatusCode(500, "Error deleting the ItemType."); // Return 500 if deletion fails
            }

            return NoContent(); // Return 204 No Content on successful deletion
        }
    }
}