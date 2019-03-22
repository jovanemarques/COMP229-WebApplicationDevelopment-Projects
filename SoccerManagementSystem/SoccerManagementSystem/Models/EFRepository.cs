using Microsoft.EntityFrameworkCore;
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
        public IQueryable<Club> Clubs => dbContext.Clubs.Include(c => c.Players);
        public IQueryable<Player> Players => dbContext.Players;

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
            Club club = dbContext.Clubs.Include(c => c.Players).FirstOrDefault(c => c.ClubID == clubID);
            if (club != null)
            {
                foreach (var player in club.Players)
                {
                    player.hasTeam = false;
                }
                club.Players.RemoveAll(p => p.hasTeam = false);
                dbContext.Clubs.Remove(club);
                dbContext.SaveChanges();
            }
            return club;
        }

        public Club Get(int clubID) =>
            Clubs.FirstOrDefault(c => c.ClubID == clubID);

        public IQueryable<Player> GetAvailablePlayers()
        {
            return Players.Where(p => !p.hasTeam);
        }

        public Player RemovePlayerFromClub(int playerID, int clubID)
        {
            Player player = Players.FirstOrDefault(p => p.PlayerID == playerID);
            Club club = Clubs.FirstOrDefault(c => c.ClubID == clubID);
            club.Players.Remove(player);
            player.hasTeam = false;
            dbContext.SaveChanges();
            return player;
        }
        public Player AddPlayerToClub(int playerID, int clubID)
        {
            Player player = Players.FirstOrDefault(p => p.PlayerID == playerID);
            Club club = Clubs.FirstOrDefault(c => c.ClubID == clubID);
            club.Players.Add(player);
            player.hasTeam = true;
            dbContext.SaveChanges();
            return player;
        }
    }
}
