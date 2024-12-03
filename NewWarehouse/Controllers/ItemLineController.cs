using Microsoft.AspNetCore.Mvc;
using Models; // For ItemLine
using Services;

namespace Controllers
{
    [Route("api/v2/item_lines")]
    [ApiController]
    public class ItemLineController : ControllerBase
    {
        private readonly IItemLineService _itemLineService;

        public ItemLineController(IItemLineService itemlineService)
        {
            _itemLineService = itemlineService;
        }

        // GET: api/v2/item_lines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemLine>>> GetItemLines()
        {
            var itemLine = await _itemLineService.GetAllItemLinesAsync();
            return Ok(itemLine);
        }

        // GET: api/v2/item_lines/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemLine>> GetItemLineById(int id)
        {
            var itemLine = await _itemLineService.GetItemLineByIdAsync(id);
            if (itemLine == null)
            {
                return NotFound(); // Return 404 if itemLine not found
            }
            return Ok(itemLine); // Return the itemLine 
        }

        // POST: api/v2/item_lines
        [HttpPost]
        public async Task<ActionResult<ItemLine>> PostItemLine(ItemLine itemLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return a 400 Bad Request if invalid
            }
            var createdItemLine = await _itemLineService.AddItemLineAsync(itemLine);
            return CreatedAtAction(nameof(GetItemLines), new { id = createdItemLine.Id }, createdItemLine);
        }

        // PUT: api/v2/item_lines/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItemLine(int id, ItemLine itemLine)
        {
            if (id != itemLine.Id)
            {
                return BadRequest("ItemLine ID mismatch.");
            }

            var updatedItemLine = await _itemLineService.UpdateItemLineAsync(id, itemLine);

            if (updatedItemLine == null)
            {
                return NotFound();
            }
            return Ok(updatedItemLine);
        }

        // DELETE: api/v2/item_lines/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemLine(int id)
        {
            var itemLine = await _itemLineService.GetItemLineByIdAsync(id);
            if (itemLine == null)
            {
                return NotFound(); // Return 404 if the ItemLine is not found
            }

            var result = await _itemLineService.DeleteItemLineAsync(id);
            if (!result)
            {
                return StatusCode(500, "Error deleting the Item_Line."); // Return 500 if deletion fails
            }

            return NoContent(); // Return 204 No Content on successful deletion
        }
    }
}