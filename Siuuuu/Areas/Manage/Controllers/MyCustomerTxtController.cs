using Microsoft.AspNetCore.Mvc;

namespace Siuuuu.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class MyCustomerTxtController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
