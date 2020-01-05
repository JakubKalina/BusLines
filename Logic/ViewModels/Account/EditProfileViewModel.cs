using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logic.ViewModels.Account
{
    public class EditProfileViewModel
    {
        [Required]
        [StringLength(255)]
        [Display(Name = "Imię")]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }

        [Required]
        [StringLength(11)]
        [Display(Name = "Numer telefonu")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Adres email")]
        public string EmailAddress { get; set; }
    }
}
