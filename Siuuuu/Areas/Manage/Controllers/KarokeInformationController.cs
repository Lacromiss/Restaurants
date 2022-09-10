using Microsoft.AspNetCore.Mvc;
using Siuuuu.DAL;
using Siuuuu.Models.Karoke;
using System.Collections.Generic;
using System.Linq;

namespace Siuuuu.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class KarokeInformationController : Controller
    {
        private readonly AppDbContext _context;

        public KarokeInformationController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            List<KarokeInformation> karoke = _context.informations.ToList();
            return View(karoke);
        }

        public IActionResult Update(int Id)
        {
            KarokeInformation karokeInformation = _context.informations.Find(Id);
            if (karokeInformation == null)
            {
                return BadRequest();

            }
            return View(karokeInformation);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int Id, KarokeInformation karoke)
        {
            KarokeInformation karokeInformation = _context.informations.Find(Id);
            if (karokeInformation == null)
            {
                return NotFound();
            }
            if (Id != karokeInformation.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View();

            }
            karokeInformation.Title = karoke.Title;
            karokeInformation.Description1 = karoke.Description1;
            karokeInformation.Description2 = karoke.Description2;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
