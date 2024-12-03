using Models; // Namespace for the Inventory model

namespace Services
{
    public interface IInventoryService
    {
        Task<IEnumerable<Inventory>> GetAllInventoriesAsync();
        Task<Inventory> GetInventoryByIdAsync(int id);
        Task<Inventory> AddInventoryAsync(Inventory inventory);
        Task<Inventory?> UpdateInventoryAsync(int id, Inventory updatedinventory);
        Task<bool> DeleteInventoryAsync(int id);
    }
}
