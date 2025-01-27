using Insurance_Final_Version.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insurance_Final_Version.Models
{
    public class Customer : ICustomer
    {
        public int Id { get; set; }
        [NotMapped]
        public int? CustomerId
        {
            get { return Id; }
            set
            {
                if(value != null)
                Id = (int)value;
            }
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public virtual List<Insurance>? Insurances { get; set; }
        public virtual Address Address { get; set; }
        public string PhoneNumberPrefix { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }

        public Customer()
        {

        }
    }
}
