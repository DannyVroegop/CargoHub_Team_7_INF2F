using System;

namespace Models
{
    #pragma warning disable CS8618
    public class OrderItem
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; }
    }
    #pragma warning restore CS8618
}
