using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garlic_WebClient.Models
{
    public class RegisterModel
    {

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

    }
}