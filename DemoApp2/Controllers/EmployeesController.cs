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
            return View(db.Employees.Where(x => x.IsDeleted == false)
                .OrderByDescending(m => m.HDate));
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
            if (id == null)
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
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
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
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            db.Employees.Update(employee);
            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int? id) {
            if (id ==null)
            {
                return RedirectToAction(nameof(Index));
            }
            var data=db.Employees.Find(id);
            if (data==null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(data);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(Employee employee) 
        {
            var data = db.Employees.Find(employee.EmployeeId);
            if (data!=null)
            {
                db.Employees.Remove(data);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        
        }

        public IActionResult SoftDelete(int? id) 
        {
            
            var data= db.Employees.Find(id);
            if (data != null) {
                data.IsDeleted = true;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RestoreEmployees()
        {
            return View(db.Employees.Where(x => x.IsDeleted == true)
                           .OrderByDescending(m => m.HDate));
        }

        public IActionResult ConfirmRestore(int? id) 
        {
            var data = db.Employees.Find(id);
            if (data != null)
            {
                data.IsDeleted = false;
                db.SaveChanges();
                return RedirectToAction(nameof(RestoreEmployees));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
