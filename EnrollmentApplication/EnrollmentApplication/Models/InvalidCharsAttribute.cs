using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnrollmentApplication.Models
{
    public class InvalidCharsAttribute : ValidationAttribute
    {
        readonly string invalidChars;

        public InvalidCharsAttribute(string invalidChars) : base("Notes contains unacceptable characters!")
        {
            this.invalidChars = invalidChars;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                for(int i = 0; i < value.ToString().Length; i++)
                {
                    for(int j = 0; j < invalidChars.Length; j++)
                    {
                        if(value.ToString().Substring(i, 1) == invalidChars.Substring(j, 1))
                        {
                            var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                            return new ValidationResult(errorMessage);
                        }
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}