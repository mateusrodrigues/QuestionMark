using QuestionMark.Models;
using QuestionMark.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestionMark.Controllers
{
    [Authorize]
    public class QuestionsController : Controller
    {
        private ApplicationDbContext _context;

        public QuestionsController()
        {
            _context = new ApplicationDbContext();
        }

        public JsonResult GetJson(int id)
        {
            var question = _context.Questions.Find(id);

            var result = new
            {
                Content = question.Content,
                QuestionID = question.QuestionID
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AnswerJson(AnswerQuestionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var question = _context.Questions.Find(model.QuestionID);

                question.Answer = model.Answer;
                question.Status = Status.Answered;

                _context.SaveChanges();

                return Json(new
                {
                    QuestionID = question.QuestionID,
                    Content = question.Content,
                    Answer = question.Answer,
                    PublishedAt = question.PublishedAt
                }, JsonRequestBehavior.DenyGet);
            }

            return Json(new { Message = "Invalid model" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Question question)
        {
            question.PublishedAt = DateTime.UtcNow.AddHours(-3);
            question.Status = Status.Awaiting;

            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    db.Questions.Add(question);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
            }

            return View(question);
        }
    }
}