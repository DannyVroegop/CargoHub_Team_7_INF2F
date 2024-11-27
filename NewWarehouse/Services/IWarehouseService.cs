using Models; // Namespace for the Warehouse model

namespace Services
{
    public interface IWarehouseService
    {
        Task<IEnumerable<Warehouse>> GetAllWarehousesAsync();
        Task<Warehouse> GetWarehouseByIdAsync(int id);
        Task<Warehouse> AddWarehouseAsync(Warehouse warehouse);
        Task<Warehouse?> UpdateWarehouseAsync(int id, Warehouse updatedWarehouse);
        Task<bool> DeleteWarehouseAsync(int id);
    }
}
