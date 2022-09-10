using Microsoft.AspNetCore.Mvc;
using Siuuuu.DAL;
using Siuuuu.Models.HomePage;
using System.Collections.Generic;
using System.Linq;

namespace Siuuuu.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class PageHomeManifestController : Controller
    {
        private readonly AppDbContext _context;

        public PageHomeManifestController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<HomeDescriptionOne> curior = _context.homeDescriptionOnes.ToList();
            return View(curior);
        }

        public IActionResult Update(int Id)
        {
            HomeDescriptionOne home = _context.homeDescriptionOnes.Find(Id);
            if (home == null)
            {
                return BadRequest();

            }
            return View(home);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int Id, HomeDescriptionOne home)
        {
            if (Id != home.Id)
            {
                return BadRequest();
            }
            HomeDescriptionOne home1 = _context.homeDescriptionOnes.Find(Id);
            if (home1 == null)
            {
                return NotFound();
            }


            if (!ModelState.IsValid)
            {
                return View();

            }
            home1.Title = home.Title;
            home1.Description = home.Description;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
