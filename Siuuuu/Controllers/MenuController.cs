using Microsoft.AspNetCore.Mvc;
using Siuuuu.DAL;
using Siuuuu.Models.Menu;
using Siuuuu.Vm;
using System.Collections.Generic;
using System.Linq;

namespace Siuuuu.Controllers
{
    public class MenuController : Controller
    {
        private AppDbContext _context;

        public MenuController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

         List   < Product> product=   _context.products.Where(x => x.CatagoryId == 1).ToList();
         List   < Product> product1=   _context.products.Where(x => x.CatagoryId == 2).ToList();
         List   < Product> product2=   _context.products.Where(x => x.CatagoryId == 3).ToList();
         List   < Product> product3=   _context.products.Where(x => x.CatagoryId == 4).ToList();
            ViewData["product"] = product;
            ViewData["product1"] = product1;
            ViewData["product2"] = product2;
            ViewData["product3"] = product3;



            return View();
        }
        public IActionResult Indexx()
        {
            List<Product> product = _context.products.Where(x => x.CatagoryId == 1).ToList();
            List<Product> product1 = _context.products.Where(x => x.CatagoryId == 2).ToList();
            List<Product> product2 = _context.products.Where(x => x.CatagoryId == 3).ToList();
            List<Product> product3 = _context.products.Where(x => x.CatagoryId == 4).ToList();
            ViewData["product"] = product;
            ViewData["product1"] = product1;
            ViewData["product2"] = product2;
            ViewData["product3"] = product3;
            return View();
        }
    }
}
