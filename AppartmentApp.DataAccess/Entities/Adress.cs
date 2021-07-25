
namespace AppartmentApp.DataAccess.Entities
{
   public class Adress
    {
        public int AdressId { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string AppartmentNumber { get; set; }
        public string HouseNumber { get; set; }
        public string EntranceNumber { get; set; }
    }
}
