using Microsoft.AspNetCore.Mvc;
using Siuuuu.DAL;
using Siuuuu.Models.Adres;
using System.Collections.Generic;
using System.Linq;

namespace Siuuuu.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AdresController : Controller
    {
        private AppDbContext _context;

        public AdresController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
           List< Adres> adres = _context.adres.ToList();
            return View(adres);
        } 
        public IActionResult Delete(int Id)
        {
            
          Adres adres=  _context.adres.Find(Id);
            if (adres==null)
            {
                return NotFound();
            }
            _context.adres.Remove(adres);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
