using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models{

    public class Location{
        public int Id{ get; set; }
        public int WarehouseId{ get; set; }
        public string Code{ get; set; }
        public string Name{ get; set; }
        public string Created_at{ get; set; }
        public string Updated_at{ get; set; }

        #pragma warning disable CS8618
        public Location(){}

        #pragma warning restore CS8618
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