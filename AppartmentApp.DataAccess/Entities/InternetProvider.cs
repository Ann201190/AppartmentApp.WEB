using System;
using System.Collections.Generic;
using System.Text;

namespace AppartmentApp.DataAccess.Entities
{
  public class InternetProvider:BaseEntities
    {
        public string Name { get; set; }
        public ICollection<Appartament> Appartaments { get; set; }
    }
}
