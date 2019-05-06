using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventApp.Models
{
    public class EventType
    {
        public virtual int EventTypeID { get; set; }
        public virtual string Type { get; set; }
    }
}