using AppartmentApp.DataAccess.Entities;
using AppartmentApp.DataAccess.Repositories;
using AppartmentApp.VewModels.Models;
using AppartmentApp.VewModels.ViewModels;
using System.Collections.Generic;

namespace AppartmentApp.Business.Services
{
    public class AppartmentsService 
    {
        private readonly AppartmentsRepository _appartmentrepository;
        public AppartmentsService(AppartmentsRepository appartmentrepository)
        {
            _appartmentrepository = appartmentrepository;
        }
        public IEnumerable<GetAppartmentViewModel> Get()
        {
            var appartments = _appartmentrepository.Get();
            var models = new List<GetAppartmentViewModel>();

            foreach (var item in appartments)
            {
                List<AmenityModel> amenityModel = new List<AmenityModel>();

                foreach (var i in item.Amenites)
                {
                    if (i != null)
                    {
                        amenityModel.Add(new AmenityModel
                        {
                            Name = i.Name,
                            AmenityId = i.AmenityId
                        });            
                    }           
                }
             
                models.Add(new GetAppartmentViewModel
                {
                    Id = item.AppartamentId,
                    Name = item.Name,
                    Area = item.Area,
                    Amenites = amenityModel,
                    Adress = new AdressModel
                    {
                        AdressId = item.Adress.AdressId,
                        City = item.Adress.City,
                        Country = item.Adress.Country,
                        Region = item.Adress.Region,
                        Street = item.Adress.Street,
                        AppartmentNumber = item.Adress.AppartmentNumber,
                        EntranceNumber = item.Adress.EntranceNumber,
                        HouseNumber = item.Adress.HouseNumber
                    },
                    InternetProvider = new InternetProviderModel
                    {
                        InternetProviderId = item.InternetProvider.InternetProviderId,
                        Name = item.InternetProvider.Name
                    },
                    Price = item.Price,
                    RoomNumber = item.RoomNumber,
                              

                    TypeOfAppartment = new AppartmentTepyModel
                    {
                        AppartmentTypeId = item.AppartmentType.AppartmentTypeId,
                        NameType = item.AppartmentType.NameType
                    },
                });
            }
            return models;
        }


        public GetAppartmentIdViewModel Get(int appartamentId)
        {
            var appartment = _appartmentrepository.Get(appartamentId);

            var model = new GetAppartmentIdViewModel();

            List<AmenityModel> amenityModel = new List<AmenityModel>();
            int amenityCount = 0;
            foreach (var i in appartment.Amenites)
            {
                if (i != null)
                {
                    amenityModel.Add(new AmenityModel
                    {
                        Name = i.Name,
                        AmenityId = i.AmenityId
                    });
                    amenityCount = appartment.Amenites.Count;
                }
            }
      
            model = new GetAppartmentIdViewModel
            {
                Id = appartment.AppartamentId,
                Name = appartment.Name,
                Area = appartment.Area,
                Amenites = amenityModel,
                Adress = new AdressModel
                {
                    AdressId = appartment.Adress.AdressId,
                    City = appartment.Adress.City,
                    Country = appartment.Adress.Country,
                    Region = appartment.Adress.Region,
                    Street = appartment.Adress.Street,
                    AppartmentNumber = appartment.Adress.AppartmentNumber,
                    EntranceNumber = appartment.Adress.EntranceNumber,
                    HouseNumber = appartment.Adress.HouseNumber
                },
                InternetProvider = new InternetProviderModel
                {
                    InternetProviderId = appartment.InternetProvider.InternetProviderId,
                    Name = appartment.InternetProvider.Name
                },

                Price = appartment.Price,
                RoomNumber = appartment.RoomNumber,

                TypeOfAppartment = new AppartmentTepyModel
                {
                    AppartmentTypeId = appartment.AppartmentType.AppartmentTypeId,
                    NameType = appartment.AppartmentType.NameType
                },

                AmenityCount = amenityCount

            };

            return model;
        }

   

        public bool Post(PostAppartmentViewModel postAppartmentModel)
        {
            AppartmentType appartmentType = new AppartmentType();
            appartmentType.AppartmentTypeId = postAppartmentModel.AppartmentTypeId;

            InternetProvider internetProvider = new InternetProvider();
            internetProvider.InternetProviderId = postAppartmentModel.InternetProviderId;

            Adress adress = new Adress()
            {
                City = postAppartmentModel.Adress.City,
                Country = postAppartmentModel.Adress.Country,
                Region = postAppartmentModel.Adress.Region,
                Street = postAppartmentModel.Adress.Street,
                AppartmentNumber = postAppartmentModel.Adress.AppartmentNumber,
                EntranceNumber = postAppartmentModel.Adress.EntranceNumber,
                HouseNumber = postAppartmentModel.Adress.HouseNumber
            };

            List<Amenity> amenity = new List<Amenity>();
            foreach (var a in postAppartmentModel.AmenityId)
            {
                amenity.Add(new Amenity()
                {
                    AmenityId = a,
                });
            }


         
            Appartament appartament = new Appartament()
            {
                Name = postAppartmentModel.Name,
                Area = postAppartmentModel.Area,
                Price = postAppartmentModel.Price,
                RoomNumber = postAppartmentModel.RoomNumber,
                Amenites = amenity,
                Adress = adress,
                AppartmentType = appartmentType,
                InternetProvider = internetProvider,
            };
            return _appartmentrepository.Post(appartament);
        }
    }
}
