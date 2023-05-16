using BeaverCarAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeaverCarAPI.Models
{
    public class TripModels
    {
        public TripModels(Trip trip) 
        {
            id = trip.id;
            Data = trip.Data;
            Price = trip.Price;
            DriverID = trip.DriverID;
            CountPlace = trip.CountPlace;
            StatusID = trip.StatusID;
            CreaterID = trip.CreaterID;
            StartPointLongitude = trip.StartPointLongitude;
            StartPointLatitude = trip.StartPointLatitude;
            EndPointLongitude = trip.EndPointLongitude;
            EndPointLatitude = trip.EndPointLatitude;
            Name = trip.Status.Name;
        }
        public int id { get; set; }
        public System.DateTime Data { get; set; }
        public decimal Price { get; set; }
        public string StartPointLongitude { get; set; }
        public string StartPointLatitude { get; set; }
        public string EndPointLongitude { get; set; }
        public string EndPointLatitude { get; set; }
        public Nullable<int> DriverID { get; set; }
        public Nullable<int> CountPlace { get; set; }
        public int StatusID { get; set; }
        public int CreaterID { get; set; }
        public string Name { get; set; }
    }
}