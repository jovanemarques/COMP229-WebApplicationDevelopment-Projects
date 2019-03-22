using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerManagementSystem.Models.ViewModels
{
    public class ManagePlayersViewModel
    {
        public Club Club { get; set; }
        public IQueryable<Player> AvailablePlayers { get; set; }
    }
}
