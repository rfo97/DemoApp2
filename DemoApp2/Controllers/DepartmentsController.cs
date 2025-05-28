using DemoApp2.Data;
using DemoApp2.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp2.Controllers
{
    public class DepartmentsController : Controller
    {

        private AppDbContext db;
        public DepartmentsController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View(db.Departments.OrderByDescending(x => x.DepartmentId));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                if (!DepartmentEx(department.DepartmentName))
                {
                    db.Departments.Add(department);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("DepartmentName", "Exist");
                return View(department);


            }
            return View(department);

        }

        public bool DepartmentEx(string deptName)
        {
            if (db.Departments.Where(x => x.DepartmentName == deptName).Any())
            {
                return true;
            }
            return false;
        }
    }
}
