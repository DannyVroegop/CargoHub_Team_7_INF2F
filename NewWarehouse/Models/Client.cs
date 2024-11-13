using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Client
    {
        public int Id;
        public string Name;
        public string Address;
        public string City;
        public string Zip_Code;
        public string Province;
        public string Country;
        public string Contact_Name;
        public string Contact_Phone;
        public string Contact_Email;
        public string Created_at;
        public string Updated_at;

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