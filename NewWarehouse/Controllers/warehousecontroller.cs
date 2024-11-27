using Microsoft.AspNetCore.Mvc;
using Models; // Namespace for the Warehouse model
using WarehouseCase.Services; // Namespace for the IWarehouseService

namespace WarehouseCase.Controllers
{
    [Route("api/v2/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        // Constructor to inject the service
        public WarehousesController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        // GET: api/v2/warehouse
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Warehouse>>> GetWarehouses()
        {
            var warehouses = await _warehouseService.GetAllWarehousesAsync();
            return Ok(warehouses); // Return the list of warehouses
        }

        // POST: api/v2/warehouse
        [HttpPost]
        public async Task<ActionResult<Warehouse>> PostWarehouse(Warehouse warehouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return a 400 Bad Request if invalid
            }

            var createdWarehouse = await _warehouseService.AddWarehouseAsync(warehouse);
            return CreatedAtAction(nameof(GetWarehouses), new { id = createdWarehouse.Id }, createdWarehouse);
        }
    }
}
