using System;
using System.Collections.Generic;

namespace SoccerManagementSystem.Models
{
    public class FakeRepository : IRepository
    {
        private List<Club> clubs = new List<Club>();
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

        public List<Club> Clubs
        {
            get { return clubs; }
        }
        public void Add(Club club)
        {
            clubs.Add(club);
        }
        public void LoadClubs()
        {
            clubs.AddRange(
                new List<Club>  {
                new Club {
                    Name = "Flamengo",
                    Foundation = new DateTime(1895,11,19),
                    CresteLinkAddress = "/images/flamengo_logo.png",
                    City = "Rio de Janeiro",
                    Country = "Brazil"
                },
                new Club {
                    Name = "Real Madrid",
                    Foundation = new DateTime(1902,03,06),
                    CresteLinkAddress = "/images/real_madrid.jpg",
                    City = "Madrid",
                    Country = "Spain"
                }
            });
        }
        public void LoadData()
        {
            LoadClubs();
        }

        public Club GetClub(int clubId)
        {
            Club result = null;
            foreach (var club in clubs)
            {
                if (clubId == club.Id)
                {
                    result = club;
                }
            }
            return result;
        }
    }
}
