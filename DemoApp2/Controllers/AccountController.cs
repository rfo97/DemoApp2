using DemoApp2.Data;
using DemoApp2.Models;
using DemoApp2.Models.ViewModels;
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

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Email = model.Email,
                    City = "Kuwait",
                    Gender = model.Gender,
                    RoleId = model.RoleId,
                    Password = model.Password,
                    UserName = model.UserName,
                    IsActive = model.IsActive
                };
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            ViewBag.Roles = new SelectList(db.Role, "RoleId", "RoleName");
            return View(model);

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                var chkUser = db.Users.Where
                    (x => x.UserName == model.UserName && x.Password == model.Password);

                if (chkUser.Any()) 
                {
                    if (chkUser.First().RoleId==1)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Administrator" });

                    }
                    return RedirectToAction("Index", "Home", new { area = "User" });

                }

                return View(model);
            }
            return View(model);
        }
    }
}
