using Insurance_Final_Version.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insurance_Final_Version.Models
{
    public class CustomerViewModel : IViewModelable
    {
        public int Id { get; set; }

        [NotMapped]
        public int? CustomerId { get; set; }

        [Required(ErrorMessage = "Enter the name")]
        [Length(2, 20, ErrorMessage = "Name must be between 2 and 20 characters long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter the surname")]
        [Length(2, 20, ErrorMessage = "Surname must be between 2 and 20 characters long")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Enter the age")]
        [Range(1, 150, ErrorMessage = "Age must be between 1 and 150 years")]
        public int Age { get; set; }

        [DisplayName("Phone Number Prefix")]
        [Required(ErrorMessage = "Enter the phone number prefix")]
        [Length(0, 4, ErrorMessage = "Prefix must have between 0 and 4 digits")]
        public string PhoneNumberPrefix { get; set; }

        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "Enter the phone number")]
        [Range(1000000, 999999999999, ErrorMessage = "The phone number must have between 7 and 12 digits")]
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
