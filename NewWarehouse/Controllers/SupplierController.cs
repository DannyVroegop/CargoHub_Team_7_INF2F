using Microsoft.AspNetCore.Mvc;
using Models; // For Supplier
using Services;

namespace Controllers
{
    [Route("api/v2/suppliers")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        // GET: api/v2/suppliers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
        {
            var suppliers = await _supplierService.GetAllSuppliersAsync();
            return Ok(suppliers);
        }

        // GET: api/v2/suppliers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSupplierById(int id)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            if (supplier == null)
            {
                return NotFound(); // Return 404 if Supplier not found
            }
            return Ok(supplier); // Return the Supplier 
        }

        // POST: api/v2/suppliers
        [HttpPost]
        public async Task<ActionResult<Supplier>> PostSupplier(Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return a 400 Bad Request if invalid
            }
            var createdSupplier = await _supplierService.AddSupplierAsync(supplier);
            return CreatedAtAction(nameof(GetSuppliers), new { id = createdSupplier.Id }, createdSupplier);
        }

        // PUT: api/v2/suppliers/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier(int id, Supplier supplier)
        {
            if (id != supplier.Id)
            {
                return BadRequest("Supplier ID mismatch.");
            }

            var updatedSupplier = await _supplierService.UpdateSupplierAsync(id, supplier);

            if (updatedSupplier == null)
            {
                return NotFound();
            }
            return Ok(updatedSupplier);
        }

        // DELETE: api/v2/suppliers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var supplier = await _supplierService.GetSupplierByIdAsync(id);
            if (supplier == null)
            {
                return NotFound(); // Return 404 if the Supplier is not found
            }

            var result = await _supplierService.DeleteSupplierAsync(id);
            if (!result)
            {
                return StatusCode(500, "Error deleting the supplier."); // Return 500 if deletion fails
            }

            return NoContent(); // Return 204 No Content on successful deletion
        }

    }
}