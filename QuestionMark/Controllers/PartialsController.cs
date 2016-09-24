using QuestionMark.Models;
using QuestionMark.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestionMark.Controllers
{
    public class PartialsController : Controller
    {
        // GET: Partials
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
    }
}