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
        public string TransferFrom{ get; set; }
        public string TransferTo{ get; set; }
        public string TransferStatus{ get; set; }
        public string Created_at{ get; set; }
        public string Updated_at{ get; set; }
        public ICollection<TransferItem> TransferItems { get; set; }

        public Transfer(){}

        public Transfer(int id, string reference, string transferFrom, string transferTo, string transferStatus, string created_at, string updated_at, ICollection<TransferItem> transferItems){
            Id = id;
            Reference = reference;
            TransferFrom = transferFrom;
            TransferTo = transferTo;
            TransferStatus = transferStatus;
            Created_at = created_at;
            Updated_at = updated_at;
            TransferItems = transferItems;
        }
    }
}