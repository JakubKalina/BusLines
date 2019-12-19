using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logic.ViewModels.Account
{
    public class UserLoginViewModel
    {
        [Required]
        [Display(Name = "Login")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }
}
