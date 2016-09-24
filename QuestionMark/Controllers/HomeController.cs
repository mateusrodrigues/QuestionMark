using QuestionMark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestionMark.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Question> model;

            using (var db = new ApplicationDbContext())
            {
                model = db.Questions.OrderByDescending(m => m.PublishedAt).Take(100).ToList();
            }

            return View(model);
        }
    }
}