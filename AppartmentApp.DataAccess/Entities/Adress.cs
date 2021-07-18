using System;
using System.Collections.Generic;
using System.Text;

namespace AppartmentApp.DataAccess.Entities
{
   public class Adress:BaseEntities
    {
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string ApartmentNumber { get; set; }
        public string HouseNumber { get; set; }
        public string EntranceNumber { get; set; }       
    }
}
