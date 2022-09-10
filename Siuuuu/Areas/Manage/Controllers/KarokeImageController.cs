using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RestorauntWebAppp.Utilites;
using Siuuuu.DAL;
using Siuuuu.Models.Karoke;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Siuuuu.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class KarokeImageController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public KarokeImageController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }
        public IActionResult Index()
        {
            List<KarokeImage> karokeImage = _context.karokeImages.ToList();


            return View(karokeImage);
        }

        public IActionResult Update(int Id)
        {
            KarokeImage a = _context.karokeImages.Find(Id);
            if (a == null)
            {
                return BadRequest();

            }

            return View(a);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(KarokeImage karokeImage, int Id)
        {
            KarokeImage a = _context.karokeImages.Find(Id);
            if (a == null)
            {
                return BadRequest();

            }


            if (karokeImage.Photo != null)
            {
                if (!(karokeImage.Photo.CheckSize(5)))
                {
                    ModelState.AddModelError("Photo", "5 mb limitinizi kecibsiz");
                    return View();


                }
                if (!(karokeImage.Photo.CheckType("image/")))
                {
                    ModelState.AddModelError("Photo", "img  formatinda bir seyler at");
                    return View();

                }
                ExImgMethods.DeleteFile(Path.Combine(_env.WebRootPath, "Pages", "image", a.ImgUrl));


                a.ImgUrl = await karokeImage.Photo.SaveFileAsync(Path.Combine(_env.WebRootPath, "Pages", "image"));


            }
            else
            {
                ModelState.AddModelError("Photo", "image elave etmelisen bos kecile bilmez");
                return View();
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
