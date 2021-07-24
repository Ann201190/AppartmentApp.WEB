using AppartmentApp.VewModels.Adresses;
using AppartmentApp.VewModels.Amenites;
using AppartmentApp.VewModels.AppartmentTypes;
using AppartmentApp.VewModels.InternetProviders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppartmentApp.VewModels.Appartments
{
  public  class PostAppartmentViewModel
    {
        public int AppartamentId { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public int RoomNumber { get; set; }
        public float Area { get; set; }
        public int InternetProviderId { get; set; }
        public AdressModel Adress { get; set; }
        public int AppartmentTypeId { get; set; }
        public IEnumerable<int> AmenityId { get; set; } = new List<int>();
    }
}
