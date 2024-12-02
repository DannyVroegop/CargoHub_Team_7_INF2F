using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;  // Namespace for the DbContext
using Models;  // Namespace for the Warehouse model

namespace WarehouseCase.Controllers
{
    [Route("api/v2/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly CargoContext _context;

        // Constructor to inject the DbContext
        public WarehousesController(CargoContext context)
        {
            _context = context;
        }

        // GET: api/v2/warehouse
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Warehouse>>> GetWarehouses()
        {
            // Fetch all the warehouses from the database
            var warehouses = await _context.Warehouses.ToListAsync();

            // Return the list of warehouses as an HTTP 200 OK response
            return Ok(warehouses);
        }

        // POST: api/v2/warehouse
        [HttpPost]
        public async Task<ActionResult<Warehouse>> PostWarehouse(Warehouse warehouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // If the data is not valid, return a 400 Bad Request
            }

            // Add the new warehouse to the DbContext
            _context.Warehouses.Add(warehouse);

            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return a 201 Created response with the added warehouse
            return CreatedAtAction(nameof(GetWarehouses), new { id = warehouse.Id }, warehouse);
        }
    }
}
