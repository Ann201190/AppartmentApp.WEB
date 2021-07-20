using AppartmentApp.DataAccess.Repositories;
using AppartmentApp.VewModels.Appartments;
using System;
using System.Collections.Generic;
using System.Text;


namespace AppartmentApp.Business.Services
{
  public  class AppartmentsService
    {
        private readonly AppartmentsRepository _appartmentrepository;
        public AppartmentsService(AppartmentsRepository appartmentrepository)
        {
            _appartmentrepository = appartmentrepository;
        }
        public IEnumerable<GetAppartmentModel> Get()
        {
            var appartments = _appartmentrepository.Get();
            var models = new List<GetAppartmentModel>();
            foreach (var item in appartments)
            {
                models.Add(new GetAppartmentModel
                {
                    Id = item.AppartamentId,
                    Name = item.Name,
                    Area = item.Area,
                    Amenites = item.Amenites,
                    Adress = item.Adress,
                    InternetProvider = item.InternetProvider,
                    Price = item.Price,
                    RoomNumber = item.RoomNumber,
                    TypeOfAppartment = item.AppartmentType
                });
            }
            return models;
        }
    }
}
