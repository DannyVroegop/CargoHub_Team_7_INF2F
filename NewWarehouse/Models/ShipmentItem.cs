namespace Models
{
    public class ShipmentItem
    {
        public int ShipmentId { get; set; }
        public Shipment Shipment { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; }
    }
}
