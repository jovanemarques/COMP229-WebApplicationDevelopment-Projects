using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T1_300982100.Models
{
    public class Repository : IRepository
    {
        private static List<Car> cars = new List<Car>();
        public void AddCar(Car car)
        {
            car.RegistrationDate = DateTime.Now;
            cars.Add(car);
        }
        public IQueryable<Car> GetCars
        {
            get
            {
                return (IQueryable<Car>)cars;
            }
        }
    }
}
