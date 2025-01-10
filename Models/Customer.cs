using Insurance_Two_Tables.Interfaces;

namespace Insurance_Two_Tables.Models
{
    public class Customer : ICustomer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Insurance Insurance { get; set; }
        public virtual Address Address { get; set; }
    }
}
