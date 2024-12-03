using Microsoft.EntityFrameworkCore;
using Data; // Namespace for the DbContext
using Models; // Namespace for the ItemGroup model

namespace Services
{
    public class ItemGroupService : IItemGroupService
    {
        private readonly CargoContext _context;

        public ItemGroupService(CargoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemGroup>> GetAllItemGroupsAsync()
        {
            return await _context.ItemGroups.ToListAsync();
        }

        public async Task<ItemGroup> GetItemGroupByIdAsync(int id)
        {
            return await _context.ItemGroups.FindAsync(id); // Retrieve ItemGroup by ID
        }

        public async Task<ItemGroup> AddItemGroupAsync(ItemGroup itemGroup)
        {
            _context.ItemGroups.Add(itemGroup);
            await _context.SaveChangesAsync();
            return itemGroup;
        }

        public async Task<ItemGroup?> UpdateItemGroupAsync(int id, ItemGroup updatedItemGroup)
        {
            var existingItemGroup = await _context.ItemGroups.FindAsync(id);

            if (existingItemGroup == null)
            {
                return null; // Return null if the ItemGroup doesn't exist
            }

            // Update the fields of the existing ItemGroup
            existingItemGroup.Id = updatedItemGroup.Id;
            existingItemGroup.Name = updatedItemGroup.Name;
            existingItemGroup.Description = updatedItemGroup.Description;
            existingItemGroup.Created_at = updatedItemGroup.Created_at;
            existingItemGroup.Updated_at = updatedItemGroup.Updated_at;

            // Save changes to the database
            await _context.SaveChangesAsync();

            return existingItemGroup; // Return the updated ItemGroup
        }
        public async Task<bool> DeleteItemGroupAsync(int id)
        {
            var itemGroup = await _context.ItemGroups.FindAsync(id);
            if (itemGroup == null)
            {
                return false; // Return false if the ItemGroup doesn't exist
            }

            _context.ItemGroups.Remove(itemGroup);
            await _context.SaveChangesAsync();
            return true; // Return true if the ItemGroup was successfully deleted
        }
    }
}