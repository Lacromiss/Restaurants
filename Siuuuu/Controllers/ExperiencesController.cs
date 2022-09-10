using Microsoft.AspNetCore.Mvc;
using Siuuuu.DAL;
using Siuuuu.Vm;
using System.Linq;

namespace Siuuuu.Controllers
{
    
    public class ExperiencesController : Controller
    {
        private AppDbContext _context;

        public ExperiencesController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            PageCustomerVm page = new PageCustomerVm
            {
                customerJobAndCareers = _context.customerJobAndCareers.ToList(),
                customeHumen = _context.customeHumen.ToList(),

            };
            return View(page);
        }
    }
}
