using System;

namespace Models
{
    public class OrderItem
    {
        public int Order_Id { get; set; }
        public Order Order { get; set; }

        public string Item_Uid { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; }
    }
}
