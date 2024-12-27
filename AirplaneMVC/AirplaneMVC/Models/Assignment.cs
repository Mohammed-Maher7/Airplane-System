using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirplaneMVC.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentID { get; set; } // Primary key

        public int AircraftID { get; set; }

        public int RouteID { get; set; }

        public int? Passengers { get; set; }
        public decimal? PricePerPassenger { get; set; }
        public DateTime? DepartureDateTime { get; set; }
        public DateTime? ArrivalDateTime { get; set; }
        public TimeSpan? TravelTime { get; set; }

        [ForeignKey("AircraftID")]
        [ValidateNever]
        public virtual Aircraft Aircraft { get; set; }

        [ForeignKey("RouteID")]
        [ValidateNever]
        public virtual Route Route { get; set; }
    }
}