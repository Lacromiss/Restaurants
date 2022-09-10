using Microsoft.AspNetCore.Mvc;
using Siuuuu.DAL;
using Siuuuu.Models.Adres;
using System.Collections.Generic;
using System.Linq;

namespace Siuuuu.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CustomerAdressController : Controller
    {
        private AppDbContext _context;

        public CustomerAdressController(AppDbContext context)
        {

            _context = context;
        }
        public IActionResult Index()
        {
            List<Adres> adres = _context.adres.ToList();
            return View(adres);
        }
    }
}
