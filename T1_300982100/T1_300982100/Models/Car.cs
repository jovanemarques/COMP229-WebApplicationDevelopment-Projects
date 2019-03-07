using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T1_300982100.Models
{
    public class Car
    {
        public string LicensePlate { get; set; }
        public string OwnerName { get; set; }
        public string OwnerAddress { get; set; }
        public string Make { get; set; }
        public Models Model { get; set; }
        public bool FourDoor{ get; set; }
        public bool Hybrid { get; set; }
        public bool FourWD { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
