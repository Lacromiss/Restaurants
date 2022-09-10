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
    public class CuriousImageTwoController : Controller
    {
        private AppDbContext _context;
        private IWebHostEnvironment _env;

        public CuriousImageTwoController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<CuriorOne> curior = _context.curiorOnes.ToList();
            return View(curior);
        }


        public IActionResult Update(int Id)
        {

            CuriorOne curior = _context.curiorOnes.Find(Id);


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
            CuriorOne curior1 = _context.curiorOnes.Find(Id);
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
            CuriorOne curior = _context.curiorOnes.Find(Id);
            if (curior == null)
            {
                return BadRequest();

            }
            ExImgMethods.DeleteFile(Path.Combine(_env.WebRootPath, "Pages", "image", curior.ImgUrl));

            _context.curiorOnes.Remove(curior);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
