using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebApplication3.Models;

namespace Identity.Models
{
    public class User
    {
        [Required]
        [RegularExpression(@"([A-Z'?a-z]-?){3,50}",
         ErrorMessage = "Characters are not allowed.")]
        public string Name { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*_?&])[A-Za-z\d@$!%*?_&]{8,}$",
         ErrorMessage = "Characters are not allowed.")]
        public string Password { get; set; }


    }
}
