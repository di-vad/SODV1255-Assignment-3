using Microsoft.AspNetCore.Mvc;

namespace libraryManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "test" && password == "password")
            {
                return RedirectToAction("Dashboard");
            }
            ViewBag.Error = "Invalid credentials.";
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string email, string password)
        {
            
            return RedirectToAction("Login");
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
