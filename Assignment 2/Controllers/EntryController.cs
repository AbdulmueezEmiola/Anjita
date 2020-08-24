using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2.Controllers
{
    public class EntryController : Controller
    {
        private IAnjitaRepository anjitaRepository;
        public EntryController(IAnjitaRepository anjitaRepository)
        {
            this.anjitaRepository = anjitaRepository;
        }
        public IActionResult Index()
        {

            ViewBag.CanAdd = anjitaRepository.CanAdd;
            return View(new SampleQuestion());
            
        }

        [HttpPost]
        public IActionResult Index(SampleQuestion sampleQuestion)
        {
            if (ModelState.IsValid)
            {
                anjitaRepository.SaveQuestion(sampleQuestion);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.CanAdd = anjitaRepository.CanAdd;
                return View();
            }
        }
        public IActionResult Edit(SampleQuestion sampleQuestion)
        {
            ViewBag.Type = "Edit";
            return View("Index",sampleQuestion);
        }
    }
}