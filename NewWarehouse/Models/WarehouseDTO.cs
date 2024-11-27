namespace Models
{
    public class WarehouseDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public ContactDTO Contact { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }
    }

    public class ContactDTO
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
