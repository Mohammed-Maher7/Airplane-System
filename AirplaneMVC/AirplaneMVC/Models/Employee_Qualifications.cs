using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirplaneMVC.Models
{
    public class Employee_Qualifications
    {
        [Key, Column(Order = 0)]
        [ValidateNever]
        public int QualificationID { get; set; } // Primary key

        [Required]
        public string Skill { get; set; }

        // Foreign Key
        public int EmployeeID { get; set; }

        [ForeignKey("EmployeeID")]
        [ValidateNever]
        public virtual Employee Employee { get; set; }
    }
}