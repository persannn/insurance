namespace Insurance_Two_Tables.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Insurance Insurance { get; set; }
    }
}
