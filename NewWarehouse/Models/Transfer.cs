using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Transfer
    {
        public int Id;
        public string Reference;
        public string TransferFrom;
        public string TransferTo;
        public string TransferStatus;
        public string Created_at;
        public string Updated_at;
        public Dictionary<int, int> Items;

        public Transfer(int id, string reference, string transferFrom, string transferTo, string transferStatus, string created_at, string updated_at, Dictionary<int, int> items){
            Id = id;
            Reference = reference;
            TransferFrom = transferFrom;
            TransferTo = transferTo;
            TransferStatus = transferStatus;
            Created_at = created_at;
            Updated_at = updated_at;
        }
    }
}