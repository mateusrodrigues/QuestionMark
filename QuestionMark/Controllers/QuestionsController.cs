using QuestionMark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestionMark.Controllers
{
    [Authorize]
    [ValidateAntiForgeryToken]
    public class QuestionsController : Controller
    {
        [HttpPost]
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