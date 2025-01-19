using System.ComponentModel.DataAnnotations;

namespace Insurance_Final_Version.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter the name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter the surname")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Enter the age")]
        public int Age { get; set; }
        public virtual List<Insurance> Insurances { get; set; }

        public CustomerViewModel()
        {

        }
    }
}
