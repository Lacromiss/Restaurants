using Microsoft.AspNetCore.Mvc;
using Siuuuu.DAL;
using Siuuuu.Models.Karoke;
using System.Collections.Generic;
using System.Linq;

namespace Siuuuu.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class KarokeRezervationController : Controller
    {

        private readonly AppDbContext _context;

        public KarokeRezervationController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<KarokeRezerevation> rezerv = _context.karokeRezerevations.ToList();
            return View(rezerv);
        }

        public IActionResult Update(int Id)
        {
            KarokeRezerevation rezerevation = _context.karokeRezerevations.Find(Id);
            if (rezerevation == null)
            {
                return BadRequest();

            }
            return View(rezerevation);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int Id, KarokeRezerevation rezerevation)
        {
            KarokeRezerevation rezerevation1 = _context.karokeRezerevations.Find(Id);
            if (rezerevation1 == null)
            {
                return NotFound();
            }
            if (Id != rezerevation1.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View();

            }
            rezerevation1.Title = rezerevation.Title;
            rezerevation1.Description = rezerevation.Description;
            rezerevation1.Link = rezerevation.Link;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
