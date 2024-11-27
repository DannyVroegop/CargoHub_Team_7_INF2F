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

        public async Task<Warehouse> GetWarehouseByIdAsync(int id)
        {
            return await _context.Warehouses.FindAsync(id); // Retrieve warehouse by ID
        }

        public async Task<Warehouse> AddWarehouseAsync(Warehouse warehouse)
        {
            _context.Warehouses.Add(warehouse);
            await _context.SaveChangesAsync();
            return warehouse;
        }

        public async Task<Warehouse?> UpdateWarehouseAsync(int id, Warehouse updatedWarehouse)
        {
            var existingWarehouse = await _context.Warehouses.FindAsync(id);

            if (existingWarehouse == null)
            {
                return null; // Return null if the warehouse doesn't exist
            }

            // Update the fields of the existing warehouse
            existingWarehouse.Code = updatedWarehouse.Code;
            existingWarehouse.Name = updatedWarehouse.Name;
            existingWarehouse.Address = updatedWarehouse.Address;
            existingWarehouse.Zip_Code = updatedWarehouse.Zip_Code;
            existingWarehouse.City = updatedWarehouse.City;
            existingWarehouse.Province = updatedWarehouse.Province;
            existingWarehouse.Country = updatedWarehouse.Country;
            existingWarehouse.ContactName = updatedWarehouse.ContactName;
            existingWarehouse.ContactPhone = updatedWarehouse.ContactPhone;
            existingWarehouse.ContactEmail = updatedWarehouse.ContactEmail;
            existingWarehouse.Created_at = updatedWarehouse.Created_at;
            existingWarehouse.Updated_at = updatedWarehouse.Updated_at;

            // Save changes to the database
            await _context.SaveChangesAsync();

            return existingWarehouse; // Return the updated warehouse
        }

        public async Task<bool> DeleteWarehouseAsync(int id)
        {
            var warehouse = await _context.Warehouses.FindAsync(id);
            if (warehouse == null)
            {
                return false; // Return false if the warehouse doesn't exist
            }

            _context.Warehouses.Remove(warehouse);
            await _context.SaveChangesAsync();
            return true; // Return true if the warehouse was successfully deleted
        }
    }
}
