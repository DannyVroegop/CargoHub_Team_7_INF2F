using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models{

    public class Location{
        public int Id;
        public int WarehouseId;
        public string Code;
        public string Name;
        public string Created_at;
        public string Updated_at;

        public Location(int id, int warehouseId, string code, string name, string created_at, string updated_at){
            Id = id;
            WarehouseId = warehouseId;
            Code = code;
            Name = name;
            Created_at = created_at;
            Updated_at = updated_at;
        }
    }
}