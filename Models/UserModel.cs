using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyFirstApp.Models
{
    public class UserModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "\"{0}\" muss mind. {2} Zeichen lang sein.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "\"{0}\" muss mind. {2} Zeichen lang sein.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Kennwort")]
        public string Password { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name = "Kennwort bestätigen")]
        [Compare("Password", ErrorMessage = "Das Kennwort entspricht nicht dem Bestätigungskennwort.")]
        [Required(ErrorMessage = "Confirm Password required")]
        public string ConfirmPassword { get; set; }

    }
}