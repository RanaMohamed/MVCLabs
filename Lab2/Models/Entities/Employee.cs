using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab2.Models.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        public double Salary { get; set; }

        public string Address { get; set; }

        [Required]
        public Gender Gender { get; set; }


    }
}