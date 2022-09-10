using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RestorauntWebAppp.Utilites;
using Siuuuu.DAL;
using Siuuuu.Models.Buy;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Siuuuu.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BuyController : Controller
    {
        private AppDbContext _context;
        private IWebHostEnvironment _env;

        public BuyController(AppDbContext context,IWebHostEnvironment env)
        {

            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
           List< BuyProduct> buyProduct = _context.buyProducts.ToList();
            return View(buyProduct);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BuyProduct homeBestFood)
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
            _context.buyProducts.Add(homeBestFood);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Update(int Id)
        {

            BuyProduct bestFood = _context.buyProducts.Find(Id);


            if (bestFood == null)
            {
                return BadRequest();

            }

            return View(bestFood);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int Id, BuyProduct bestFood)
        {


            if (Id != bestFood.Id)
            {
                return BadRequest();
            }
            BuyProduct bestFood1 = _context.buyProducts.Find(Id);
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
            bestFood1.Name = bestFood.Name;
            bestFood1.Price = bestFood.Price;
            bestFood1.Count = bestFood.Count;
            bestFood1.Description = bestFood.Description;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int Id)
        {
            BuyProduct bestFood = _context.buyProducts.Find(Id);
            if (bestFood == null)
            {
                return BadRequest();

            }
            string suloysu = Path.Combine(_env.WebRootPath, "Pages", "image", bestFood.ImgUrl);
            if (System.IO.File.Exists(suloysu))
            {
                System.IO.File.Delete(suloysu);

            }
            _context.buyProducts.Remove(bestFood);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
