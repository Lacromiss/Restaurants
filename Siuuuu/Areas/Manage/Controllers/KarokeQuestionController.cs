using Microsoft.AspNetCore.Mvc;
using Siuuuu.DAL;
using Siuuuu.Models.Karoke;
using System.Collections.Generic;
using System.Linq;

namespace Siuuuu.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class KarokeQuestionController : Controller
    {
        private readonly AppDbContext _context;

        public KarokeQuestionController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<KarokeQuestion> questions = _context.karokeQuestions.ToList();
            return View(questions);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(KarokeQuestion karokeQuestion)
        {
            if (!ModelState.IsValid)
            {
                return View();

            }
            if (_context.karokeQuestions.Any(x => x.Question.ToLower() == karokeQuestion.Question.ToLower()))
            {
                ModelState.AddModelError("Question", "eyni suali tekrar yazma");
                return View();

            }
            _context.karokeQuestions.Add(karokeQuestion);
            _context.SaveChanges();



            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int Id)
        {
            KarokeQuestion karokeQuestion = _context.karokeQuestions.Find(Id);
            if (karokeQuestion == null)
            {
                return BadRequest();

            }
            return View(karokeQuestion);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int Id, KarokeQuestion ques)
        {
            KarokeQuestion ques1 = _context.karokeQuestions.Find(Id);
            if (ques1 == null)
            {
                return NotFound();
            }
            if (Id != ques1.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View();

            }
            ques1.Question = ques.Question;
            ques1.Answer = ques.Answer;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int Id)
        {
            KarokeQuestion karokeQuestion = _context.karokeQuestions.Find(Id);
            if (Id == null)
            {
                return BadRequest();

            }
            if (Id != karokeQuestion.Id)
            {
                return NotFound();

            }
            _context.karokeQuestions.Remove(karokeQuestion);
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }
    }
}
