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
    public class HomeImageTwoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public HomeImageTwoController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }

        public IActionResult Index()
        {
            List<HomeImageTwo> HomeImageTwo = _context.homeImageTwos.ToList();
            return View(HomeImageTwo);
        }

        public IActionResult Update(int Id)
        {

            HomeImageTwo HomeImageTwo = _context.homeImageTwos.Find(Id);


            if (HomeImageTwo == null)
            {
                return BadRequest();

            }

            return View(HomeImageTwo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int Id, HomeImageTwo HomeImageTwo)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }

            if (Id != HomeImageTwo.Id)
            {
                return BadRequest();
            }
            HomeImageTwo HomeImageTwo1 = _context.homeImageTwos.Find(Id);
            if (HomeImageTwo1 == null)
            {
                return NotFound();
            }



            if (HomeImageTwo.Photo != null)
            {
                if (!(HomeImageTwo.Photo.CheckSize(5)))
                {
                    ModelState.AddModelError("Photo", "5 mb limitinizi kecibsiz");
                    return View();


                }
                if (!(HomeImageTwo.Photo.CheckType("image/")))
                {
                    ModelState.AddModelError("Photo", "img  formatinda bir seyler at");
                    return View();

                }
                string suloysu = Path.Combine(_env.WebRootPath, "Pages", "image", HomeImageTwo1.ImgUrl);
                if (System.IO.File.Exists(suloysu))
                {
                    System.IO.File.Delete(suloysu);

                }

                HomeImageTwo1.ImgUrl = await HomeImageTwo.Photo.SaveFileAsync(Path.Combine(_env.WebRootPath, "Pages", "image"));


            }
            else
            {
                ModelState.AddModelError("Photo", "image elave etmelisen bos kecile bilmez");
                return View();
            }
            HomeImageTwo1.Txt = HomeImageTwo.Txt;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
