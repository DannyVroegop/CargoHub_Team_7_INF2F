namespace Models
{
    #pragma warning disable CS8618
    public class ShipmentItem
    {
        public int ShipmentId { get; set; }
        public Shipment Shipment { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; }
    }
    #pragma warning restore CS8618
}
