using AppartmentApp.VewModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppartmentApp.VewModels.ViewModels
{
   public class GetAdressByAmenityViewModel
    {
        public int AmenityId { get; set; }
        public AdressModel Adress { get; set; }
    }
}
