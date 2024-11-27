using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models{

    public class Supplier{
        public int Id{ get; set; }
        public string Code{ get; set; }
        public string Name{ get; set; }
        public string Address{ get; set; }
        public string City{ get; set; }
        public string Zip_Code{ get; set; }
        public string Province{ get; set; }
        public string Country{ get; set; }
        public string ContactName{ get; set; }
        public string ContactPhone{ get; set; }
        public string Reference{ get; set; }
        public string Created_at{ get; set; }
        public string Updated_at{ get; set; }

        public string AddressExtra { get; set; }

        #pragma warning disable CS8618
        public Supplier(){}
        #pragma warning restore CS8618
        public Supplier(int id, string code, string name, string address, string city, string zip_Code, string province, string country, string contactName, string contactPhone, string reference, string created_at, string updated_at, string addressExtra = "~"){
            Id = id;
            Code = code;
            Name = name;
            Address = address;
            AddressExtra = addressExtra;
            City = city;
            Zip_Code = zip_Code;
            Province = province;
            Country = country;
            ContactName = contactName;
            ContactPhone = contactPhone;
            Reference = reference;
            Created_at = created_at;
            Updated_at = updated_at;
        }
    }
}