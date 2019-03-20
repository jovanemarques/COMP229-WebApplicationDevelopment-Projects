using System;
using System.Collections.Generic;
using System.Linq;

namespace SoccerManagementSystem.Models
{
    public class FakeRepository : IRepository
    {
        private IQueryable<Club> clubs = new List<Club>().AsQueryable();
        private static FakeRepository repo;

        private FakeRepository()
        {

        }
        public static FakeRepository GetFakeRepository()
        {
            if (repo == null)
            {
                repo = new FakeRepository();
            }
            return repo;
        }

        public IQueryable<Club> Clubs
        {
            get { return clubs; }
        }
        public Club Save(Club club)
        {
            clubs.Append(club);
            return club;
        }
        public void LoadClubs()
        {
            clubs.Append(
                new Club
                {
                    Name = "Flamengo",
                    Foundation = new DateTime(1895, 11, 19),
                    CresteLinkAddress = "/images/flamengo_logo.png",
                    City = "Rio de Janeiro",
                    Country = "Brazil"
                });
            clubs.Append(
                new Club
                {
                    Name = "Real Madrid",
                    Foundation = new DateTime(1902, 03, 06),
                    CresteLinkAddress = "/images/real_madrid.jpg",
                    City = "Madrid",
                    Country = "Spain"
                });
        }
        public void LoadData()
        {
            LoadClubs();
        }

        public Club Get(int clubID)
        {
            Club result = null;
            foreach (var club in clubs)
            {
                if (clubID == club.ClubID)
                {
                    result = club;
                }
            }
            return result;
        }

        public Club Delete(int clubID)
        {
            throw new NotImplementedException();
        }
    }
}
