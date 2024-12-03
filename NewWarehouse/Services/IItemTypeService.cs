using Models; // Namespace for the ItemType model

namespace Services
{
    public interface IItemTypeService
    {
        Task<IEnumerable<ItemType>> GetAllItemTypesAsync();
        Task<ItemType> GetItemTypeByIdAsync(int id);
        Task<ItemType> AddItemTypeAsync(ItemType itemType);
        Task<ItemType?> UpdateItemTypeAsync(int id, ItemType updateditemType);
        Task<bool> DeleteItemTypeAsync(int id);
    }
}