using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Item_id { get; set; }
        public string Description { get; set; }
        public string Item_Reference { get; set; }
        public List<int> Locations { get; set; }
        public int Total_On_Hand { get; set; }
        public int Total_Expected { get; set; }
        public int Total_Ordered { get; set; }
        public int Total_Allocated { get; set; }
        public int Total_Available { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }

        public Inventory()
        {
            Locations = new List<int>();
        }

        public Inventory(int id, string item_id, string description, string item_reference, string location_id, int total_On_Hand, int total_Expected, int total_Ordered, int total_Allocated, int total_Available, string created_at, string updated_at){
            Id = id;
            Item_id = item_id;
            Description = description;
            Item_Reference = item_reference;
            Total_On_Hand = total_On_Hand;
            Total_Expected = total_Expected;
            Total_Allocated = total_Allocated;
            Total_Available = total_Available;
            Created_at = created_at;
            Updated_at = updated_at;
        }
    }
}