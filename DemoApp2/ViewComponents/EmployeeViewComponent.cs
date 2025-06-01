using DemoApp2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApp2.ViewComponents
{
    public class EmployeeViewComponent : ViewComponent
    {
        private AppDbContext db;

        public EmployeeViewComponent(AppDbContext _db)
        {
            db = _db;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.Deleted = db.Employees.Where(x => x.IsDeleted == true).Count();
            return View(db.Employees.Where(x => x.IsDeleted == false)
                .Include(m => m.Department)
                .OrderByDescending(m => m.HDate));

        }
    }
}
