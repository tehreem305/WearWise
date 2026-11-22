
using Microsoft.AspNetCore.Mvc;

namespace WearWise.Controllers
{
    public class ProductPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
