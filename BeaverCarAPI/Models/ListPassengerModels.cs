using BeaverCarAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeaverCarAPI.Models
{
    public class ListPassengerModels
    {
        public ListPassengerModels(ListPassenger listPassenger)
        {
            id = listPassenger.id;
            UserID = listPassenger.UserID;
            PlaceUser = listPassenger.PlaceUser;
            TripID = listPassenger.TripID;
        }
        public int id { get; set; }
        public int UserID { get; set; }
        public System.Data.Entity.Spatial.DbGeography PlaceUser { get; set; }
        public int TripID { get; set; }
    }
}