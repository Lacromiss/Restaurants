using Microsoft.AspNetCore.Mvc;
using Siuuuu.DAL;
using Siuuuu.Vm;
using System.Linq;

namespace Siuuuu.Controllers
{
    public class KarokeController : Controller
    {
        private AppDbContext _context;

        public KarokeController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            KarokePageVm karokePageVm = new KarokePageVm
            {
                karokeRezerevation = _context.karokeRezerevations.ToList(),
                karokeImage = _context.karokeImages.ToList(),
                karokeConcept = _context.concepts.ToList(),
                karokeInformation = _context.informations.ToList(),
                karokeQuestion = _context.karokeQuestions.ToList(),
            };
            return View(karokePageVm);
        }
    }
}
