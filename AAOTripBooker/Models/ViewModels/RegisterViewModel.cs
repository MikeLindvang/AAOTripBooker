using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace AAOTripBooker.Models.ViewModels
{
    public enum Roles
    {
        Disponent, Chauffør
    }
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "{0} skal være på mindst {2} tegn.", MinimumLength = 6)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Bekræft dit password")]
        [Compare("Password", ErrorMessage = "Matcher ikke dit password")]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name = "Rolle")]
        public Roles Roles { get; set; }

    }
}
