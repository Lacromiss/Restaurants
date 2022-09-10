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
    public class CuriousThreeController : Controller
    {
        private AppDbContext _context;
        private IWebHostEnvironment _env;

        public CuriousThreeController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<CuriorTwo> curior = _context.curiorTwos.ToList();
            return View(curior);
        }


        public IActionResult Update(int Id)
        {

            CuriorTwo curior = _context.curiorTwos.Find(Id);


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
            CuriorTwo curior1 = _context.curiorTwos.Find(Id);
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
                ExImgMethods.DeleteFile(Path.Combine(_env.WebRootPath, "Pages", "image", curior1.ImgUrl));


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
            CuriorTwo curior = _context.curiorTwos.Find(Id);
            if (curior == null)
            {
                return BadRequest();

            }
            ExImgMethods.DeleteFile(Path.Combine(_env.WebRootPath, "Pages", "image", curior.ImgUrl));

            _context.curiorTwos.Remove(curior);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
