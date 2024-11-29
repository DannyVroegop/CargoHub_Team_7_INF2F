using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Transfer
    {
        public int Id{ get; set; }
        public string Reference{ get; set; }
        public int Transfer_From{ get; set; }
        public int Transfer_To{ get; set; }
        public string Transfer_Status{ get; set; }
        public string Created_at{ get; set; }
        public string Updated_at{ get; set; }
        public ICollection<TransferItem> TransferItems { get; set; }

        public Transfer(){}

        public Transfer(int id, string reference, int transfer_From, int transfer_To, string transfer_Status, string created_at, string updated_at, ICollection<TransferItem> transferItems){
            Id = id;
            Reference = reference;
            Transfer_From = transfer_From;
            Transfer_To = transfer_To;
            Transfer_Status = transfer_Status;
            Created_at = created_at;
            Updated_at = updated_at;
            TransferItems = transferItems;
        }
    }

    public class TransferDTO
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public int Transfer_From { get; set; }
        public int Transfer_To { get; set; }
        public string Transfer_Status { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }
        public List<TransferItemDTO> Items { get; set; }
    }

    public class TransferItemDTO
    {
        public string Item_Id { get; set; }
        public int Amount { get; set; }
    }
}