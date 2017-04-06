using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public enum TicketType
    {
        [Display(Name = "Bug")]
        Bug,
        [Display(Name = "Feature Request")]
        Request,
        [Display(Name = "Documentation")]
        Documentation,
    }
        
    public class Type
    {
        public Type()
        {
        }
        public int Id { get; set; }

        public string Name { get; set; }
    }
}