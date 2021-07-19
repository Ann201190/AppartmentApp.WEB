using AppartmentApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppartmentApp.VewModels.Appartments
{
    public class GetAppartmentModel //промежуточный класс мужду БД и пользователем
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public int RoomNumber { get; set; }
        public float Area { get; set; }
        public InternetProvider InternetProvider { get; set; }
        public Adress Adress { get; set; }
        public AppartmentType TypeOfAppartment { get; set; }
        public IEnumerable<Amenity> Amenites { get; set; } = new List<Amenity>();
    }
}

