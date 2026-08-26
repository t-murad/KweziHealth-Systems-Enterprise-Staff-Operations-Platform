using Microsoft.AspNetCore.Mvc;
using KweziHealth_Systems_Enterprise_Staff_Operations_Platform.Models;
using KweziHealth_Systems_Enterprise_Staff_Operations_Platform.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KweziHealth_Systems_Enterprise_Staff_Operations_Platform.Controllers
{
    public class StaffController : Controller
    {
        private readonly StaffService _staffService;

        public StaffController(StaffService staffService)
        {
            _staffService = staffService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var isAdminLoggedIn = HttpContext.Session.GetString("IsAdminLoggedIn");

            if (isAdminLoggedIn != "true")
            {
                context.Result = RedirectToAction("Login", "Access");
                return;
            }

            base.OnActionExecuting(context);
        }

        //listing staff members
        [HttpGet]
        public IActionResult Index()
        {
            var staffMembers = _staffService.GetAllStaff();

            return View(staffMembers);
        }

        //Creating staff members
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StaffMember staffMember)
        {
            if (!ModelState.IsValid)
            {
                return View(staffMember);
            }

            _staffService.AddStaff(staffMember);

            return RedirectToAction(nameof(Index));
        }

        //Edit Staff members
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var staffMember = _staffService.GetStaffById(id);

            if (staffMember == null)
            {
                return NotFound();
            }

            return View (staffMember);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StaffMember staffMember)
        {
            if (!ModelState.IsValid)
            {
                return View(staffMember);
            }

            var updated = _staffService.UpdateStaff(staffMember);

            if (!updated)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        //Delete Staff member
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var staffMember = _staffService.GetStaffById(id);

            if (staffMember == null)
            {
                return NotFound();
            }

            return View(staffMember);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var deleted = _staffService.DeleteStaff(id);

            if (!deleted)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
