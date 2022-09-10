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
    public class HomeMainImageController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public HomeMainImageController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }

        public IActionResult Index()
        {
            List<HomeMainImage> images = _context.homeMainImages.ToList();
            return View(images);
        }



        public IActionResult Update(int Id)
        {

            HomeMainImage homeMainImage = _context.homeMainImages.Find(Id);


            if (homeMainImage == null)
            {
                return BadRequest();

            }

            return View(homeMainImage);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int Id, HomeMainImage homeMainImage)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }

            if (Id != homeMainImage.Id)
            {
                return BadRequest();
            }
            HomeMainImage homeMainImage1 = _context.homeMainImages.Find(Id);
            if (homeMainImage1 == null)
            {
                return NotFound();
            }



            if (homeMainImage.Photo1 != null)
            {
                if (!(homeMainImage.Photo1.CheckSize(5)))
                {
                    ModelState.AddModelError("Photo1", "5 mb limitinizi kecibsiz");
                    return View();


                }
                if (!(homeMainImage.Photo1.CheckType("image/")))
                {
                    ModelState.AddModelError("Photo1", "img  formatinda bir seyler at");
                    return View();

                }
                string suloysu = Path.Combine(_env.WebRootPath, "Pages", "image", homeMainImage1.ImgUrl1);
                if (System.IO.File.Exists(suloysu))
                {
                    System.IO.File.Delete(suloysu);

                }

                homeMainImage1.ImgUrl1 = await homeMainImage.Photo1.SaveFileAsync(Path.Combine(_env.WebRootPath, "Pages", "image"));


            }
            else
            {
                ModelState.AddModelError("Photo1", "image elave etmelisen bos kecile bilmez");
                return View();
            }




            if (homeMainImage.Photo2 != null)
            {
                if (!(homeMainImage.Photo2.CheckSize(5)))
                {
                    ModelState.AddModelError("Photo2", "5 mb limitinizi kecibsiz");
                    return View();


                }
                if (!(homeMainImage.Photo2.CheckType("image/")))
                {
                    ModelState.AddModelError("Photo2", "img  formatinda bir seyler at");
                    return View();

                }
                string suloysu = Path.Combine(_env.WebRootPath, "Pages", "image", homeMainImage1.ImgUrl2);
                if (System.IO.File.Exists(suloysu))
                {
                    System.IO.File.Delete(suloysu);

                }

                homeMainImage1.ImgUrl2 = await homeMainImage.Photo2.SaveFileAsync(Path.Combine(_env.WebRootPath, "Pages", "image"));


            }
            else
            {
                ModelState.AddModelError("Photo2", "image elave etmelisen bos kecile bilmez");
                return View();
            }
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
