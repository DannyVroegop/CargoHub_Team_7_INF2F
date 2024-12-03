using Microsoft.EntityFrameworkCore;
using Data; // Namespace for the DbContext
using Models; // Namespace for the Supplier model

namespace Services
{
    public class SupplierService : ISupplierService
    {
        private readonly CargoContext _context;

        public SupplierService(CargoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier> GetSupplierByIdAsync(int id)
        {
            return await _context.Suppliers.FindAsync(id); // Retrieve Supplier by ID
        }

        public async Task<Supplier> AddSupplierAsync(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<Supplier?> UpdateSupplierAsync(int id, Supplier updatedSupplier)
        {
            var existingSupplier = await _context.Suppliers.FindAsync(id);

            if (existingSupplier == null)
            {
                return null; // Return null if the Supplier doesn't exist
            }

            // Update the fields of the existing Supplier
            existingSupplier.Code = updatedSupplier.Code;
            existingSupplier.Name = updatedSupplier.Name;
            existingSupplier.Address = updatedSupplier.Address;
            existingSupplier.Address_Extra = updatedSupplier.Address_Extra;
            existingSupplier.City = updatedSupplier.City;
            existingSupplier.Zip_Code = updatedSupplier.Zip_Code;
            existingSupplier.Province = updatedSupplier.Province;
            existingSupplier.Country = updatedSupplier.Country;
            existingSupplier.Contact_Name = updatedSupplier.Contact_Name;
            existingSupplier.Phonenumber = updatedSupplier.Phonenumber;
            existingSupplier.Reference = updatedSupplier.Reference;
            existingSupplier.Created_at = updatedSupplier.Created_at;
            existingSupplier.Updated_at = updatedSupplier.Updated_at;

            // Save changes to the database
            await _context.SaveChangesAsync();

            return existingSupplier; // Return the updated Supplier
        }

        public async Task<bool> DeleteSupplierAsync(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return false; // Return false if the Supplier doesn't exist
            }

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
            return true; // Return true if the supplier was successfully deleted
        }
    }
}