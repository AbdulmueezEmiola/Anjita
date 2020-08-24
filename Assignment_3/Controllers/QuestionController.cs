using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_3.Infrastructure;
using Assignment_3.Models;
using Assignment_3.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_3.Controllers
{
    public class QuestionController : Controller
    {
        private IUserRepository repository;
        public QuestionController(IUserRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index(int pos =0)
        {
            if (pos == repository.Questions.Count())
            {
                return RedirectToAction("Index", "Result");
            }
            EmailModel email = HttpContext.Session.GetJson<EmailModel>("EmailModel") ?? new EmailModel();
            SampleQuestion question = repository.FindQuestion(pos);
            ViewBag.QuestionNumber = pos+1;
            UserAnswer answer = repository.FindAnswer(question.QuestionId, email.Email);            
            return View(new SampleQuestionViewModel
            {
                SampleQuestion = question,
                QuestionNumber = pos + 1,
                ShowPrev = pos > 0,
                ShowNext = pos < repository.QuestionCount,
                Answer = answer?.Answer ?? 0
            }) ;
        }
        [HttpPost]
        public IActionResult Index(string Prev, string Next,string answer, int questionId, int pos = 0)
        {
            if (pos == repository.Questions.Count())
            {
                return RedirectToAction("Index", "Result");
            }
            if (!string.IsNullOrEmpty(Prev))
            {
                pos--;
            }
            else if (!string.IsNullOrEmpty(Next))
            {
                pos++;
            }
            SampleQuestion question = repository.FindQuestion(pos);
            EmailModel email = HttpContext.Session.GetJson<EmailModel>("EmailModel") ?? new EmailModel();
            if (answer != null)
            {
                repository.SaveAnswer(new UserAnswer { QuestionId= questionId,Answer = int.Parse(answer),EmailAddress = email.Email});
            }
            ViewBag.QuestionNumber = pos + 1;
            UserAnswer userAnswer = repository.FindAnswer(question.QuestionId, email.Email);
            return View(new SampleQuestionViewModel
            {
                SampleQuestion = question,
                QuestionNumber = pos + 1,
                ShowPrev = pos > 0,
                ShowNext = pos < repository.QuestionCount-1,
                Answer = userAnswer?.Answer??0
            });
        }
    }
}