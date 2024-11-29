using Microsoft.EntityFrameworkCore;
using Data; // Namespace for the DbContext
using Models; // Namespace for Transfer and TransferItem models

namespace Services
{
    public class TransferService : ITransferService
    {
        private readonly CargoContext _context;

        public TransferService(CargoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transfer>> GetAllTransfersAsync()
        {
            return await _context.Transfers
                .Include(t => t.TransferItems) // Ensure related items are included
                .ToListAsync();
        }
        public async Task<Transfer> GetTransferByIdAsync(int id)
        {
            return await _context.Transfers
                .Include(t => t.TransferItems) // Include related TransferItems
                .FirstOrDefaultAsync(t => t.Id == id); // Retrieve transfer by ID
        }

        public async Task<Transfer> AddTransferAsync(Transfer transfer)
        {
            _context.Transfers.Add(transfer);
            await _context.SaveChangesAsync();
            return transfer;
        }

        public async Task<Transfer?> UpdateTransferAsync(int id, Transfer updatedTransfer)
        {
            var existingTransfer = await _context.Transfers
                .Include(t => t.TransferItems) // Include TransferItems for updating
                .FirstOrDefaultAsync(t => t.Id == id);

            if (existingTransfer == null)
            {
                return null; // Transfer not found
            }

            // Update the basic transfer details
            existingTransfer.Reference = updatedTransfer.Reference;
            existingTransfer.Transfer_From = updatedTransfer.Transfer_From;
            existingTransfer.Transfer_To = updatedTransfer.Transfer_To;
            existingTransfer.Transfer_Status = updatedTransfer.Transfer_Status;
            existingTransfer.Created_at = updatedTransfer.Created_at;
            existingTransfer.Updated_at = updatedTransfer.Updated_at;

            // Handle TransferItems
            foreach (var updatedItem in updatedTransfer.TransferItems)
            {
                // Check if the item already exists in the transfer
                var existingItem = existingTransfer.TransferItems
                    .FirstOrDefault(item => item.Item_Uid == updatedItem.Item_Uid);

                if (existingItem != null)
                {
                    // Update the existing item's quantity (or other properties if necessary)
                    existingItem.Quantity = updatedItem.Quantity;
                }
                else
                {
                    // If item does not exist, add it to the transfer
                    existingTransfer.TransferItems.Add(updatedItem);
                }
            }
            var itemsToRemove = existingTransfer.TransferItems
                .Where(item => !updatedTransfer.TransferItems.Any(updatedItem => updatedItem.Item_Uid == item.Item_Uid))
                .ToList();

            foreach (var itemToRemove in itemsToRemove)
            {
                existingTransfer.TransferItems.Remove(itemToRemove);
            }
            // Save changes to the database
            await _context.SaveChangesAsync();
            return existingTransfer;
        }


        public async Task<bool> DeleteTransferAsync(int id)
        {
            var transfer = await _context.Transfers.FindAsync(id);
            if (transfer == null)
            {
                return false; // Return false if the transfer doesn't exist
            }

            _context.Transfers.Remove(transfer);
            await _context.SaveChangesAsync();
            return true; // Return true if the transfer was successfully deleted
        }
    }
}
