using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models{
    public class ItemGroup{
        public int Id;
        public string Name;
        public string Description;
        public string Created_at;
        public string Updated_at;

        public ItemGroup(int id, string name, string description, string created_at, string updated_at){
            Id = id;
            Name = name;
            Description = description;
            Created_at = created_at;
            Updated_at = updated_at;
        }
    }
}