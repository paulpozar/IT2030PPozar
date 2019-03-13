using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnrollmentApplication.Models
{
    public class Course
    {
        [Display(Name="Course ID")]
        public virtual int CourseID { get; set; }

        [Required]
        [Display(Name="Course Title")]
        [StringLength(150)]
        public virtual string Title { get; set; }

        [Display(Name ="Description")]
        public virtual string Description { get; set; }

        [Required]
        [Display(Name ="Number of credits")]
        [Range(1,4)]
        public virtual int Credits { get; set; }
    }
}