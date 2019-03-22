using Microsoft.AspNetCore.Mvc;
using SoccerManagementSystem.Models;
using SoccerManagementSystem.Models.ViewModels;

namespace SoccerManagementSystem.Controllers
{
    public class ClubController : Controller
    {
        private IRepository repository;
        public ClubController(IRepository repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        public RedirectToActionResult SaveClub(Club club)
        {
            Club clubReturn = repository.Save(club);
            return RedirectToAction("List", clubReturn);
        }
        public ViewResult Add(Club club)
        {
            return View(club);
        }
        [HttpPost]
        public RedirectToActionResult RemovePlayer(int playerID, int clubID)
        {
            repository.RemovePlayerFromClub(playerID, clubID);
            return RedirectToAction("List");
        }
        [HttpPost]
        public RedirectToActionResult AddPlayer(int playerID, int clubID)
        {
            repository.AddPlayerToClub(playerID, clubID);
            return RedirectToAction("List");
        }
        [HttpPost]
        public RedirectToActionResult DeleteClub(int clubID)
        {
            Club club = repository.Delete(clubID);
            return RedirectToAction("List", club);
        }
        [HttpPost]
        public RedirectToActionResult UpdateClub(int clubID)
        {
            Club club = repository.Get(clubID);
            return RedirectToAction("Add", club);
        }
        [HttpPost]
        public ViewResult ManagePlayers(int clubID)
        {
            ManagePlayersViewModel manage = new ManagePlayersViewModel();
            manage.Club = repository.Get(clubID);
            manage.AvailablePlayers = repository.GetAvailablePlayers();

            return View(manage);
        }
        [HttpPost]
        public ViewResult Details(int clubID)
        {
            Club club = repository.Get(clubID);
            return View(club);
        }
        public ViewResult List()
        {
            return View(repository.Clubs);
        }
    }
}