﻿using QuestionMark.Models;
using QuestionMark.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestionMark.Controllers
{
    public class PartialsController : Controller
    {
        // GET: Partials
        [AllowAnonymous]
        public PartialViewResult UserInformation(string email)
        {
            UserInformationViewModel model = new UserInformationViewModel();

            using (var db = new ApplicationDbContext())
            {
                var user = db.Users.FirstOrDefault(m => m.Email.Equals(email));

                if (user != null)
                {
                    model.Email = user.Email;
                    model.Name = user.Name;
                    model.EnrollmentNumber = user.EnrollmentNumber;
                }
            }

            return PartialView("_UserInformation", model);
        }

        public PartialViewResult NewQuestion()
        {
            Question question = new Question();

            using (var db = new ApplicationDbContext())
            {
                ViewBag.TopicID = new SelectList(db.Topics.ToList(), "TopicID", "Title");
                question.UserID = db.Users.FirstOrDefault(m => m.Email.Equals(User.Identity.Name)).Id;
            }

            return PartialView("_NewQuestion", question);
        }

        public PartialViewResult AnswerQuestion()
        {
            return PartialView("_AnswerQuestion");
        }

        public PartialViewResult Questions()
        {
            List<Question> model;
            using (var db = new ApplicationDbContext())
            {
                model = db.Questions
                    .Include(p => p.Topic)
                    .Include(p => p.User)
                    .ToList();
            }

            return PartialView("_Questions", model);
        }
    }
}