using Microsoft.AspNetCore.Mvc;
using SoccerManagementSystem.Models;
using SoccerManagementSystem.Models.ViewModels;

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
            return View(club);
        }
        [HttpPost]
        public RedirectToActionResult RemovePlayer(int playerID, int clubID)
        {
            repository.RemovePlayerFromClub(playerID, clubID);
            return RedirectToAction("Club");//TODO: maybe point to a better destination
        }
        [HttpPost]
        public RedirectToActionResult AddPlayer(int playerID, int clubID)
        {
            repository.AddPlayerToClub(playerID, clubID);
            return RedirectToAction("Club");//TODO: maybe point to a better destination
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
        public ViewResult ManagePlayers(int clubID)
        {
            ManagePlayersViewModel manage = new ManagePlayersViewModel();
            manage.Club = repository.Get(clubID);
            manage.AvailablePlayers = repository.GetAvailablePlayers();

            return View(manage);
            //return View();
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