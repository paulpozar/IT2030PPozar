using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventApp.Models
{
    public class MinimumAttribute : ValidationAttribute
    {
        readonly int minValue;

        public MinimumAttribute(int min) : base("This value cannot be below the minimum value.")
        {
            minValue = min;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if ((int)value < minValue)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}