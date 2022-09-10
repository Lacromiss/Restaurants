using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestorauntWebAppp.Utilites;
using Siuuuu.DAL;
using Siuuuu.Models.Menu;
using Siuuuu.Vm;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Siuuuu.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class MenuProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public MenuProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }
        public IActionResult Index()
        {
            ProductCatagoryVm pcVm = new ProductCatagoryVm();
            pcVm.product = _context.products.ToList();
            pcVm.catagory = _context.catagories.ToList();
            return View(pcVm);
        }
        public IActionResult Create()
        {
            ViewBag.catagory = new SelectList(_context.catagories.ToList(), "Id", "Name");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            ViewBag.catagory = new SelectList(_context.catagories.ToList(), "Id", "Name");

            if (!ModelState.IsValid)
            {
                return View();

            }


            if (product.Photo2 != null)
            {
                if (!(product.Photo2.CheckSize(5)))
                {
                    ModelState.AddModelError("Photo2", "5 mb limitinizi kecibsiz");
                    return View();


                }
                if (!(product.Photo2.CheckType("image/")))
                {
                    ModelState.AddModelError("Photo2", "img  formatinda bir seyler at");
                    return View();

                }


                product.LargeImg = await product.Photo2.SaveFileAsync(Path.Combine(_env.WebRootPath, "Pages", "image"));


            }
            else
            {
                ModelState.AddModelError("Photo2", "image elave etmelisen bos kecile bilmez");
                return View();
            }


            _context.products.Add(product);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int Id)
        {
            ViewBag.catagoryy = _context.catagories.ToList();

            Product product = _context.products.Find(Id);
            if (product == null)
            {
                return BadRequest();

            }
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Product product, int Id)
        {

            if (Id != product.Id)
            {
                return NotFound();

            }
            Product product1 = _context.products.Find(Id);
            if (product1 == null)
            {
                return BadRequest();

            }

            if (!ModelState.IsValid)
            {
                return View();

            }





           


            if (product.Photo2 != null)
            {
                if (!(product.Photo2.CheckSize(5)))
                {
                    ModelState.AddModelError("Photo2", "5 mb limitinizi kecibsiz");
                    return View();


                }
                if (!(product.Photo2.CheckType("image/")))
                {
                    ModelState.AddModelError("Photo2", "img  formatinda bir seyler at");
                    return View();

                }

                string suloysu = Path.Combine(_env.WebRootPath, "Pages", "image", product1.LargeImg);
                if (System.IO.File.Exists(suloysu))
                {
                    System.IO.File.Delete(suloysu);

                }

                product1.LargeImg = await product.Photo2.SaveFileAsync(Path.Combine(_env.WebRootPath, "Pages", "image"));


            }
            else
            {
                ModelState.AddModelError("Photo2", "image elave etmelisen bos kecile bilmez");
                return View();
            }

            product1.Description = product.Description;
            product1.Name = product.Name;
            product1.Price = product.Price;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int Id)
        {
            Product product = _context.products.Find(Id);
            if (product == null)
            {
                return BadRequest();

            }

            string suloysu = Path.Combine(_env.WebRootPath, "Pages", "image", product.LargeImg);
            if (System.IO.File.Exists(suloysu))
            {
                System.IO.File.Delete(suloysu);

            }
            _context.products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
