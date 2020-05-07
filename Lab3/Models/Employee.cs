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
        [ForeignKey("Department")]
        [Display(Name = "Department")]
        public int FK_DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        [Required]
        [EmailAddress]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(12)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Range(5000, 50000)]
        [DataType(DataType.Currency)]
        public double? Salary { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [MaxLength(256)]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required]
        public Gender? Gender { get; set; }


    }
}