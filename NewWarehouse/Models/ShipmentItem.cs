namespace Models
{
    public class ShipmentItem
    {
        public int Shipment_Id { get; set; }
        public Shipment Shipment { get; set; }

        public string Item_Id { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; }
    }
}
