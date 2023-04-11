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
            public string StartPoint { get; set; }
            public string EndPoint { get; set; }
            public int? DriverID { get; set; }
            public int? CountPlace { get; set; }
            public int StatusID { get; set; }
            public int CreaterID { get; set; }

    }
}
