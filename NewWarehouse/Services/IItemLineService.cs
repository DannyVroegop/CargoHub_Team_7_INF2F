using Models; // Namespace for the ItemLine model

namespace Services
{
    public interface IItemLineService
    {
        Task<IEnumerable<ItemLine>> GetAllItemLinesAsync();
        Task<ItemLine> GetItemLineByIdAsync(int id);
        Task<ItemLine> AddItemLineAsync(ItemLine itemline);
        Task<ItemLine?> UpdateItemLineAsync(int id, ItemLine updateditemline);
        Task<bool> DeleteItemLineAsync(int id);
    }
}