using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirplaneMVC.Models
{
    public class Transactions
    {
        [Key]
        public int TransactionID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string Description { get; set; }

        public decimal? Amount { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; } // Should be 'Buy' or 'Sell'

        [Required]
        public int AirlineID { get; set; }

        [ForeignKey("AirlineID")]
        [ValidateNever]
        public virtual Airline Airline { get; set; }
    }
}