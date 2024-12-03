using Microsoft.AspNetCore.Mvc;
using Models; // For ItemGroup
using Services;

namespace Controllers
{
    [Route("api/v2/item_groups")]
    [ApiController]
    public class ItemGroupController : ControllerBase
    {
        private readonly IItemGroupService _itemGroupService;

        public ItemGroupController(IItemGroupService itemGroupService)
        {
            _itemGroupService = itemGroupService;
        }

        // GET: api/v2/item_groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemGroup>>> GetItemGroups()
        {
            var itemGroup = await _itemGroupService.GetAllItemGroupsAsync();
            return Ok(itemGroup);
        }

        // GET: api/v2/item_groups/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemGroup>> GetItemGroupById(int id)
        {
            var itemGroup = await _itemGroupService.GetItemGroupByIdAsync(id);
            if (itemGroup == null)
            {
                return NotFound(); // Return 404 if ItemGroup not found
            }
            return Ok(itemGroup); // Return the ItemGroup 
        }

        // POST: api/v2/item_groups
        [HttpPost]
        public async Task<ActionResult<ItemGroup>> PostItemGroup(ItemGroup itemGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return a 400 Bad Request if invalid
            }
            var createdItemGroup = await _itemGroupService.AddItemGroupAsync(itemGroup);
            return CreatedAtAction(nameof(GetItemGroups), new { id = createdItemGroup.Id }, createdItemGroup);
        }

        // PUT: api/v2/item_groups/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItemGroup(int id, ItemGroup itemGroup)
        {
            if (id != itemGroup.Id)
            {
                return BadRequest("ItemGroup ID mismatch.");
            }

            var updatedItemGroup = await _itemGroupService.UpdateItemGroupAsync(id, itemGroup);

            if (updatedItemGroup == null)
            {
                return NotFound();
            }
            return Ok(updatedItemGroup);
        }

        // DELETE: api/v2/item_groups/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemGroup(int id)
        {
            var itemGroup = await _itemGroupService.GetItemGroupByIdAsync(id);
            if (itemGroup == null)
            {
                return NotFound(); // Return 404 if the ItemGroup is not found
            }

            var result = await _itemGroupService.DeleteItemGroupAsync(id);
            if (!result)
            {
                return StatusCode(500, "Error deleting the ItemGroup."); // Return 500 if deletion fails
            }

            return NoContent(); // Return 204 No Content on successful deletion
        }
    }
}