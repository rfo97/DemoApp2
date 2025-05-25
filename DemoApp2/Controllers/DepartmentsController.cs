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
            db.Departments.Add(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
