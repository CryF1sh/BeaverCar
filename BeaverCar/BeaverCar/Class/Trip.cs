using System;
using System.Collections.Generic;
using System.Text;

namespace BeaverCar.Class
{
    public class Trip
    {
            public int id { get; set; }
            public DateTime Data { get; set; }
            public float Price { get; set; }
            public string StartPointLongitude { get; set; }
            public string StartPointLatitude { get; set; }
            public string EndPointLongitude { get; set; }
            public string EndPointLatitude { get; set; }
            public int? DriverID { get; set; }
            public int? CountPlace { get; set; }
            public int StatusID { get; set; }
            public int CreaterID { get; set; }
        public string StritBegin { get; set; }
        public string StritEnd { get; set; }

    }
}
