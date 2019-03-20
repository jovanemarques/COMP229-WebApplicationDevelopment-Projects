using System;
using System.Collections.Generic;
using System.Reflection;

namespace SoccerManagementSystem.Models
{
    public class Club
    {
        //private static int clubID = 0;
        public int ClubID { get; set; }
        public string Name { get; set; }
        public DateTime Foundation { get; set; }
        public string CresteLinkAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Player> Players { get; set; }
        public FieldInfo[] GetFields()
        {
            return this.GetType().GetFields();
        }
        public Club()
        {
            //clubID = clubID++;
        }
    }
}
