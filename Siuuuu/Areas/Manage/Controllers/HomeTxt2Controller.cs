using Microsoft.AspNetCore.Mvc;
using Siuuuu.DAL;
using Siuuuu.Models.HomePage;
using System.Collections.Generic;
using System.Linq;

namespace Siuuuu.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class HomeTxt2Controller : Controller
    {
        private readonly AppDbContext _context;

        public HomeTxt2Controller(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<HomeTxt2> homeTxt2s = _context.homeTxt2s.ToList();
            return View(homeTxt2s);
        }

        public IActionResult Update(int Id)
        {
            HomeTxt2 homeTxt1 = _context.homeTxt2s.Find(Id);
            if (homeTxt1 == null)
            {
                return BadRequest();

            }
            return View(homeTxt1);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int Id, HomeTxt1 homeTxt1)
        {
            if (Id != homeTxt1.Id)
            {
                return BadRequest();
            }
            HomeTxt2 hometxtttt = _context.homeTxt2s.Find(Id);
            if (hometxtttt == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View();

            }


            hometxtttt.Title = homeTxt1.Title;
            hometxtttt.Description = homeTxt1.Description;
            hometxtttt.Description2 = homeTxt1.Description2;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
