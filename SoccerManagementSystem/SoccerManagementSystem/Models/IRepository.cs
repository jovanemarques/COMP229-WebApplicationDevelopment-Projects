using System.Collections.Generic;
using System.Linq;

namespace SoccerManagementSystem.Models
{
    public interface IRepository
    {
        IQueryable<Club> Clubs { get; }
        Club Get(int clubID);
        Club Save(Club club);
        Club Delete(int clubID);
    }
}