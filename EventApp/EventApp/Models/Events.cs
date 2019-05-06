using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventApp.Models
{
    public class Events
    {
        public virtual int EventsID { get; set; }
        [Required]
        [MaxLength(50)]
        public virtual string Title { get; set; }
        [MaxLength(150)]
        public virtual string Description { get; set; }
        [Required]
        public virtual string StartDate { get; set; }
        [Required]
        public virtual string StartTime { get; set; }
        [Required]
        public virtual string EndDate { get; set; }
        [Required]
        public virtual string EndTime { get; set; }
        [Required]
        public virtual string Location { get; set; }
        public virtual EventType Type { get; set; }
        [Required]
        public virtual string OrganizerName { get; set; }
        public virtual string OrganizerContact { get; set; }
        [Required]
        [Minimum(0)]
        public virtual int MaxTickets { get; set; }
        [Required]
        [Minimum(0)]
        public virtual int AvailableTickets { get; set; }
    }
}