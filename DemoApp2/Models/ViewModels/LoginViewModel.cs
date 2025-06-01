using System.ComponentModel.DataAnnotations;

namespace DemoApp2.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Min 6 Char")]
        public string Password { get; set; }
    }
}
