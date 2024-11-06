using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Warehouse
    {
        public int id;
        public string code;
        public string name;
        public string address;
        public string city;
        public string zip_code;
        public string province;
        public string country;
        public string contact_name;
        public string contact_phone;
        public string contact_email;
        public string created_at;
        public string updated_at;

        public Warehouse(int _id, string _code, string _name, string _address, string _city, string _zip_code, string _province, string _country, string _contact_name, string _contact_phone, string _contact_email, string _created_at, string _updated_at)
        {
            id = _id;
            code = _code;
            name = _name;
            address = _address;
            city = _city;
            zip_code = _zip_code;
            province = _province;
            country = _country;
            contact_name = _contact_name;
            contact_phone = _contact_phone;
            contact_email = _contact_email;
            created_at = _created_at;
            updated_at = _updated_at;
        }
    }
}