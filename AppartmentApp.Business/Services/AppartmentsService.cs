using AppartmentApp.DataAccess.Entities;
using AppartmentApp.DataAccess.Repositories;
using AppartmentApp.VewModels.Adresses;
using AppartmentApp.VewModels.Amenites;
using AppartmentApp.VewModels.Appartments;
using AppartmentApp.VewModels.AppartmentTypes;
using AppartmentApp.VewModels.InternetProviders;
using System;
using System.Collections.Generic;
using System.Text;


namespace AppartmentApp.Business.Services
{
    public class AppartmentsService ///
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
               List<GetAmenityModel> amenityModel = new List <GetAmenityModel>();
               
                foreach (var i in item.Amenites)
                {
                    amenityModel.Add(new GetAmenityModel
                    { 
                        Name = i.Name, 
                        AmenityId = i.AmenityId
                    });
                }

                models.Add(new GetAppartmentModel
                {
                    Id = item.AppartamentId,
                    Name = item.Name,
                    Area = item.Area,
                    Amenites = amenityModel,
                    Adress = new GetAdressModel
                    {
                        City = item.Adress.City,
                        Country = item.Adress.Country,
                        Region = item.Adress.Region,
                        Street = item.Adress.Street,
                        AppartmentNumber = item.Adress.AppartmentNumber,
                        EntranceNumber = item.Adress.EntranceNumber,
                        HouseNumber = item.Adress.HouseNumber
                    },
                    InternetProvider = new GetInternetProviderModel
                    {
                        Name = item.InternetProvider.Name
                    },
                    Price = item.Price,
                    RoomNumber = item.RoomNumber,

                    TypeOfAppartment = new GetAppartmentTypeModel
                    {
                        NameType = item.AppartmentType.NameType
                    }
                });
            }
            return models;
        }   
    }
}
