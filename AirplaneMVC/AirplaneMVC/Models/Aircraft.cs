using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirplaneMVC.Models
{
    public class Aircraft
    {
        [Key]
        public int AircraftID { get; set; }

        public int? Capacity { get; set; }
        public string Model { get; set; }

        [Required]
        public int AirlineID { get; set; }

        [ForeignKey("AirlineID")]
        [ValidateNever]
        public virtual Airline Airline { get; set; }

        // Navigation Properties
        [ValidateNever]
        public virtual ICollection<Assignment> Assignments { get; set; }
        [ValidateNever]
        public virtual ICollection<Crew> Crews { get; set; }
    }
}