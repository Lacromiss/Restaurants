using Microsoft.AspNetCore.Mvc;
using Siuuuu.DAL;
using Siuuuu.Models.Mail;
using System;

namespace Siuuuu.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly AppDbContext _context;

        public ContactUsController(AppDbContext context)
        {
            _context = context;

        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Email email)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }
            email.dateTime = DateTime.Parse(DateTime.Now.ToShortDateString());
            _context.emails.Add(email);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
