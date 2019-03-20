using System.Linq;

namespace SoccerManagementSystem.Models
{
    public class EFRepository : IRepository
    {
        private AppDBContext dbContext;
        public EFRepository(AppDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IQueryable<Club> Clubs => dbContext.Clubs;

        public Club Save(Club club)
        {
            if (club.ClubID == 0)
            {
                dbContext.Clubs.Add(club);
            }
            else
            {
                Club clubCtx = dbContext.Clubs.FirstOrDefault(c => c.ClubID == club.ClubID);
                clubCtx.Name = club.Name;
                clubCtx.Foundation = club.Foundation;
                clubCtx.City = club.City;
                clubCtx.Country = club.Country;
                clubCtx.CresteLinkAddress = club.CresteLinkAddress;
            }
            dbContext.SaveChanges();
            return club;
        }

        public Club Delete(int clubID)
        {
            Club club = dbContext.Clubs.FirstOrDefault(c => c.ClubID == clubID);
            if (club != null)
            {
                dbContext.Clubs.Remove(club);
                dbContext.SaveChanges();
            }
            return club;
        }

        public Club Get(int clubID)
        {
            return dbContext.Clubs.FirstOrDefault(c => c.ClubID == clubID);
        }
    }
}
