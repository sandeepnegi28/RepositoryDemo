using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModelDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }

        //[Required, MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        [Display(Name = "Office Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        //[RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$")]

        //[EmailAddress]
        [Required]
        public string Email { get; set; }
        //public string Department { get; set; }

            [Required]
        public Dept ?Department { get; set; }
    }
}
//Built in Validation Attributes
//1. Regular Expression
//2. Required
//3. Range
//4. MinLength
//5. MaxLength
//6.Compare
