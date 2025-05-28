using System.ComponentModel.DataAnnotations;

namespace DemoApp2.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required(ErrorMessage ="Enter Department Name")]
        [Display(Name = "Department Name")]
        [MinLength(3,ErrorMessage ="Min 3 Char")]
        [MaxLength(10,ErrorMessage ="Max 10 Char")]
        public string DepartmentName { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [Display(Name = "Deleted")]
        public bool IsDeleted { get; set; }


    }
}
