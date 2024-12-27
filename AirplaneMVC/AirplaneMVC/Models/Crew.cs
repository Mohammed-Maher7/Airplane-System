using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirplaneMVC.Models
{
    public class Crew
    {
        [Key]
        public int CrewID { get; set; }

        public string MajorPilot { get; set; }
        public string AssistantPilot { get; set; }
        public string Hostess1 { get; set; }
        public string Hostess2 { get; set; }

        public int AircraftID { get; set; }

        [ForeignKey("AircraftID")]
        [ValidateNever]
        public virtual Aircraft Aircraft { get; set; }
    }
}