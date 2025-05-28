using System.ComponentModel.DataAnnotations;

namespace DemoApp2.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        [Required(ErrorMessage ="Enter Role Name")]
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
    }
}
