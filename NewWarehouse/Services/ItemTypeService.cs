using Microsoft.EntityFrameworkCore;
using Data; // Namespace for the DbContext
using Models; // Namespace for the ItemType model

namespace Services
{
    public class ItemTypeService : IItemTypeService
    {
        private readonly CargoContext _context;

        public ItemTypeService(CargoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemType>> GetAllItemTypesAsync()
        {
            return await _context.ItemTypes.ToListAsync();
        }

        public async Task<ItemType> GetItemTypeByIdAsync(int id)
        {
            return await _context.ItemTypes.FindAsync(id); // Retrieve ItemType by ID
        }

        public async Task<ItemType> AddItemTypeAsync(ItemType itemType)
        {
            _context.ItemTypes.Add(itemType);
            await _context.SaveChangesAsync();
            return itemType;
        }

        public async Task<ItemType?> UpdateItemTypeAsync(int id, ItemType updatedItemType)
        {
            var existingItemType = await _context.ItemTypes.FindAsync(id);

            if (existingItemType == null)
            {
                return null; // Return null if the ItemType doesn't exist
            }

            // Update the fields of the existing ItemType
            existingItemType.Id = updatedItemType.Id;
            existingItemType.Name = updatedItemType.Name;
            existingItemType.Description = updatedItemType.Description;
            existingItemType.Created_at = updatedItemType.Created_at;
            existingItemType.Updated_at = updatedItemType.Updated_at;

            // Save changes to the database
            await _context.SaveChangesAsync();

            return existingItemType; // Return the updated ItemType
        }
        public async Task<bool> DeleteItemTypeAsync(int id)
        {
            var itemType = await _context.ItemTypes.FindAsync(id);
            if (itemType == null)
            {
                return false; // Return false if the ItemType doesn't exist
            }

            _context.ItemTypes.Remove(itemType);
            await _context.SaveChangesAsync();
            return true; // Return true if the ItemType was successfully deleted
        }
    }
}