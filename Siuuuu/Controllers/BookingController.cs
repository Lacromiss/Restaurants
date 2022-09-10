using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Siuuuu.DAL;
using Siuuuu.Models.Booking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Siuuuu.Controllers
{
    public class BookingController : Controller
    {
        private AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.tableee = new SelectList(_context.bookingTables.ToList(), "Id", "Masaa");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Booking booking)
        {
            ViewBag.tableee = new SelectList(_context.bookingTables.ToList(), "Id", "Masaa");
            var a = _context.bookings.Where(x => x.BookingTableId == booking.BookingTableId).ToList();
            bool masa = _context.bookings.Any(x => x.BookingTableId == booking.BookingTableId);
            bool number = _context.bookings.Any(x => x.Phone == booking.Phone && x.StartTime.Day==booking.StartTime.Day && x.StartTime.Month==booking.StartTime.Month && x.StartTime.Year==booking.StartTime.Year);
            bool emaill = _context.bookings.Any(x => x.Email == booking.Email && x.StartTime.Day==booking.StartTime.Day && x.StartTime.Month==booking.StartTime.Month && x.StartTime.Year==booking.StartTime.Year);
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

            var time1 = booking.StartTime;
            var time2 = booking.EndTime;
            bool f = true;
            bool b = true;
            bool c = true;
            bool d = false;
            int time = 3;

            bool musi = true;
            bool var = false;

            bool son = false;
            
           
            var suslik = _context.bookings.Where(x => x.BookingTableId==booking.BookingTableId).ToList();
            if (booking.StartTime > booking.EndTime)
            {
                ModelState.AddModelError("EndTime", " yanlis data");
                return View();

            }
            if (time1.AddHours(5)<time2)
            {
                ModelState.AddModelError("StartTime", "Maksimum 5 saat yer rezerv ede bilersiniz");
                return View();

            }
         


       
        
          
            if (suslik==null)
            {
                ModelState.AddModelError("xeber", "rezervasyaniz qebul olunmusdur");

                _context.bookings.Add(booking);


            }
      
            else
            {

            
            foreach (var item in suslik)
            {
                if (item.StartTime>=booking.StartTime && item.EndTime<=booking.EndTime || item.StartTime>=booking.StartTime && item.StartTime<booking.EndTime || item.StartTime<=booking.StartTime && item.EndTime>booking.StartTime)
                {

                    var = true;

                }

            }
            if (var)
            {
                    ModelState.AddModelError("BookingTableId", "YER REZERV EDILIB");
                return View();

            }
            else
            {
                    ModelState.AddModelError("xeber", "rezervasyaniz qebul olunmusdur");

                    _context.bookings.Add(booking);
            }



            }





            _context.SaveChanges();



            return Content("Rezervasyonun qeyd olunmusdur");
        }

    }
}

