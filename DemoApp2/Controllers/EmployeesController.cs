using DemoApp2.Data;
using DemoApp2.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp2.Controllers
{
    public class EmployeesController : Controller
    {
        private AppDbContext db;
        public EmployeesController(AppDbContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            return View(db.Employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee) 
        {
            employee.IsActive = true;
            // Save Data
            db.Employees.Add(employee);
            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int? id) 
        {
            if (id==null)
            {
                return RedirectToAction(nameof(Index));
            }
            var empData = db.Employees.Find(id);
            if (empData != null) 
            {
                return View(empData);

            }
            return RedirectToAction(nameof(Index));
        }
    }
}
