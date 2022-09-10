using Microsoft.AspNetCore.Mvc;
using Siuuuu.DAL;
using Siuuuu.Models.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace Siuuuu.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TopMessageController : Controller
    {
        private AppDbContext _context;

        public TopMessageController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Create(Top top)
        {
           _context.tops.Add(top);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMaill(SendEmail email)
        {



                MailMessage mailim = new MailMessage();
                mailim.To.Add("Lacromis@gmail.com");
                mailim.From = new MailAddress("tu7a45yc6@code.edu.az");
                mailim.Body = "Slider  firmasindan, " + email.Kontent;
                mailim.IsBodyHtml = true;



                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new NetworkCredential("tu7a45yc6@code.edu.az", "wiplash92144356789100");
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;

                try
                {
                    smtp.Send(mailim);
                    TempData["Message"] = " asdasdasdasdfsadtfasdutfasdtasfdas        Mesajınız catdirildi.";
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Mesaj gonderile bilmedi.xeta sebebi:" + ex.Message;
                }


            return View();


        }



    }
}
