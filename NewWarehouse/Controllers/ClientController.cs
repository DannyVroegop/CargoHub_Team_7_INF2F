using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;  // Namespace for the DbContext
using Models;  // Namespace for the Warehouse model

namespace WarehouseCase.Controllers{

    [Route("api/v2/[Controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly CargoContext _Context;

        public (CargoContext context)
        {
            _context = context;
        }
        //GET api/v2/Clients
        [HttpGet]
        public async Task<IActionResult> Get(){
            var warehouses = await _context.Clients.ToListAsync();

            return Ok(warehouses);
        }

    }
}