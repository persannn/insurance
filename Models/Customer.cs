using Insurance_Two_Tables.Interfaces;

namespace Insurance_Two_Tables.Models
{
    public class Customer : ICustomer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public List<Insurance> Insurance { get; } = new List<Insurance>();
        public virtual Address Address { get; set; }
        
        public Customer()
        {
            
        }
    }
}
