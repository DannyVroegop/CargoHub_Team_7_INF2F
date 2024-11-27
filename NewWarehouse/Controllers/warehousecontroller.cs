using Microsoft.AspNetCore.Mvc;
using Models; // For Warehouse and WarehouseDTO
using Services;

namespace Controllers
{
    [Route("api/v2/[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        public WarehousesController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        // GET: api/v2/warehouses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarehouseDTO>>> GetWarehouses()
        {
            var warehouses = await _warehouseService.GetAllWarehousesAsync();
            var warehouseDTOs = warehouses.Select(MapWarehouseToDTO);
            return Ok(warehouseDTOs); // Return the list of DTOs
        }

        // POST: api/v2/warehouses
        [HttpPost]
        public async Task<ActionResult<WarehouseDTO>> PostWarehouse(WarehouseDTO warehouseDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return a 400 Bad Request if invalid
            }

            // Map DTO to Model
            var warehouse = MapDTOToWarehouse(warehouseDTO);
            var createdWarehouse = await _warehouseService.AddWarehouseAsync(warehouse);

            // Map Model back to DTO for the response
            var createdWarehouseDTO = MapWarehouseToDTO(createdWarehouse);
            return CreatedAtAction(nameof(GetWarehouses), new { id = createdWarehouseDTO.Id }, createdWarehouseDTO);
        }

        // PUT: api/v2/warehouses/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWarehouse(int id, WarehouseDTO warehouseDTO)
        {
            if (id != warehouseDTO.Id)
            {
                return BadRequest("Warehouse ID mismatch.");
            }

            // Map DTO to Model
            var warehouse = MapDTOToWarehouse(warehouseDTO);

            var updatedWarehouse = await _warehouseService.UpdateWarehouseAsync(id, warehouse);

            if (updatedWarehouse == null)
            {
                return NotFound();
            }

            // Map Model back to DTO for the response
            var updatedWarehouseDTO = MapWarehouseToDTO(updatedWarehouse);
            return Ok(updatedWarehouseDTO);
        }

        // DELETE: api/v2/warehouses/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarehouse(int id)
        {
            var warehouse = await _warehouseService.GetWarehouseByIdAsync(id);
            if (warehouse == null)
            {
                return NotFound(); // Return 404 if the warehouse is not found
            }

            var result = await _warehouseService.DeleteWarehouseAsync(id);
            if (!result)
            {
                return StatusCode(500, "Error deleting the warehouse."); // Return 500 if deletion fails
            }

            return NoContent(); // Return 204 No Content on successful deletion
        }

        // Mapping DTO to Model
        private Warehouse MapDTOToWarehouse(WarehouseDTO dto)
        {
            return new Warehouse
            {
                Id = dto.Id,
                Code = dto.Code,
                Name = dto.Name,
                Address = dto.Address,
                Zip_Code = dto.Zip,
                City = dto.City,
                Province = dto.Province,
                Country = dto.Country,
                ContactName = dto.Contact.Name,
                ContactPhone = dto.Contact.Phone,
                ContactEmail = dto.Contact.Email,
                Created_at = dto.Created_at,
                Updated_at = dto.Updated_at
            };
        }

        // Mapping Model to DTO
        private WarehouseDTO MapWarehouseToDTO(Warehouse warehouse)
        {
            return new WarehouseDTO
            {
                Id = warehouse.Id,
                Code = warehouse.Code,
                Name = warehouse.Name,
                Address = warehouse.Address,
                Zip = warehouse.Zip_Code,
                City = warehouse.City,
                Province = warehouse.Province,
                Country = warehouse.Country,
                Contact = new ContactDTO
                {
                    Name = warehouse.ContactName,
                    Phone = warehouse.ContactPhone,
                    Email = warehouse.ContactEmail
                },
                Created_at = warehouse.Created_at,
                Updated_at = warehouse.Updated_at
            };
        }
    }
}
