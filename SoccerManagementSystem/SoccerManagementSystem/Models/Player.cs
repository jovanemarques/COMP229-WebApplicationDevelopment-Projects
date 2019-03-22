using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerManagementSystem.Models
{
    public class Player
    {

        public int PlayerID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public bool hasTeam { get; set; }
    }
}
