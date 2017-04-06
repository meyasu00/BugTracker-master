using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public enum TicketPriority
    {
        [Display(Name = "Low")]
        Low,
        [Display(Name = "Medium")]
        Medium,
        [Display(Name = "High")]
        High
    }
    public class Priority
    {
        public Priority()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}