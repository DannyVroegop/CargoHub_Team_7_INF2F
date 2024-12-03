using Models; // Namespace for the Supplier model

namespace Services
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> GetAllSuppliersAsync();
        Task<Supplier> GetSupplierByIdAsync(int id);
        Task<Supplier> AddSupplierAsync(Supplier supplier);
        Task<Supplier?> UpdateSupplierAsync(int id, Supplier updatedsupplier);
        Task<bool> DeleteSupplierAsync(int id);
    }
}
