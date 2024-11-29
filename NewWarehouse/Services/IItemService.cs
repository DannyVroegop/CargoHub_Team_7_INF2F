using Models; // Namespace for the Transfer model

namespace Services
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task<Item> GetItemByIdAsync(string uid);
        Task<Item> AddItemAsync(Item item);
        Task<Item?> UpdateItemAsync(string uid, Item updatedItem);
        Task<bool> DeleteItemAsync(string id);
    }
}