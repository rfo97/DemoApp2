using DemoApp2.Data;
using DemoApp2.Models;
using DemoApp2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DemoApp2.Controllers
{
    public class EmployeesController : Controller
    {
        #region Employees

        private AppDbContext db;
        public EmployeesController(AppDbContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {

            if (db.Departments.Count() > 0)
            {
                ViewBag.Deleted = db.Employees.Where(x => x.IsDeleted == true).Count();
                return View(db.Employees.Where(x => x.IsDeleted == false)
                    .Include(m => m.Department)
                    .OrderByDescending(m => m.HDate));
            }
            return RedirectToAction("Index", "Departments");
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.allDepts = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {

                employee.IsActive = true;
                // Save Data
                db.Employees.Add(employee);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            ViewBag.allDepts = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
            return View(employee);


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
                string fName, lName;
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
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var data = db.Employees.Find(id);
            if (data == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(data);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(Employee employee)
        {
            var data = db.Employees.Find(employee.EmployeeId);
            if (data != null)
            {
                db.Employees.Remove(data);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));

        }

        public IActionResult SoftDelete(int? id)
        {

            var data = db.Employees.Find(id);
            if (data != null)
            {
                data.IsDeleted = true;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RestoreEmployees()
        {
            var data = db.Employees.Where(x => x.IsDeleted == true)
                           .OrderByDescending(m => m.HDate);
            if (data.Any())
            {
                return View(data);
            }
            return RedirectToAction(nameof(Index));

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

        #endregion

        #region Users
        [HttpGet]
        public IActionResult CreateUser()
        {

            return View();
        }
        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(user);


        }


        public IActionResult AllData()
        {
            UserEmployeeViewModel model = new UserEmployeeViewModel
            {
                Employees = db.Employees.ToList(),
                Users = db.Users.ToList()
            };
            ViewBag.depts = db.Departments;
            return View(model);
        }


        #endregion

        

    }
}
