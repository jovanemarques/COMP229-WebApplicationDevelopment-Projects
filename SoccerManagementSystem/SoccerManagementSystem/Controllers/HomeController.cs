using Microsoft.AspNetCore.Mvc;
using SoccerManagementSystem.Models;

namespace SoccerManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;
        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }
        public ViewResult Index()
        {
            return View();
        }
        public ViewResult Menu()
        {
            return View();
        }
    }
}