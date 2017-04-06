using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public enum TicketStatus
    {
        [Display(Name = "Open")]
        Open,
        [Display(Name = "Pending")]
        Pending,
        [Display(Name = "Resolved")]
        Resolved,
        [Display(Name = "Closed")]
        Closed
    }
    public class Status
    {
        public Status()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}