using System.Collections.Generic;

namespace AppartmentApp.DataAccess.Entities
{
   public class Appartament
    {
        public int AppartamentId { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public int RoomNumber { get; set; }
        public float Area { get; set; }
        public InternetProvider InternetProvider { get; set; }
        public Adress Adress { get; set; } 
        public AppartmentType AppartmentType { get; set; }
        public List<Amenity> Amenites { get; set; } = new List<Amenity>();
   }
}

