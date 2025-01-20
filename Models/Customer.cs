using Insurance_Final_Version.Interfaces;

namespace Insurance_Final_Version.Models
{
    public class Customer : ICustomer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public virtual List<Insurance> Insurances { get; set; }
        public virtual Address Address { get; set; }

        public Customer()
        {

        }
    }
}
