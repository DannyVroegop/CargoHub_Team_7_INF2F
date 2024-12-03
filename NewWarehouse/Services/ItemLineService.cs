using Microsoft.EntityFrameworkCore;
using Data; // Namespace for the DbContext
using Models; // Namespace for the ItemLine model

namespace Services
{
    public class ItemLineService : IItemLineService
    {
        private readonly CargoContext _context;

        public ItemLineService(CargoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemLine>> GetAllItemLinesAsync()
        {
            return await _context.ItemLines.ToListAsync();
        }

        public async Task<ItemLine> GetItemLineByIdAsync(int id)
        {
            return await _context.ItemLines.FindAsync(id); // Retrieve ItemLine by ID
        }

        public async Task<ItemLine> AddItemLineAsync(ItemLine itemLine)
        {
            _context.ItemLines.Add(itemLine);
            await _context.SaveChangesAsync();
            return itemLine;
        }

        public async Task<ItemLine?> UpdateItemLineAsync(int id, ItemLine updatedItemLine)
        {
            var existingItemLine = await _context.ItemLines.FindAsync(id);

            if (existingItemLine == null)
            {
                return null; // Return null if the ItemLine doesn't exist
            }

            // Update the fields of the existing ItemLine
            existingItemLine.Id = updatedItemLine.Id;
            existingItemLine.Name = updatedItemLine.Name;
            existingItemLine.Description = updatedItemLine.Description;
            existingItemLine.Created_at = updatedItemLine.Created_at;
            existingItemLine.Updated_at = updatedItemLine.Updated_at;

            // Save changes to the database
            await _context.SaveChangesAsync();

            return existingItemLine; // Return the updated ItemLine
        }

        public async Task<bool> DeleteItemLineAsync(int id)
        {
            var itemLine = await _context.ItemLines.FindAsync(id);
            if (itemLine == null)
            {
                return false; // Return false if the itemLine doesn't exist
            }

            _context.ItemLines.Remove(itemLine);
            await _context.SaveChangesAsync();
            return true; // Return true if the itemLine was successfully deleted
        }
    }
}