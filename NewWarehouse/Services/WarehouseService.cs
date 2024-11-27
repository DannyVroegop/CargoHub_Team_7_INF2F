using Microsoft.EntityFrameworkCore;
using Data; // Namespace for the DbContext
using Models; // Namespace for the Warehouse model

namespace Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly CargoContext _context;

        public WarehouseService(CargoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Warehouse>> GetAllWarehousesAsync()
        {
            return await _context.Warehouses.ToListAsync();
        }

        public async Task<Warehouse> AddWarehouseAsync(Warehouse warehouse)
        {
            _context.Warehouses.Add(warehouse);
            await _context.SaveChangesAsync();
            return warehouse;
        }
    }
}
