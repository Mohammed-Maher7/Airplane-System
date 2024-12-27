using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirplaneMVC.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public char? Gender { get; set; }
        public string Position { get; set; }

        [Required]
        public int AirlineID { get; set; }

        [ForeignKey("AirlineID")]
        [ValidateNever]
        public virtual Airline Airline { get; set; }

        // Navigation Properties
        [ValidateNever]
        public virtual ICollection<Employee_Qualifications> EmployeeQualifications { get; set; }
    }
}