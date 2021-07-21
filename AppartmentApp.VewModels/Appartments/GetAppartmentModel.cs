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
    public class GetAppartmentModel
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public int RoomNumber { get; set; }
        public float Area { get; set; }
        public GetInternetProviderModel InternetProvider { get; set; }
        public GetAdressModel Adress { get; set; }
        public GetAppartmentTypeModel TypeOfAppartment { get; set; }
        public IEnumerable<GetAmenityModel> Amenites { get; set; } = new List<GetAmenityModel>();
    }
}

