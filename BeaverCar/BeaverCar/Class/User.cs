using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace BeaverCar.Class
{
    public class User
    {      
            public int id { get; set; }
            public string Name { get; set; }
            public string SecondName { get; set; }
            public string Surname { get; set; }
            public string PhoneNumber { get; set; }
            public object Photo { get; set; }
            public object CarID { get; set; }
            public bool Type { get; set; }
            public float Rating { get; set; }

        //public ImageSource PhotoUser //Должно подгружать фото 
        //{
        //    get
        //    {
        //        return ImageSource.FromStream(() = new MemoryStream(Convert.FromBase64String(Photo)));
        //    }
        //}
    }
}
