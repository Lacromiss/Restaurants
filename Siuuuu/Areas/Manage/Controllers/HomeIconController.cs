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
    public class HomeIconController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public HomeIconController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }

        public IActionResult Index()
        {
            List<HomeIcon> homeIcons = _context.homeIcons.ToList();
            return View(homeIcons);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HomeIcon homeIcons)
        {
            if (homeIcons.Photo != null)
            {
                if (!(homeIcons.Photo.CheckSize(5)))
                {
                    ModelState.AddModelError("Photo", "5 mb limitinizi kecibsiz");
                    return View();


                }
                if (!(homeIcons.Photo.CheckType("image/")))
                {
                    ModelState.AddModelError("Photo", "img  formatinda bir seyler at");
                    return View();

                }


                homeIcons.ImgUrl = await homeIcons.Photo.SaveFileAsync(Path.Combine(_env.WebRootPath, "Pages", "image"));


            }
            else
            {
                ModelState.AddModelError("Photo", "image elave etmelisen bos kecile bilmez");
                return View();
            }
            _context.homeIcons.Add(homeIcons);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Update(int Id)
        {

            HomeIcon homeIcons = _context.homeIcons.Find(Id);


            if (homeIcons == null)
            {
                return BadRequest();

            }

            return View(homeIcons);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int Id, HomeIcon homeIcons)
        {
            if (Id != homeIcons.Id)
            {
                return BadRequest();
            }
            HomeIcon homeIcons1 = _context.homeIcons.Find(Id);
            if (homeIcons1 == null)
            {
                return NotFound();
            }



            if (homeIcons.Photo != null)
            {
                if (!(homeIcons.Photo.CheckSize(5)))
                {
                    ModelState.AddModelError("Photo", "5 mb limitinizi kecibsiz");
                    return View();


                }
                if (!(homeIcons.Photo.CheckType("image/")))
                {
                    ModelState.AddModelError("Photo", "img  formatinda bir seyler at");
                    return View();

                }
                string suloysu = Path.Combine(_env.WebRootPath, "Pages", "image", homeIcons1.ImgUrl);
                if (System.IO.File.Exists(suloysu))
                {
                    System.IO.File.Delete(suloysu);

                }

                homeIcons1.ImgUrl = await homeIcons.Photo.SaveFileAsync(Path.Combine(_env.WebRootPath, "Pages", "image"));


            }
            else
            {
                ModelState.AddModelError("Photo", "image elave etmelisen bos kecile bilmez");
                return View();
            }
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int Id)
        {
            HomeIcon homeIcons = _context.homeIcons.Find(Id);
            if (homeIcons == null)
            {
                return BadRequest();

            }
            string suloysu = Path.Combine(_env.WebRootPath, "Pages", "image", homeIcons.ImgUrl);
            if (System.IO.File.Exists(suloysu))
            {
                System.IO.File.Delete(suloysu);

            }

            _context.homeIcons.Remove(homeIcons);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
