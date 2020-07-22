using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoginSignupApp.DbContextFactory
{
    [Table("User")]
    public class User
    {
        [Key]
        public Int64 Id { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }
        
        public string ConfirmPassword { get; set; }
        
        public string Phone { get; set; }
    }
}