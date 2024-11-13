using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models{

    public class Supplier{
        public int Id;
        public string Code;
        public string Name;
        public string Address;
        public string City;
        public string Zip_Code;
        public string Province;
        public string Country;
        public string ContactName;
        public string ContactPhone;
        public string Reference;
        public string Created_at;
        public string Updated_at;

        public string AddressExtra = "~";

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