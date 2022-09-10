using Microsoft.AspNetCore.Mvc;
using Siuuuu.DAL;
using Siuuuu.Models.Mail;
using Siuuuu.Vm;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace RestorauntWebAppp.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class EmailController : Controller
    {
        private readonly AppDbContext _context;

        public EmailController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            SendAndReadEmailVm sendAndReadEmailVm = new SendAndReadEmailVm
            {
                email = _context.emails.ToList(),

            };

            return View(sendAndReadEmailVm);
        }
        public ActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMail(SendEmail model)
        {
            MailMessage mailim = new MailMessage();
            mailim.To.Add(model.EmailAdress);
            mailim.From = new MailAddress("tu7a45yc6@code.edu.az");
            mailim.Body = "Slider  firmasindan, " + model.Kontent;
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
        public IActionResult Delete(int Id)
        {
            Email email1 = _context.emails.Find(Id);
            if (email1==null)
            {
                return BadRequest();

            }
            _context.emails.Remove(email1);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
