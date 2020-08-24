using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assignment_3.Models;
using Assignment_3.Infrastructure;

namespace Assignment_3.Controllers
{
    public class HomeController : Controller
    {
        private IUserRepository repository;
        public HomeController(IUserRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(EmailModel emailModel)
        {
            HttpContext.Session.SetJson("EmailModel", emailModel);
            repository.SaveEmail(emailModel);
            int pos;
            if (repository.Answers.Count(e => e.EmailAddress == emailModel.Email)>0)
            {
                var questionId = repository.Answers.Where(e => e.EmailAddress == emailModel.Email).Max(e => e.QuestionId);
                pos = repository.Questions.Count(e => e.QuestionId <= questionId);
            }
            else
            {
                pos = 0;
            }
            return RedirectToAction("Index", "Question",new { pos = pos});
        }

    }
}
