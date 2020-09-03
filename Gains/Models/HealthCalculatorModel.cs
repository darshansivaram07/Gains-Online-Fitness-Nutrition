using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gains.Models
{
    
    public class HealthCalculatorModel
    {
       
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Alphabets Only!!!")]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [Range(2, 100, ErrorMessage = "Age must be between 2 and 100")]
        public int Age { get; set; }

        [Required]
        public string Unit { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Enter a value greater than zero")]
        public double Height { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Enter a value greater than zero")]

        public double Weight { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Enter a value greater than zero")]

        public double Waist { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Enter a value greater than zero")]

        public double Hip { get; set; }

    }
}