using System;
using System.Collections.Generic;
using System.Text;

namespace AppartmentApp.DataAccess.Entities
{
   public class Amenity:BaseEntities
    {
        public string Name { get; set; }
        public IEnumerable<Appartament> Appartaments { get; set; } = new List<Appartament>();
    }
}
