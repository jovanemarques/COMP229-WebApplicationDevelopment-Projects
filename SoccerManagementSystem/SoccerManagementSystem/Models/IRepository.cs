using System.Collections.Generic;

namespace SoccerManagementSystem.Models
{
    public interface IRepository
    {
        void Add(Club club);
        List<Club> Clubs { get; }

        Club GetClub(int clubId);
    }
}