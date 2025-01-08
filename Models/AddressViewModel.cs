using System.ComponentModel.DataAnnotations;

namespace Insurance_Two_Tables.Models
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Enter the street name")]
        public string? Street { get; set; }
        [Required(ErrorMessage = "Enter the house number")]
        public int? HouseNumber { get; set; }
        [Required(ErrorMessage = "Enter the registry number")]
        public int? RegistryNumber { get; set; }
        [Required(ErrorMessage = "Enter the city name")]
        public string? City { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
