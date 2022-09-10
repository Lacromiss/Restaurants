using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Siuuuu.DAL;
using Siuuuu.Models;
using Siuuuu.Vm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Siuuuu.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;

        public HomeController(AppDbContext context)
        {

            _context = context;
        }

        public IActionResult Index()
        {
            HomePageVm homePageVm = new HomePageVm
            {
                homeIcon = _context.homeIcons.ToList(),
                homeImageOne = _context.homeImageOnes.ToList(),
                homeImageTwo = _context.homeImageTwos.ToList(),
                homeTxt1 = _context.homeTxt1s.ToList(),
                homeTxt2 = _context.homeTxt2s.ToList(),
                homeMainImage = _context.homeMainImages.ToList(),
                homeManifestDescriptionn = _context.homeManifestDescriptionns.ToList(),
                food = _context.homeBestFoods.ToList(),
                descriptionOne = _context.homeDescriptionOnes.ToList(),
            };

            return View(homePageVm);
        }


    }
}
