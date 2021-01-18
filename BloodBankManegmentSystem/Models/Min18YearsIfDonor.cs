using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BloodBankManegmentSystem.Models
{
    public class Min18YearsIfDonor: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var donor = (Donors)validationContext.ObjectInstance;

            if (donor.age == null)
                return new ValidationResult("Birthdate is required.");

            var age = donor.age;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Donor should be at least 18 years old to go on a membership.");
        }
    }
}