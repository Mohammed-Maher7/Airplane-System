using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirplaneMVC.Models
{
    public class Airline
    {
        [Key]
        public int AirlineID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }
        public string ContactName { get; set; }

        // Navigation Properties
        [ValidateNever]
        public virtual ICollection<Airline_PhoneNumbers> PhoneNumbers { get; set; }
        [ValidateNever]
        public virtual ICollection<Employee> Employees { get; set; }
        [ValidateNever]
        public virtual ICollection<Aircraft> Aircrafts { get; set; }
        [ValidateNever]
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}