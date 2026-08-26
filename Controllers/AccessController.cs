using Microsoft.AspNetCore.Mvc;
using KweziHealth_Systems_Enterprise_Staff_Operations_Platform.Models;

namespace KweziHealth_Systems_Enterprise_Staff_Operations_Platform.Controllers
{
    public class AccessController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(SystemAdmin admin)
        {
            if (admin.Username == "admin" && admin.Password == "abc123")
            {
                HttpContext.Session.SetString("IsAdminLoggedIn", "true");

                return RedirectToAction("Index", "Staff");
            }

            ViewBag.Error = "Invalid usernameor password.";

            return View(admin);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }

    }
}
