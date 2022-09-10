using Microsoft.AspNetCore.Mvc;
using Siuuuu.DAL;
using Siuuuu.Vm;
using System.Linq;

namespace Siuuuu.Controllers
{
    public class InterestingController : Controller
    {
        private AppDbContext _context;

        public InterestingController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            WhoPageVm whoPageVm = new WhoPageVm
            {
                curiorDescription1s = _context.curiorDescriptions.ToList(),
                curiorDescription2s = _context.curiorDescription2s.ToList(),
                curiorDescription3s = _context.curiorDescription3s.ToList(),
                curiorDescription4s = _context.curiorDescription4s.ToList(),
                curiors = _context.curiors.ToList(),
                curiorOnes = _context.curiorOnes.ToList(),
                curiorTwos = _context.curiorTwos.ToList(),
                curiorThree = _context.curiorThree.ToList(),
                
            };
            return View(whoPageVm);
        }
    }
}
