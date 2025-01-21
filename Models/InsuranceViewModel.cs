using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Insurance_Final_Version.Models
{
    public class InsuranceViewModel
    {
        public int? Id { get; set; }
        public int? CustomerId { get; set; }
        [DisplayName("Type of insurance")]
        [Required(ErrorMessage = "Please fill in the type of insurance")]
        public string? InsuranceType { get; set; }
        [DisplayName("Value of insurance")]
        [Required(ErrorMessage = "Please fill in the value of the insurance")]
        public int? InsuranceValue { get; set; }

        public InsuranceViewModel() { }
        public InsuranceViewModel(int? id, int? customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
