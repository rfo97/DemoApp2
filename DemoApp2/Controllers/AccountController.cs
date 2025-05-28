using DemoApp2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoApp2.Controllers
{
    public class AccountController : Controller
    {

        private AppDbContext db;
        public AccountController(AppDbContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Roles = new SelectList(db.Role, "RoleId", "RoleName");
            return View();
        }


    }
}
