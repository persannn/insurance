﻿using System.ComponentModel.DataAnnotations;

namespace Insurance_Two_Tables.Models
{
    public class InsuranceViewModel
    {
        public int? Id { get; set; }
        public int? CustomerId { get; set; }
        [Required(ErrorMessage = "Please fill in the type of insurance")]
        public string? InsuranceType { get; set; }
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
