using BeaverCarAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeaverCarAPI.Models
{
    public class CarModels
    {
        public CarModels (Car car)
        {
            id = car.id;
            Mark = car.Mark;
            Model = car.Model;
            YearProduction = car.YearProduction;
            CarPhoto = car.CarPhoto;
        }
        public int id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int YearProduction { get; set; }
        public byte[] CarPhoto { get; set; }
    }
}