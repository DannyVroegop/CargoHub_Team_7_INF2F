using Models; // Namespace for the ItemGroup model

namespace Services
{
    public interface IItemGroupService
    {
        Task<IEnumerable<ItemGroup>> GetAllItemGroupsAsync();
        Task<ItemGroup> GetItemGroupByIdAsync(int id);
        Task<ItemGroup> AddItemGroupAsync(ItemGroup itemGroup);
        Task<ItemGroup?> UpdateItemGroupAsync(int id, ItemGroup updateditemGroup);
        Task<bool> DeleteItemGroupAsync(int id);
    }
}