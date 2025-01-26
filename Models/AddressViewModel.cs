using Insurance_Final_Version.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Insurance_Final_Version.Models
{
    /// <summary>
    /// ViewModel mapped to the Address class
    /// </summary>
    public class AddressViewModel : IViewModelable
    {
        /// <summary>
        /// The Id of the Address
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The Id of the corresponding Customer
        /// </summary>
        public int? CustomerId { get; set; }
        [Required(ErrorMessage = "Enter the street name")]
        public string? Street { get; set; }
        [DisplayName("House Number")]
        [Required(ErrorMessage = "Enter the house number")]
        public int? HouseNumber { get; set; }
        [DisplayName("Registry Number")]
        [Required(ErrorMessage = "Enter the registry number")]
        public int? RegistryNumber { get; set; }
        [Required(ErrorMessage = "Enter the city name")]
        public string? City { get; set; }

        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public AddressViewModel() { }
        /// <summary>
        /// Constructor using the Address Id and the CustomerId
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customerId"></param>
        public AddressViewModel(int id, int customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
