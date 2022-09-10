using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Siuuuu.Models.Buy;
using Siuuuu.DAL;
using Siuuuu.Models.Buy;
using Siuuuu.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siuuuu.Controllers
{
    public class BuyController : Controller
    {
        private AppDbContext _context;

        public BuyController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<BuyProduct> buyProduct = _context.buyProducts.ToList();
            return View(buyProduct);
        } 
        public IActionResult AddBasket(int? Id)
        {
            if (Id==null)
            {
                return BadRequest();

            }
            BuyProduct buyProduct1 = _context.buyProducts.Find(Id);
            if (buyProduct1 == null)
            {
                return NotFound();

            }

            List<BuyProductCount> buyProducts;
            string siu = Request.Cookies["basket"];
            if (siu == null)
            {
                buyProducts = new List<BuyProductCount>();

            }
            else
            {
                buyProducts = JsonConvert.DeserializeObject<List<BuyProductCount>>(Request.Cookies["basket"]);
            }
            BuyProductCount buyProductCount=buyProducts.FirstOrDefault(X=>X.Id==buyProduct1.Id);
            if (buyProductCount==null)
            {
                BuyProductCount buyProductCount1 = new BuyProductCount();
                buyProductCount1.Id=buyProduct1.Id;
                buyProductCount1.Name = buyProduct1.Name;
                buyProductCount1.Count = 1;
                buyProducts.Add(buyProductCount1);

            }
            else
            {
                buyProductCount.Count++;
            }
            Response.Cookies.Append("basket",JsonConvert.SerializeObject(buyProducts),new CookieOptions { MaxAge=TimeSpan.FromMinutes(20)});
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Basket()
        {
            List<BuyProductCount> buyProduct = JsonConvert.DeserializeObject<List<BuyProductCount>>(Request.Cookies["basket"]);
            List<BuyProductCount> updatedProducts = new List<BuyProductCount>();

            foreach (var item in buyProduct)
            {
                BuyProduct dbProduct = _context.buyProducts.FirstOrDefault(p => p.Id == item.Id);
                BuyProductCount basketProduct = new BuyProductCount()
                {
                    Id = dbProduct.Id,
                    Price = dbProduct.Price,
                    Name = dbProduct.Name,
                    ImgUrl = dbProduct.ImgUrl,
                    Count = item.Count

                };

                basketProduct.Price = basketProduct.Price * basketProduct.Count;

                
                updatedProducts.Add(basketProduct);

            }

            return View(updatedProducts);
        }
        public async Task<IActionResult> InvokeAsync()
        {
            List<BuyProductCount> products = JsonConvert.DeserializeObject<List<BuyProductCount>>(Request.Cookies["basket"]);
            int cem =0;
            foreach (var item in products)
            {
                cem+=cem;

            }
            ViewBag.kount = cem;
            
            return View(await Task.FromResult(products));
        }
        public IActionResult RemoveItem(int? id)
        {
            if (id == null) return NotFound();

            string basket = Request.Cookies["basket"];

            List<BuyProductCount> products = JsonConvert.DeserializeObject<List<BuyProductCount>>(basket);

            BuyProductCount existProduct = products.FirstOrDefault(p => p.Id == id);

            if (existProduct == null) return NotFound();

            products.Remove(existProduct);

            Response.Cookies.Append(
                "basket",
                JsonConvert.SerializeObject(products),
                new CookieOptions { MaxAge = TimeSpan.FromMinutes(20) }
                );

            return RedirectToAction(nameof(Basket));
        }

        public IActionResult Topla(int? id)
        {
            if (id == null) return NotFound();

            string basket = Request.Cookies["basket"];

            List<BuyProductCount> products = JsonConvert.DeserializeObject<List<BuyProductCount>>(basket);

            BuyProductCount existProduct = products.FirstOrDefault(p => p.Id == id);

            if (existProduct == null) return NotFound();

            BuyProduct dbProdut = _context.buyProducts.FirstOrDefault(p => p.Id == id);

            if (dbProdut.Count > existProduct.Count)
            {
                existProduct.Count++;
            }
            else
            {
                TempData["Fail"] = "not enough count";
                return RedirectToAction("Basket", "Basket");
            }

            Response.Cookies.Append(
                "basket",
                JsonConvert.SerializeObject(products),
                new CookieOptions { MaxAge = TimeSpan.FromMinutes(20) }
                );

            return RedirectToAction(nameof(Basket));
        }

        public IActionResult Cix(int? id)
        {
            if (id == null) return NotFound();

            string basket = Request.Cookies["basket"];

            List<BuyProductCount> products = JsonConvert.DeserializeObject<List<BuyProductCount>>(basket);

            BuyProductCount existProduct = products.FirstOrDefault(p => p.Id == id);

            if (existProduct == null) return NotFound();

            if (existProduct.Count > 1)
            {
                existProduct.Count--;
            }
            else
            {
                RemoveItem(existProduct.Id);

                return RedirectToAction(nameof(Basket));
            }


            Response.Cookies.Append(
                "basket",
                JsonConvert.SerializeObject(products),
                new CookieOptions { MaxAge = TimeSpan.FromMinutes(20) }
                );

            return RedirectToAction(nameof(Basket));
        }
       
    }
}
