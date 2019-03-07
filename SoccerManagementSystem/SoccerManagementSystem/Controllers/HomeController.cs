using Microsoft.AspNetCore.Mvc;
using SoccerManagementSystem.Models;

namespace SoccerManagementSystem.Controllers
{
    public class HomeController : Controller
    {
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
            return View(FakeRepository.GetFakeRepository().Clubs);
        }
        public ViewResult AddClub()
        {
            return View();
        }
        [HttpPost]
        public RedirectToActionResult AddNewClub(Club club)
        {
            FakeRepository.GetFakeRepository().Add(club);
            return RedirectToAction("Club");
        }
        public ViewResult ShowClubDetails(int clubId)
        {
            Club club = FakeRepository.GetFakeRepository().GetClub(clubId);
            return View(club);
        }
        public ViewResult ManagePlayers()
        {
            return View();
        }
    }
}