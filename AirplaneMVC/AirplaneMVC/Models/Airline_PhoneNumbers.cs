using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirplaneMVC.Models
{
    public class Airline_PhoneNumbers
    {
        [Key]
        public int PhoneNumberID { get; set; } // Primary key

        [Required]
        public string Phone { get; set; }

        // Foreign Key
        public int AirlineID { get; set; }

        [ForeignKey("AirlineID")]
        [ValidateNever]
        public virtual Airline Airline { get; set; }
    }
}