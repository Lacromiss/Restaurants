using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RestorauntWebAppp.Utilites;
using Siuuuu.DAL;
using Siuuuu.Models.Customer;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Siuuuu.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class MyCustomerrController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public MyCustomerrController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }

        public IActionResult Index()
        {
            List<CustomeHuman> human = _context.customeHumen.ToList();
            return View(human);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomeHuman human)
        {
            if (!ModelState.IsValid)
            {

                return View();

            }
            if (human.Photo != null)
            {
                if (!(human.Photo.CheckSize(5)))
                {
                    ModelState.AddModelError("Photo", "5 mb limitinizi kecibsiz");
                    return View();


                }
                if (!(human.Photo.CheckType("image/")))
                {
                    ModelState.AddModelError("Photo", "img  formatinda bir seyler at");
                    return View();

                }


                human.ImgUrl = await human.Photo.SaveFileAsync(Path.Combine(_env.WebRootPath, "Pages", "image"));


            }
            else
            {
                ModelState.AddModelError("Photo", "image elave etmelisen bos kecile bilmez");
                return View();
            }
            await _context.customeHumen.AddAsync(human);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int Id)
        {

            CustomeHuman human = _context.customeHumen.Find(Id);


            if (human == null)
            {
                return BadRequest();

            }

            return View(human);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int Id, CustomeHuman human)
        {
            if (Id != human.Id)
            {
                return BadRequest();
            }
            CustomeHuman human1 = _context.customeHumen.Find(Id);
            if (human1 == null)
            {
                return NotFound();
            }


            if (!ModelState.IsValid)
            {
                return View();

            }
            if (human.Photo != null)
            {
                if (!(human.Photo.CheckSize(5)))
                {
                    ModelState.AddModelError("Photo", "5 mb limitinizi kecibsiz");
                    return View();


                }
                if (!(human.Photo.CheckType("image/")))
                {
                    ModelState.AddModelError("Photo", "img  formatinda bir seyler at");
                    return View();

                }
                ExImgMethods.DeleteFile(Path.Combine(_env.WebRootPath, "Pages", "image", human1.ImgUrl));


                human1.ImgUrl = await human.Photo.SaveFileAsync(Path.Combine(_env.WebRootPath, "Pages", "image"));


            }
            else
            {
                ModelState.AddModelError("Photo", "image elave etmelisen bos kecile bilmez");
                return View();
            }
            human1.insta = human.insta;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int Id)
        {
            CustomeHuman customeHuman = _context.customeHumen.Find(Id);
            if (customeHuman == null)
            {
                return BadRequest();

            }
            ExImgMethods.DeleteFile(Path.Combine(_env.WebRootPath, "Pages", "image", customeHuman.ImgUrl));

            _context.customeHumen.Remove(customeHuman);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
