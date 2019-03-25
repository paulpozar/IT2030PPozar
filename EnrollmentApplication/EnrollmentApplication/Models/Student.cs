using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnrollmentApplication.Models
{
    public class Student : IValidatableObject
    {
        [Display(Name="Student ID")]
        public virtual int StudentID { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public virtual string LastName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public virtual string FirstName { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string State { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Address1 != null && Address2 != null && Address2.ToLower() == Address1.ToLower())
            {
                yield return (new ValidationResult("Address 2 cannot be the same as Address 1."));
            }
            if(State != null && State.Length != 2)
            {
                yield return (new ValidationResult("Enter a 2 digit State code."));
            }
            if(Zipcode != null && Zipcode.Length != 5)
            {
                yield return (new ValidationResult("Enter a 5 digit Zipcode."));
            }
        }
    }
}