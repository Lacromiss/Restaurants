using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Siuuuu.DAL;
using Siuuuu.Models.Buy;
using Siuuuu.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Siuuuu.Controllers
{
    public class BABAController : Controller
    {
        private AppDbContext _context;

        public BABAController(AppDbContext context)
        {

            _context = context;
        }
        public IActionResult Index()
        {
            List<BuyProductCount> buyProduct = JsonConvert.DeserializeObject<List<BuyProductCount>>(Request.Cookies["basket"]);


            return View(buyProduct);
        }
    }
}
