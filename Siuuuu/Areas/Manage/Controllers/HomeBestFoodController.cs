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
    public class HomeBestFoodController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public HomeBestFoodController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }

        public IActionResult Index()
        {
            List<HomeBestFood> homeImageOne = _context.homeBestFoods.ToList();
            return View(homeImageOne);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HomeBestFood homeBestFood)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }


            if (homeBestFood.Photo != null)
            {
                if (!(homeBestFood.Photo.CheckSize(5)))
                {
                    ModelState.AddModelError("Photo", "5 mb limitinizi kecibsiz");
                    return View();


                }
                if (!(homeBestFood.Photo.CheckType("image/")))
                {
                    ModelState.AddModelError("Photo", "img  formatinda bir seyler at");
                    return View();

                }


                homeBestFood.ImgUrl = await homeBestFood.Photo.SaveFileAsync(Path.Combine(_env.WebRootPath, "Pages", "image"));


            }
            else
            {
                ModelState.AddModelError("Photo", "image elave etmelisen bos kecile bilmez");
                return View();
            }
            _context.homeBestFoods.Add(homeBestFood);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Update(int Id)
        {

            HomeBestFood bestFood = _context.homeBestFoods.Find(Id);


            if (bestFood == null)
            {
                return BadRequest();

            }

            return View(bestFood);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int Id, HomeBestFood bestFood)
        {


            if (Id != bestFood.Id)
            {
                return BadRequest();
            }
            HomeBestFood bestFood1 = _context.homeBestFoods.Find(Id);
            if (bestFood1 == null)
            {
                return NotFound();
            }



            if (bestFood.Photo != null)
            {
                if (!(bestFood.Photo.CheckSize(5)))
                {
                    ModelState.AddModelError("Photo", "5 mb limitinizi kecibsiz");
                    return View();


                }
                if (!(bestFood.Photo.CheckType("image/")))
                {
                    ModelState.AddModelError("Photo", "img  formatinda bir seyler at");
                    return View();

                }

                string suloysu = Path.Combine(_env.WebRootPath, "Pages", "image", bestFood1.ImgUrl);
                if (System.IO.File.Exists(suloysu))
                {
                    System.IO.File.Delete(suloysu);

                }
                bestFood1.ImgUrl = await bestFood.Photo.SaveFileAsync(Path.Combine(_env.WebRootPath, "Pages", "image"));


            }
            else
            {
                ModelState.AddModelError("Photo", "image elave etmelisen bos kecile bilmez");
                return View();
            }
            bestFood1.Txt = bestFood.Txt;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int Id)
        {
            HomeBestFood bestFood = _context.homeBestFoods.Find(Id);
            if (bestFood == null)
            {
                return BadRequest();

            }
            string suloysu = Path.Combine(_env.WebRootPath, "Pages", "image", bestFood.ImgUrl);
            if (System.IO.File.Exists(suloysu))
            {
                System.IO.File.Delete(suloysu);

            }
            _context.homeBestFoods.Remove(bestFood);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
