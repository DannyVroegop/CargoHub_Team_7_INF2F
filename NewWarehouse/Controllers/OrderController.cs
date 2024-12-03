using Microsoft.AspNetCore.Mvc;
using Models; // For Order and OrderItem models
using Services;

namespace Controllers
{
    [Route("api/v2/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/v2/orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            var orderDTOs = orders.Select(MapOrderToDTO);
            return Ok(orderDTOs);
        }

        // GET: api/v2/orders/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound(); // Return 404 if order not found
            }

            var orderDTO = MapOrderToDTO(order);
            return Ok(orderDTO); // Return the order DTO
        }

        // POST: api/v2/orders
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> PostOrder([FromBody] OrderDTO orderDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Map DTO to Order entity
            var order = MapDTOToOrder(orderDTO);

            // Save Order to the database
            var createdOrder = await _orderService.AddOrderAsync(order);

            // Map created Order back to DTO
            var createdOrderDto = MapOrderToDTO(createdOrder);

            // Return the created Order
            return CreatedAtAction(nameof(GetOrders), new { id = createdOrderDto.Id }, createdOrderDto);
        }

        // PUT: api/v2/orders/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, OrderDTO orderDTO)
        {
            if (id != orderDTO.Id)
            {
                return BadRequest("Order ID mismatch.");
            }

            // Map DTO to Model
            var order = MapDTOToOrder(orderDTO);

            var updatedOrder = await _orderService.UpdateOrderAsync(id, order);

            if (updatedOrder == null)
            {
                return NotFound();
            }

            // Map Model back to DTO for the response
            var updatedOrderDTO = MapOrderToDTO(updatedOrder);
            return Ok(updatedOrderDTO);
        }

        // DELETE: api/v2/orders/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrders(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound(); // Return 404 if the order is not found
            }

            var result = await _orderService.DeleteOrderAsync(id);
            if (!result)
            {
                return StatusCode(500, "Error deleting the order."); // Return 500 if deletion fails
            }

            return NoContent(); // Return 204 No Content on successful deletion
        }


        private OrderDTO MapOrderToDTO(Order order)
        {
            return new OrderDTO
            {
                Id = order.Id,
                Source_Id = order.Source_Id,
                Order_Date = order.Order_Date,
                Request_date = order.Request_date,
                Reference = order.Reference,
                Reference_Extra = order.Reference_Extra,
                Order_Status = order.Order_Status,
                Notes = order.Notes,
                Shipping_Notes = order.Shipping_Notes,
                Picking_Notes = order.Picking_Notes,
                Warehouse_Id = order.Warehouse_Id,
                Ship_To = order.Ship_To,
                Bill_To = order.Bill_To,
                Shipment_Id = order.Shipment_Id,
                Total_Ammount = order.Total_Ammount,
                Total_Discount = order.Total_Discount,
                Total_Tax = order.Total_Tax,
                Total_Surcharge = order.Total_Surcharge,
                Created_at = order.Created_at,
                Updated_at = order.Updated_at,
                Items = order.Items?.Select(item => new OrderItemDTO
                {
                    Item_Id = item.Item_Uid,
                    Amount = item.Quantity
                }).ToList()
            };
        }


        private Order MapDTOToOrder(OrderDTO orderDto)
        {
            return new Order
            {
                Id = orderDto.Id,
                Source_Id = orderDto.Source_Id,
                Order_Date = orderDto.Order_Date,
                Request_date = orderDto.Request_date,
                Reference = orderDto.Reference,
                Reference_Extra = orderDto.Reference_Extra,
                Order_Status = orderDto.Order_Status,
                Notes = orderDto.Notes,
                Shipping_Notes = orderDto.Shipping_Notes,
                Picking_Notes = orderDto.Picking_Notes,
                Warehouse_Id = orderDto.Warehouse_Id,
                Ship_To = orderDto.Ship_To,
                Bill_To = orderDto.Bill_To,
                Shipment_Id = orderDto.Shipment_Id,
                Total_Ammount = orderDto.Total_Ammount,
                Total_Discount = orderDto.Total_Discount,
                Total_Tax = orderDto.Total_Tax,
                Total_Surcharge = orderDto.Total_Surcharge,
                Created_at = orderDto.Created_at,
                Updated_at = orderDto.Updated_at,
                Items = orderDto.Items?.Select(itemDto => new OrderItem
                {
                    Item_Uid = itemDto.Item_Id,
                    Quantity = itemDto.Amount
                }).ToList()
            };
        }
    }
}
