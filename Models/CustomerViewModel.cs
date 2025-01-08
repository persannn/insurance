using System.ComponentModel.DataAnnotations;

namespace Insurance_Two_Tables.Models
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
        public Insurance Insurance { get; set; }
        public virtual Address Address { get; set; }
    }
}
