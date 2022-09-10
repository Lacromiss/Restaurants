using Microsoft.AspNetCore.Mvc;
using Siuuuu.DAL;
using Siuuuu.Models.Customer;
using System.Collections.Generic;
using System.Linq;

namespace Siuuuu.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CustomerCarieerController : Controller
    {
        private AppDbContext _context;

        public CustomerCarieerController(AppDbContext context)
        {
            _context = context;

        }

        public IActionResult Index()
        {
            List<CustomerJobAndCareer> careers = _context.customerJobAndCareers.ToList();
            return View(careers);
        }

        public IActionResult Update(int Id)
        {

            CustomerJobAndCareer careers = _context.customerJobAndCareers.Find(Id);


            if (careers == null)
            {
                return BadRequest();

            }
            return View(careers);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int Id, CustomerJobAndCareer career)
        {
            if (Id != career.Id)
            {
                return BadRequest();
            }
            CustomerJobAndCareer career1 = _context.customerJobAndCareers.Find(Id);
            if (career1 == null)
            {
                return NotFound();
            }


            if (!ModelState.IsValid)
            {
                return View();

            }
            career1.Title = career.Title;
            career1.Description = career.Description;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}