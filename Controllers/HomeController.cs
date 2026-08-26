using KweziHealth_Systems_Enterprise_Staff_Operations_Platform.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KweziHealth_Systems_Enterprise_Staff_Operations_Platform.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
