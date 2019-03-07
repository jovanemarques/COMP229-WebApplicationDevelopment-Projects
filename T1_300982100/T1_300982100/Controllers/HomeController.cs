using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using T1_300982100.Models;

namespace T1_300982100.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;
        public HomeController(IRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegistrationResult(Car car)
        {
            repository.AddCar(car);
            return View(car);
        }
        public IActionResult ResgistrationList()
        {
            return View();
        }
    }
}