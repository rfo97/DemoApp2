using DemoApp2.Data;
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
    }
}
