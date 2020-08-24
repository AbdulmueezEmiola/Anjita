using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assignment_2.Models;

namespace Assignment_2.Controllers
{
    public class HomeController : Controller
    {
        private IAnjitaRepository repository;
        public HomeController(IAnjitaRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View(repository.Questions);
        }
        public IActionResult DeleteProduct(int Questionid)
        {            
            repository.DeleteQuestion(Questionid);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult EditProduct(int questionId)
        {
            SampleQuestion question = repository.FindQuestion(questionId);
            return RedirectToAction("Edit", "Entry",question);
        }
        
    }
}
