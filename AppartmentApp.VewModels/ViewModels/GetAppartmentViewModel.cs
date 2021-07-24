using AppartmentApp.DataAccess.Entities;
using AppartmentApp.VewModels.Adresses;
using AppartmentApp.VewModels.Amenites;
using AppartmentApp.VewModels.AppartmentTypes;
using AppartmentApp.VewModels.InternetProviders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppartmentApp.VewModels.Appartments
{
    public class GetAppartmentViewModel
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public int RoomNumber { get; set; }
        public float Area { get; set; }
        public InternetProviderModel InternetProvider { get; set; }
        public AdressModel Adress { get; set; }
        public AppartmentTepyModel TypeOfAppartment { get; set; }
        public IEnumerable<AmenityModel> Amenites { get; set; } = new List<AmenityModel>();
    }
}

