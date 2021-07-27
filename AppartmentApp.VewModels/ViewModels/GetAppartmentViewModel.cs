using AppartmentApp.VewModels.Models;
using System.Collections.Generic;


namespace AppartmentApp.VewModels.ViewModels
{
    public class GetAppartmentViewModel
    {
        public int AppartamentId { get; set; }
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

