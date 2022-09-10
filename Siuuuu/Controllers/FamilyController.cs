using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Siuuuu.DAL;
using Siuuuu.Models.Booking;
using System.Linq;

namespace Siuuuu.Controllers
{
    public class FamilyController : Controller
    {
        private AppDbContext _context;

        public FamilyController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.middle = new SelectList(_context.middleStols.ToList(), "Id", "Masaa");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Middle middle)
        {
            ViewBag.middle = new SelectList(_context.middleStols.ToList(), "Id", "Masaa");
            var a = _context.middles.Where(x => x.MiddleStolId == middle.MiddleStolId).ToList();
            bool masa = _context.middles.Any(x => x.MiddleStolId == middle.MiddleStolId);
            bool number = _context.middles.Any(x => x.Phone == middle.Phone && x.StartTime.Day == middle.StartTime.Day && x.StartTime.Month == middle.StartTime.Month && x.StartTime.Year == middle.StartTime.Year);
            bool emaill = _context.middles.Any(x => x.Email == middle.Email && x.StartTime.Day == middle.StartTime.Day && x.StartTime.Month == middle.StartTime.Month && x.StartTime.Year == middle.StartTime.Year);
            if (number)
            {
                ModelState.AddModelError("StartTime", "bir nomre ile 2 defe qeydiyat olmaz");
                return View();

            }
            if (emaill)
            {
                ModelState.AddModelError("Email", "bir mail ile 2 defe qeydiyat olmaz");

                return View();

            }
            if (!ModelState.IsValid)
            {
                return View();

            }

            var time1 = middle.StartTime;
            var time2 = middle.EndTime;
            bool f = true;
            bool b = true;
            bool c = true;
            bool d = false;
            int time = 3;

            bool musi = true;
            bool var = false;

            bool son = false;


            var suslik = _context.middles.Where(x => x.MiddleStolId == middle.MiddleStolId).ToList();
            if (middle.StartTime > middle.EndTime)
            {
                ModelState.AddModelError("EndTime", " yanlis data");
                return View();

            }
            if (time1.AddHours(5) < time2)
            {
                ModelState.AddModelError("StartTime", "Maksimum 5 saat yer rezerv ede bilersiniz");
                return View();

            }






            if (suslik == null)
            {
                ModelState.AddModelError("xeber", "rezervasyaniz qebul olunmusdur");

                _context.middles.Add(middle);


            }

            else
            {


                foreach (var item in suslik)
                {
                    if (item.StartTime >= middle.StartTime && item.EndTime <= middle.EndTime || item.StartTime >= middle.StartTime && item.StartTime < middle.EndTime || item.StartTime <= middle.StartTime && item.EndTime > middle.StartTime)
                    {

                        var = true;

                    }

                }
                if (var)
                {
                    ModelState.AddModelError("MiddleStolId", "YER REZERV EDILIB");
                    return View();

                }
                else
                {
                    ModelState.AddModelError("xeber", "rezervasyaniz qebul olunmusdur");

                    _context.middles.Add(middle);
                }



            }





            _context.SaveChanges();



            return Content("Rezervasyonun qeyd olunmusdur");

        }
    }
}
