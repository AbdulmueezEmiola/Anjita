using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_3.Models;
using Assignment_3.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_3.Controllers
{
    public class ResultController : Controller
    {
        private IUserRepository repository;
        public ResultController(IUserRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {

            var Items = from Question in repository.Questions
                        join Answer in repository.Answers on Question.QuestionId equals Answer.QuestionId
                        select new { UserAnswer = Answer.Answer,CorrectAnswer= Question.CorrectAnswer };
            var count = Items.Count(e => e.CorrectAnswer == e.UserAnswer);
            return View(new Result { Score = count, Total = repository.QuestionCount});
        }
    }
}