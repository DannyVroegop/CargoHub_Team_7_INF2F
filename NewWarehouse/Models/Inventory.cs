using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models{
    public class Inventory{
        public int Id;
        public int Item_id;
        public string Description;
        public string ItemReference;
        public string Location_Id;
        public int TotalOnHand;
        public int TotalExpected;
        public int TotalOrdered;
        public int TotalAllocated;
        public int TotalAvailable;
        public string Created_at;
        public string Updated_at;

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