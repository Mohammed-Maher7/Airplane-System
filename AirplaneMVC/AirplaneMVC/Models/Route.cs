using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirplaneMVC.Models
{
    public class Route
    {
        [Key]
        public int RouteID { get; set; }

        [Required]
        public string Origin { get; set; }

        [Required]
        public string Destination { get; set; }

        public float? Distance { get; set; }
        public string Classification { get; set; }

        // Navigation Properties
        [ValidateNever]
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}