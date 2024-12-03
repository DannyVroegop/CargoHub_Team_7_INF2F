using Microsoft.EntityFrameworkCore;
using Data; // Namespace for the DbContext
using Models; // Namespace for Order and OrderItem models

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly CargoContext _context;

        public OrderService(CargoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Include(t => t.Items) // Ensure related items are included
                .ToListAsync();
        }
        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .Include(t => t.Items) // Include related OrderItems
                .FirstOrDefaultAsync(t => t.Id == id); // Retrieve Order by ID
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> UpdateOrderAsync(int id, Order updatedOrder)
        {
            var existingOrder = await _context.Orders
                .Include(t => t.Items) // Include OrderItems for updating
                .FirstOrDefaultAsync(t => t.Id == id);

            if (existingOrder == null)
            {
                return null; // Order not found
            }

            // Update the basic Order details
            existingOrder.Source_Id = updatedOrder.Source_Id;
            existingOrder.Order_Date = updatedOrder.Order_Date;
            existingOrder.Request_date = updatedOrder.Request_date;
            existingOrder.Reference = updatedOrder.Reference;
            existingOrder.Reference_Extra = updatedOrder.Reference_Extra;
            existingOrder.Order_Status = updatedOrder.Order_Status;
            existingOrder.Notes = updatedOrder.Notes;
            existingOrder.Shipping_Notes = updatedOrder.Shipping_Notes;
            existingOrder.Picking_Notes = updatedOrder.Picking_Notes;
            existingOrder.Warehouse_Id = updatedOrder.Warehouse_Id;
            existingOrder.Ship_To = updatedOrder.Ship_To;
            existingOrder.Bill_To = updatedOrder.Bill_To;
            existingOrder.Shipment_Id = updatedOrder.Shipment_Id;
            existingOrder.Total_Ammount = updatedOrder.Total_Ammount;
            existingOrder.Total_Discount = updatedOrder.Total_Discount;
            existingOrder.Total_Tax = updatedOrder.Total_Tax;
            existingOrder.Total_Surcharge = updatedOrder.Total_Surcharge;
            existingOrder.Created_at = updatedOrder.Created_at;
            existingOrder.Updated_at = updatedOrder.Updated_at;

            // Handle OrderItems
            foreach (var updatedItem in updatedOrder.Items)
            {
                // Check if the item already exists in the Order
                var existingItem = existingOrder.Items
                    .FirstOrDefault(item => item.Item_Uid == updatedItem.Item_Uid);

                if (existingItem != null)
                {
                    // Update the existing item's quantity (or other properties if necessary)
                    existingItem.Quantity = updatedItem.Quantity;
                }
                else
                {
                    // If item does not exist, add it to the Order
                    existingOrder.Items.Add(updatedItem);
                }
            }
            var itemsToRemove = existingOrder.Items
                .Where(item => !updatedOrder.Items.Any(updatedItem => updatedItem.Item_Uid == item.Item_Uid))
                .ToList();

            foreach (var itemToRemove in itemsToRemove)
            {
                existingOrder.Items.Remove(itemToRemove);
            }
            // Save changes to the database
            await _context.SaveChangesAsync();
            return existingOrder;
        }


        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return false; // Return false if the order doesn't exist
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true; // Return true if the order was successfully deleted
        }
    }
}
