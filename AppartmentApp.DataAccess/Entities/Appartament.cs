using System;
using System.Collections.Generic;
using System.Text;

namespace AppartmentApp.DataAccess.Entities
{
   public class Appartament:BaseEntities
    {
        public double Price { get; set; }
        public string Name { get; set; }
        public int RoomNumber { get; set; }
        public float Area { get; set; }
        public IEnumerable<Amenity> Amenites { get; set; } = new List<Amenity>();
        public AppartmentType TypeOfAppartment { get; set; }
        public InternetProvider InternetProvider { get; set; }
        public Adress Adress { get; set; }
    }
}
