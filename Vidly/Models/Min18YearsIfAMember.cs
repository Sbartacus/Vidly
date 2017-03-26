using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.BirthDate == null)
            {
                return new ValidationResult("BirthDate is required");
            }

            var age = DateTime.Today.Year - ((DateTimeOffset)customer.BirthDate).DateTime.Year;
            return age < 18 ? 
                new ValidationResult("You must be at least 18 to go to membership.") : 
                ValidationResult.Success;
        }
    }
}