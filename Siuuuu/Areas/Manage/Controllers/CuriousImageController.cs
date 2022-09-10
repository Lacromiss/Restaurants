using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RestorauntWebAppp.Utilites;
using Siuuuu.DAL;
using Siuuuu.Models.Curious;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Siuuuu.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CuriousImageController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CuriousImageController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }

        public IActionResult Index()
        {
            List<Curior> curior = _context.curiors.ToList();
            return View(curior);
        }


        public IActionResult Update(int Id)
        {

            Curior curior = _context.curiors.Find(Id);


            if (curior == null)
            {
                return BadRequest();

            }

            return View(curior);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int Id, Curior curior)
        {
            if (Id != curior.Id)
            {
                return BadRequest();
            }
            Curior curior1 = _context.curiors.Find(Id);
            if (curior1 == null)
            {
                return NotFound();
            }


            if (!ModelState.IsValid)
            {
                return View();

            }
            if (curior.Photo != null)
            {
                if (!(curior.Photo.CheckSize(5)))
                {
                    ModelState.AddModelError("Photo", "5 mb limitinizi kecibsiz");
                    return View();


                }
                if (!(curior.Photo.CheckType("image/")))
                {
                    ModelState.AddModelError("Photo", "img  formatinda bir seyler at");
                    return View();

                }
                ExImgMethods.DeleteFile(Path.Combine(_env.WebRootPath, "Pages", "image" ,curior1.ImgUrl));


                curior1.ImgUrl = await curior.Photo.SaveFileAsync(Path.Combine(_env.WebRootPath, "Pages", "image"));


            }
            else
            {
                ModelState.AddModelError("Photo", "image elave etmelisen bos kecile bilmez");
                return View();
            }
            curior1.Txt = curior.Txt;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int Id)
        {
            Curior Curior = _context.curiors.Find(Id);
            if (Curior == null)
            {
                return BadRequest();

            }
            ExImgMethods.DeleteFile(Path.Combine(_env.WebRootPath, "Pages", "image", Curior.ImgUrl));

            _context.curiors.Remove(Curior);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
