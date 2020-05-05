using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab3.Models
{
    public class Employee
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(12)]
        public string Password { get; set; }

        [Required]
        [Range(5000, 50000)]
        public double Salary { get; set; }

        [MaxLength(256)]
        public string Address { get; set; }

        [Required]
        public Gender? Gender { get; set; }


    }
}