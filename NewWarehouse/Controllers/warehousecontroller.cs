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
        private readonly WarehouseContext _context;

        // Constructor to inject the DbContext
        public WarehousesController(WarehouseContext context)
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
    }
}
