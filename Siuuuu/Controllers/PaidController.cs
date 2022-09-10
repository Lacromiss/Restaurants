using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Mvc;
using Siuuuu.DAL;
using Siuuuu.Models.Odemek;
using System.Collections.Generic;

namespace Siuuuu.Controllers
{
    public class PaidController : Controller
    {
        private AppDbContext _context;

        public PaidController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }
      
    }
}
