using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace S3Q1.Models
{
    [Table("Student")]
    public class studentmodel
    {
        [Key]
        public long Id { get; set; }
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Invalid Format")]
        [Required(ErrorMessage = "You Cannot leave this feild empty")]
      
        public string Name { get; set; }
        [Required(ErrorMessage = "enter age")]

        [Range(3, 450, ErrorMessage = "Age must be between 1-1400 in years.")]
        public int Age { get; set; }

    }
}