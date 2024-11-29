using Microsoft.EntityFrameworkCore;
using Data; // Namespace for the DbContext
using Models; // Namespace for the Item model

namespace Services
{
    public class ItemService : IItemService
    {
        private readonly CargoContext _context;

        public ItemService(CargoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetItemByIdAsync(string uid)
        {
            return await _context.Items.FindAsync(uid); // Retrieve Item by UID
        }

        public async Task<Item> AddItemAsync(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Item?> UpdateItemAsync(string id, Item updatedItem)
        {
            var existingItem = await _context.Items.FindAsync(id);

            if (existingItem == null)
            {
                return null; // Return null if the Item doesn't exist
            }

            // Update the fields of the existing Item
            existingItem.Code = updatedItem.Code;
            existingItem.Description = updatedItem.Description;
            existingItem.Short_Description = updatedItem.Short_Description;
            existingItem.Upc_Code = updatedItem.Upc_Code;
            existingItem.Model_Number = updatedItem.Model_Number;
            existingItem.Commodity_Code = updatedItem.Commodity_Code;
            existingItem.Item_Line = updatedItem.Item_Line;
            existingItem.Item_Group = updatedItem.Item_Group;
            existingItem.Item_Type = updatedItem.Item_Type;
            existingItem.Unit_Purchase_Quantity = updatedItem.Unit_Purchase_Quantity;
            existingItem.Unit_Order_Quantity = updatedItem.Unit_Order_Quantity;
            existingItem.Pack_Order_Quantity = updatedItem.Pack_Order_Quantity;
            existingItem.Supplier_Id = updatedItem.Supplier_Id;
            existingItem.Supplier_Code = updatedItem.Supplier_Code;
            existingItem.Supplier_Part_Number = updatedItem.Supplier_Part_Number;
            existingItem.Created_at = updatedItem.Created_at;
            existingItem.Updated_at = updatedItem.Updated_at;

            // Save changes to the database
            await _context.SaveChangesAsync();

            return existingItem; // Return the updated Item
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return false; // Return false if the item doesn't exist
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return true; // Return true if the item was successfully deleted
        }
    }
}