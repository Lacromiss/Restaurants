using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RestorauntWebAppp.Utilites;
using Siuuuu.DAL;
using Siuuuu.Models.HomePage;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Siuuuu.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class HomeImageOneController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public HomeImageOneController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }

        public IActionResult Index()
        {
            List<HomeImageOne> homeImageOne = _context.homeImageOnes.ToList();
            return View(homeImageOne);
        }

        public IActionResult Update(int Id)
        {

            HomeImageOne homeImageOne = _context.homeImageOnes.Find(Id);


            if (homeImageOne == null)
            {
                return BadRequest();

            }

            return View(homeImageOne);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int Id, HomeImageOne homeImageOne)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }

            if (Id != homeImageOne.Id)
            {
                return BadRequest();
            }
            HomeImageOne homeImageOne1 = _context.homeImageOnes.Find(Id);
            if (homeImageOne1 == null)
            {
                return NotFound();
            }



            if (homeImageOne.Photo != null)
            {
                if (!(homeImageOne.Photo.CheckSize(5)))
                {
                    ModelState.AddModelError("Photo", "5 mb  limitinizi kecibsiz");
                    return View();


                }
                if (!(homeImageOne.Photo.CheckType("image/")))
                {
                    ModelState.AddModelError("Photo", "img  formatinda bir seyler at");
                    return View();

                }
                string suloysu = Path.Combine(_env.WebRootPath, "Pages", "image", homeImageOne1.ImgUrl);
                if (System.IO.File.Exists(suloysu))
                {
                    System.IO.File.Delete(suloysu);

                }

                homeImageOne1.ImgUrl = await homeImageOne.Photo.SaveFileAsync(Path.Combine(_env.WebRootPath, "Pages", "image"));


            }
            else
            {
                ModelState.AddModelError("Photo", "image elave etmelisen bos kecile bilmez");
                return View();
            }
            homeImageOne1.Txt = homeImageOne.Txt;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
