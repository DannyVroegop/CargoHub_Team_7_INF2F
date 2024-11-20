using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Code{ get; set; }
        public string Name{ get; set; }
        public string Address{ get; set; }
        public string City{ get; set; }
        public string Zip_Code{ get; set; }
        public string Province{ get; set; }
        public string Country{ get; set; }
        public string ContactName{ get; set; }
        public string ContactPhone{ get; set; }
        public string ContactEmail{ get; set; }
        public string Created_at{ get; set; }
        public string Updated_at{ get; set; }

        public Warehouse() { }

        public Warehouse(int id, string code, string name, string address, string city, string zip_Code, string province, string country, string contact_name, string contact_phone, string contact_email, string created_at, string updated_at)
        {
            Id = id;
            Code = code;
            Name = name;
            Address = address;
            City = city;
            Zip_Code = zip_Code;
            Province = province;
            Country = country;
            ContactName = contact_name;
            ContactPhone = contact_phone;
            ContactEmail = contact_email;
            Created_at = created_at;
            Updated_at = updated_at;
        }
    }
}