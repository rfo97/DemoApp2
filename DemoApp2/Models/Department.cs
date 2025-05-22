namespace DemoApp2.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
