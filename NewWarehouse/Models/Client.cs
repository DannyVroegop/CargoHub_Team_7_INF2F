using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Client
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public string Address{ get; set; }
        public string City{ get; set; }
        public string Zip_Code{ get; set; }
        public string Province{ get; set; }
        public string Country{ get; set; }
        public string Contact_Name{ get; set; }
        public string Contact_Phone{ get; set; }
        public string Contact_Email{ get; set; }
        public string Created_at{ get; set; }
        public string Updated_at{ get; set; }
        #pragma warning disable CS8618
        public Client(){}
        #pragma warning restore CS8618
        public Client(int id, string name, string address, string city, string zip_code, string province, string country, string contact_name, string contact_phone, string contact_email, string created_at, string updated_at){
            Id = id;
            Name = name;
            Address = address;
            City = city;
            Zip_Code = zip_code;
            Province = province;
            Country = country;
            Contact_Name = contact_name;
            Contact_Phone = contact_phone;
            Contact_Email = contact_email;
            Created_at = created_at;
            Updated_at = updated_at;
        }
    }
}