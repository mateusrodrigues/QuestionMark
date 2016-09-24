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
        private ApplicationDbContext _db;

        public HomeController()
        {
            _db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            List<Question> model;

            model = _db.Questions.OrderByDescending(m => m.PublishedAt).Take(100).ToList();

            return View(model);
        }
    }
}