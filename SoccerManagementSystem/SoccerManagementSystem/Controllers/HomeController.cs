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
        public ViewResult Club()
        {
            return View(repository.Clubs);
        }
        //public ViewResult AddClub()
        //{
        //    return View();
        //}
        public ViewResult AddClub(Club club)
        {
            //TODO: date component is not loading corretly on update and on add
            return View(club);
        }
        [HttpPost]
        public RedirectToActionResult SaveClub(Club club)
        {
            Club clubReturn = repository.Save(club);
            return RedirectToAction("Club", clubReturn);
        }
        public ViewResult ShowClubDetails(int clubID)
        {
            Club club = repository.Get(clubID);
            return View(club);
        }
        public ViewResult ManagePlayers()
        {
            return View();
        }
        public RedirectToActionResult DeleteClub(int clubID)
        {
            Club club = repository.Delete(clubID);
            return RedirectToAction("Club", club);
        }
        public RedirectToActionResult UpdateClub(int clubID)
        {
            Club club = repository.Get(clubID);
            //club = repository.Save(club);
            return RedirectToAction("AddClub", club);
        }
    }
}