using Models; // Namespace for the Transfer model

namespace Services
{
    public interface ITransferService
    {
        Task<IEnumerable<Transfer>> GetAllTransfersAsync();
        Task<Transfer> GetTransferByIdAsync(int id);
        Task<Transfer> AddTransferAsync(Transfer transferDto);
        Task<Transfer?> UpdateTransferAsync(int id, Transfer updatedtransfer);
        Task<bool> DeleteTransferAsync(int id);
    }
}
