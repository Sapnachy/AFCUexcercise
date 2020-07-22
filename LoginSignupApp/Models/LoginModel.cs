using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginSignupApp.Models
{
    public class LoginModel
    {
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is invalid!")]
        [Display(Name = "Email*")]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password, ErrorMessage = "Password is invalid!")]
        [Display(Name = "Password*")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Invalid Password!")]
        [Required]
        public string Password { get; set; }
    }
}