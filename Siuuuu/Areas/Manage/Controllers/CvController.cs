using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Siuuuu.DAL;
using Siuuuu.Models.Cv;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Siuuuu.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CvController : Controller
    {
        private AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CvController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }
        public IActionResult Index()
        {
            List<CvForm> cvForm = _context.cvForms.ToList();




            return View(cvForm);
        }
        public IActionResult Delete(int? Id)
        {
            CvForm cvForm = _context.cvForms.Find(Id);
            if (Id == null)
            {
                return BadRequest();

            }
            string suloysu = Path.Combine(_env.WebRootPath, "CvFile", cvForm.File);
            if (System.IO.File.Exists(suloysu))
            {
                System.IO.File.Delete(suloysu);

            }

            _context.cvForms.Remove(cvForm);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
