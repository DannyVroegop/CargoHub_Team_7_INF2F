using Models; // Namespace for the Order model

namespace Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task<Order> AddOrderAsync(Order order);
        Task<Order?> UpdateOrderAsync(int id, Order updatedorder);
        Task<bool> DeleteOrderAsync(int id);
    }
}
