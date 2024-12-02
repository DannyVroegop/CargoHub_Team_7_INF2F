using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models{
    public class Inventory{
        public int Id{ get; set; }
        public int Item_id{ get; set; }
        public string Description{ get; set; }
        public string ItemReference{ get; set; }
        public string Location_Id{ get; set; }
        public int TotalOnHand{ get; set; }
        public int TotalExpected{ get; set; }
        public int TotalOrdered{ get; set; }
        public int TotalAllocated{ get; set; }
        public int TotalAvailable{ get; set; }
        public string Created_at{ get; set; }
        public string Updated_at{ get; set; }

        #pragma warning disable CS8618
        public Inventory(){}
        #pragma warning restore CS8618
        public Inventory(int id, int item_id, string description, string item_reference, string location_id, int totalOnHand, int totalExpected, int totalOrdered, int totalAllocated, int totalAvailable, string created_at, string updated_at){
            Id = id;
            Item_id = item_id;
            Description = description;
            ItemReference = item_reference;
            Location_Id = location_id;
            TotalOnHand = totalOnHand;
            TotalExpected = totalExpected;
            TotalAllocated = totalAllocated;
            TotalAvailable = totalAvailable;
            Created_at = created_at;
            Updated_at = updated_at;
        }
    }
}