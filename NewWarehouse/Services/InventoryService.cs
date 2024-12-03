using Microsoft.EntityFrameworkCore;
using Data; // Namespace for the DbContext
using Models; // Namespace for the Inventory model

namespace Services
{
    public class InventoryService : IInventoryService
    {
        private readonly CargoContext _context;

        public InventoryService(CargoContext context)
        {
            _context = context;
        }

        // Get all inventories
        public async Task<IEnumerable<Inventory>> GetAllInventoriesAsync()
        {
            return await _context.Inventories.ToListAsync();
        }

        public async Task<Inventory> GetInventoryByIdAsync(int id)
        {
            return await _context.Inventories.FindAsync(id); // Retrieve Inventory by ID
        }

        // Add a new inventory
        public async Task<Inventory> AddInventoryAsync(Inventory inventory)
        {
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();
            return inventory;
        }

        public async Task<Inventory?> UpdateInventoryAsync(int id, Inventory updatedInventory)
        {
            var existingInventory = await _context.Inventories.FindAsync(id);

            if (existingInventory == null)
            {
                return null; // Return null if the Inventory doesn't exist
            }

            // Update the fields of the existing Inventory 
            existingInventory.Id = updatedInventory.Id;
            existingInventory.Item_id = updatedInventory.Item_id;
            existingInventory.Description = updatedInventory.Description;
            existingInventory.Item_Reference = updatedInventory.Item_Reference;
            existingInventory.Locations = updatedInventory.Locations;
            existingInventory.Total_On_Hand = updatedInventory.Total_On_Hand;
            existingInventory.Total_Expected = updatedInventory.Total_Expected;
            existingInventory.Total_Ordered = updatedInventory.Total_Ordered;
            existingInventory.Total_Allocated = updatedInventory.Total_Allocated;
            existingInventory.Total_Available = updatedInventory.Total_Available;            
            existingInventory.Created_at = updatedInventory.Created_at;
            existingInventory.Updated_at = updatedInventory.Updated_at;

            // Save changes to the database
            await _context.SaveChangesAsync();

            return existingInventory; // Return the updated Inventory 
        }

        public async Task<bool> DeleteInventoryAsync(int id)
        {
            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory == null)
            {
                return false; // Return false if the Inventory doesn't exist
            }

            _context.Inventories.Remove(inventory);
            await _context.SaveChangesAsync();
            return true; // Return true if the Inventory was successfully deleted
        }
    }
}
