using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EjadaCompany.Model
{
    public class Employee
    {
        [Key]   // This is an attribute that specify ID as primary key, 
                // So no need to specify it yourself, it will be automatically generated
        public int Id { get; set; }

        [Required] // This means that attribute can't be empty and should be entered by user
        public string Name { get; set; }

      
        [Required]
        public string Team { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string Branch { get; set; }
        
        // Add Email Constraints to BackEnd
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public string Telphone { get; set; }

        public string Address { get; set; }

    }
}
