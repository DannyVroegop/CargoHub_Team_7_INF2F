using Microsoft.EntityFrameworkCore;
using Data; // Namespace for the DbContext
using Models; // Namespace for Shipment and ShipmentItem models

namespace Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly CargoContext _context;

        public ShipmentService(CargoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Shipment>> GetAllShipmentsAsync()
        {
            return await _context.Shipments
                .Include(t => t.Items) // Ensure related items are included
                .ToListAsync();
        }
        public async Task<Shipment> GetShipmentByIdAsync(int id)
        {
            return await _context.Shipments
                .Include(t => t.Items) // Include related ShipmentItems
                .FirstOrDefaultAsync(t => t.Id == id); // Retrieve Shipment by ID
        }

        public async Task<Shipment> AddShipmentAsync(Shipment shipment)
        {
            _context.Shipments.Add(shipment);
            await _context.SaveChangesAsync();
            return shipment;
        }

        public async Task<Shipment?> UpdateShipmentAsync(int id, Shipment updatedShipment)
        {
            var existingShipment = await _context.Shipments
                .Include(t => t.Items) // Include ShipmentItems for updating
                .FirstOrDefaultAsync(t => t.Id == id);

            if (existingShipment == null)
            {
                return null; // Shipment not found
            }

            // Update the basic Shipment details
            existingShipment.Order_Id = updatedShipment.Order_Id;
            existingShipment.Source_Id = updatedShipment.Source_Id;
            existingShipment.Order_Date = updatedShipment.Order_Date;
            existingShipment.Request_date = updatedShipment.Request_date;
            existingShipment.Shipment_Date = updatedShipment.Shipment_Date;
            existingShipment.Shipment_Type = updatedShipment.Shipment_Type;
            existingShipment.Shipment_Status = updatedShipment.Shipment_Status;
            existingShipment.Notes = updatedShipment.Notes;
            existingShipment.Carrier_Code = updatedShipment.Carrier_Code;
            existingShipment.Carrier_Description = updatedShipment.Carrier_Description;
            existingShipment.Service_Code = updatedShipment.Service_Code;
            existingShipment.Payment_Type = updatedShipment.Payment_Type;
            existingShipment.Transfer_Mode = updatedShipment.Transfer_Mode;
            existingShipment.Total_Package_Count = updatedShipment.Total_Package_Count;
            existingShipment.Total_Package_Weight = updatedShipment.Total_Package_Weight;
            existingShipment.Created_at = updatedShipment.Created_at;
            existingShipment.Updated_at = updatedShipment.Updated_at;

            // Handle ShipmentItems
            foreach (var updatedItem in updatedShipment.Items)
            {
                // Check if the item already exists in the Shipment
                var existingItem = existingShipment.Items
                    .FirstOrDefault(item => item.Item_Uid == updatedItem.Item_Uid);

                if (existingItem != null)
                {
                    // Update the existing item's quantity (or other properties if necessary)
                    existingItem.Quantity = updatedItem.Quantity;
                }
                else
                {
                    // If item does not exist, add it to the Shipment
                    existingShipment.Items.Add(updatedItem);
                }
            }
            var itemsToRemove = existingShipment.Items
                .Where(item => !updatedShipment.Items.Any(updatedItem => updatedItem.Item_Uid == item.Item_Uid))
                .ToList();

            foreach (var itemToRemove in itemsToRemove)
            {
                existingShipment.Items.Remove(itemToRemove);
            }
            // Save changes to the database
            await _context.SaveChangesAsync();
            return existingShipment;
        }


        public async Task<bool> DeleteShipmentAsync(int id)
        {
            var shipment = await _context.Shipments.FindAsync(id);
            if (shipment == null)
            {
                return false; // Return false if the shipment doesn't exist
            }

            _context.Shipments.Remove(shipment);
            await _context.SaveChangesAsync();
            return true; // Return true if the shipment was successfully deleted
        }
    }
}
