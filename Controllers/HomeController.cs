using Microsoft.AspNetCore.Mvc;

namespace libraryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
