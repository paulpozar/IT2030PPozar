using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnrollmentApplication.Models
{
    public class Student
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
    }
}