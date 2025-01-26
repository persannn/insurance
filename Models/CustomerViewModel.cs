using Insurance_Final_Version.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Insurance_Final_Version.Models
{
    public class CustomerViewModel : IViewModelable
    {
        public int? Id { get; set; }
        public int? CustomerId { get { return Id; } set { Id = value; } }
        [Required(ErrorMessage = "Enter the name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter the surname")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Enter the age")]
        public int Age { get; set; }
        [DisplayName("Phone Number Prefix")]
        [Required(ErrorMessage = "Enter the phone number prefix")]
        public string PhoneNumberPrefix { get; set; }
        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "Enter the phone number")]
        public int PhoneNumber { get; set; }
        [EmailAddress(ErrorMessage = "Error - not the right format")]
        [Required(ErrorMessage="Enter the email address")]
        public string Email { get; set; }
        [DisplayName("Insurances")]
        public virtual List<Insurance>? Insurances { get; set; }

        public CustomerViewModel()
        {

        }
    }
}
