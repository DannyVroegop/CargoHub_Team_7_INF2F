namespace Models
{
    public class TransferItem
    {
        public int Transfer_Id { get; set; }
        public Transfer Transfer { get; set; }

        public string Item_Id { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; }
    }
}
