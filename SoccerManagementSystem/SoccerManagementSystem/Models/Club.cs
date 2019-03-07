using System;
using System.Reflection;

namespace SoccerManagementSystem.Models
{
    public class Club
    {
        private static int id = 0;
        public int Id { get; }
        public string Name { get; set; }
        public DateTime Foundation { get; set; }
        public string CresteLinkAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public FieldInfo[] GetFields()
        {
            return this.GetType().GetFields();
        }
        public Club()
        {
            Id = id++;
        }
    }
}
