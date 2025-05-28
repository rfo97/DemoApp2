using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApp2.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Plz Enter Employee Name")]
        [MaxLength(50, ErrorMessage = "Max 50")]
        //[StringLength (50,MinimumLength =1,ErrorMessage ="Min 1 Char , max 50")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "ex: ahmad@gmail.com")]
        [Required(ErrorMessage = "Enter Email Address")]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime HDate { get; set; }
        [Range(700,15000,ErrorMessage ="Salary between 700 - 15000")]
        public decimal Salary { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

    }
}
