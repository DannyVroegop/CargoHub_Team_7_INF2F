using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Warehouse
    {
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
        public string ContactEmail;
        public string Created_at;
        public string Updated_at;

        public Warehouse(int _id, string _code, string _name, string _address, string _city, string _zip_code, string _province, string _country, string _contact_name, string _contact_phone, string _contact_email, string _created_at, string _updated_at)
        {
            Id = _id;
            Code = _code;
            Name = _name;
            Address = _address;
            City = _city;
            Zip_Code = _zip_code;
            Province = _province;
            Country = _country;
            ContactName = _contact_name;
            ContactPhone = _contact_phone;
            ContactEmail = _contact_email;
            Created_at = _created_at;
            Updated_at = _updated_at;
        }
    }
}