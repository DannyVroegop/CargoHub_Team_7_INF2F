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
        public string? Address_Extra{ get; set; }
        public string City{ get; set; }
        public string Zip_Code{ get; set; }
        public string Province{ get; set; }
        public string Country{ get; set; }
        public string Contact_Name{ get; set; }
        public string Phonenumber{ get; set; }
        public string Reference{ get; set; }
        public string Created_at{ get; set; }
        public string Updated_at{ get; set; }


        public Supplier(){}

        public Supplier(int id, string code, string name, string address, string city, string zip_Code, string province, string country, string contact_Name, string phonenumber, string reference, string created_at, string updated_at, string address_Extra = "empty"){
            Id = id;
            Code = code;
            Name = name;
            Address = address;
            Address_Extra = address_Extra;
            City = city;
            Zip_Code = zip_Code;
            Province = province;
            Country = country;
            Contact_Name = contact_Name;
            Phonenumber = phonenumber;
            Reference = reference;
            Created_at = created_at;
            Updated_at = updated_at;
        }
    }
}