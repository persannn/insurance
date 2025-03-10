﻿using Insurance_Final_Version.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Insurance_Final_Version.Models
{
    public class InsuranceViewModel : IViewModelable
    {
        public int Id { get; set; }

        public int? CustomerId { get; set; }

        [DisplayName("Type of insurance")]
        [Required(ErrorMessage = "Please fill in the type of insurance")]
        public string? InsuranceType { get; set; }

        [DisplayName("Value of insurance")]
        [Required(ErrorMessage = "Please fill in the value of the insurance")]
        [Range(100, 10000000, ErrorMessage = "Insurance value must be between 100 and 10 000 000 CZK")]
        public int? InsuranceValue { get; set; }

        public InsuranceViewModel() { }

        public InsuranceViewModel(int id, int customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
