using Microsoft.AspNetCore.Mvc;
using Siuuuu.DAL;
using Siuuuu.Models.Karoke;
using System.Collections.Generic;
using System.Linq;

namespace Siuuuu.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class KarokeConceptController : Controller
    {
        private readonly AppDbContext _context;

        public KarokeConceptController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<KarokeConcept> konsept = _context.concepts.ToList();
            return View(konsept);
        }

        public IActionResult Update(int Id)
        {
            KarokeConcept konsept = _context.concepts.Find(Id);
            if (konsept == null)
            {
                return BadRequest();

            }
            return View(konsept);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int Id, KarokeConcept konsept)
        {
            KarokeConcept konsept1 = _context.concepts.Find(Id);
            if (konsept1 == null)
            {
                return NotFound();
            }
            if (Id != konsept1.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View();

            }
            konsept1.Title = konsept.Title;
            konsept1.Subtitle = konsept.Subtitle;
            konsept1.Description1 = konsept.Description1;
            konsept1.Description2 = konsept.Description2;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
