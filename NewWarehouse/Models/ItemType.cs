using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models{

    public class ItemType{
        public int Id{ get; set; }
        public string Name{ get; set; }
        public string Description{ get; set; }
        public string Created_at{ get; set; }
        public string Updated_at{ get; set; }
        #pragma warning disable CS8618
        public ItemType(){}
        #pragma warning restore CS8618
        public ItemType(int id, string name, string description, string created_at, string updated_at){
            Id = id;
            Name = name;
            Description = description;
            Created_at = created_at;
            Updated_at = updated_at;
        }
    }
}