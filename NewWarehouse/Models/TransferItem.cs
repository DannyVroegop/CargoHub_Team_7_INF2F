namespace Models
{
    public class TransferItem
    {
        public int TransferId { get; set; }
        public Transfer Transfer { get; set; }

        public string ItemId { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; }
    }
}
