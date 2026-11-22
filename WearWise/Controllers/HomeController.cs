
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WearWise.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult UserHome()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminHome()
        {
            return View();
        }
    }
}
