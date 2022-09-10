using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siuuuu.DAL;
using Siuuuu.Models.Booking;
using System.Collections.Generic;
using System.Linq;

namespace Siuuuu.Areas.Manage.Controllers
{
    [Area("Manage")]

    public class BookingController : Controller
    {

        private AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            _context = context;

        }

        public IActionResult Index()
        {
          List<  Booking> booking = _context.bookings.ToList();
            return View(booking);
        } 
        public IActionResult Read()
        {
          List<  ProRoom> proRooms = _context.proRooms.ToList();
            return View(proRooms);
        }  
        public IActionResult Family()
        {
          List<Middle> middles = _context.middles.ToList();
            return View(middles);
        }
        public IActionResult Delete(int? Id)
        {
            Booking booking= _context.bookings.Find(Id);
            if (Id==null)
            {
                return BadRequest();

            }
            _context.bookings.Remove(booking);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult ReadDelete(int? Id)
        {
            ProRoom pro = _context.proRooms.Find(Id);
            if (Id == null)
            {
                return BadRequest();

            }
            _context.proRooms.Remove(pro);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        } 
        public IActionResult FamilyDelete(int? Id)
        {
            Middle pro = _context.middles.Find(Id);
            if (Id == null)
            {
                return BadRequest();

            }
            _context.middles.Remove(pro);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
