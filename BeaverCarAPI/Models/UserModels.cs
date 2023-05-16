using BeaverCarAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeaverCarAPI.Models
{
    public class UserModels
    {
        public UserModels (User user)
        {
            id = user.id;
            Name = user.Name;
            SecondName = user.SecondName;
            Surname = user.Surname;
            PhoneNumber = user.PhoneNumber;
            Photo = user.Photo;
            CarID = user.CarID;
            IsDriver = user.IsDriver;
            Rating = user.Rating;
        }
        public int id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] Photo { get; set; }
        public Nullable<int> CarID { get; set; }
        public bool IsDriver { get; set; }
        public double Rating { get; set; }
    }
}