using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T1_300982100.Models
{
    public interface IRepository
    {
        IQueryable<Car> GetCars { get; }
        void AddCar(Car car);
    }
}
