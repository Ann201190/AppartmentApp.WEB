using AppartmentApp.VewModels.Models;
using System.Collections.Generic;


namespace AppartmentApp.VewModels.ViewModels
{
  public  class PostAppartmentViewModel
    {
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
