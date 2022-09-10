using Microsoft.AspNetCore.Mvc;

namespace Siuuuu.Areas.Manage.Controllers
{
    public class StellerController : Controller
    {
        [Area("Manage")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
