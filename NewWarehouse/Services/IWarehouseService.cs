using Models; // Namespace for the Warehouse model

namespace Services
{
    public interface IWarehouseService
    {
        Task<IEnumerable<Warehouse>> GetAllWarehousesAsync();
        Task<Warehouse> AddWarehouseAsync(Warehouse warehouse);
    }
}
