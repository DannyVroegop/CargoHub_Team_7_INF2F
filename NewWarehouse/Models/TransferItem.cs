namespace Models
{
    #pragma warning disable CS8618
    public class TransferItem
    {
        public int TransferId { get; set; }
        public Transfer Transfer { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int Quantity { get; set; }
    }
    #pragma warning restore CS8618
}
