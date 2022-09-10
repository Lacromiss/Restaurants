using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RestorauntWebAppp.Utilites;
using Siuuuu.DAL;
using Siuuuu.Models.Cv;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Siuuuu.Controllers
{
    public class CvController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CvController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CvForm()
        {


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CvForm(CvForm cvForm)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }

            if (cvForm.Pdf != null)
            {
                if (!(cvForm.Pdf.CheckSize(5)))
                {
                    ModelState.AddModelError("Pdf", "maksimum limit 5mb dir");
                    return View();


                }
                var extention = Path.GetExtension(cvForm.Pdf.FileName.ToLower());
                if (!(new[] { ".docx", ".pdf", ".doc" }).Contains(extention))
                {
                    ModelState.AddModelError("Pdf", "ancaq pdf,word, formatinda fayl ata bilersen");
                    return View();
                }



                cvForm.File = await cvForm.Pdf.SaveFileAsync(Path.Combine(_env.WebRootPath, "CvFile"));

            }
            else
            {
                ModelState.AddModelError("Pdf", "bos kecile bilmez");
                return View();

            }
            cvForm.time = DateTime.Parse(DateTime.Now.ToShortDateString());


            _context.cvForms.Add(cvForm);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}











