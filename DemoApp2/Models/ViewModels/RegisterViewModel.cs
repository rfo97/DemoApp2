using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DemoApp2.Models.User;

namespace DemoApp2.Models.ViewModels
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Enter User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Min 6 Char")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "password and confirm not match")]
        public string ConfirmPassword { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Compare("Email", ErrorMessage = "Email and confirm Email not match")]
        [EmailAddress]
        [Required]
        public string ConfirmEmail { get; set; }

        public Genders Gender { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
