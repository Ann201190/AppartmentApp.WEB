using AppartmentApp.DataAccess.Entities;
using AppartmentApp.DataAccess.Repositories;
using AppartmentApp.VewModels.Models;
using AppartmentApp.VewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppartmentApp.Business.Services
{
    public class AmanitesService
    {
        private readonly AmenitiesRepository _amenitiesRepository;
        public AmanitesService(AmenitiesRepository appartmentrepository)
        {
            _amenitiesRepository = appartmentrepository;
        }

        public IEnumerable<GetAmenityViewModel> Get()
        {
              var amenites  = _amenitiesRepository.Get();
              var models = new List<GetAmenityViewModel>();

            foreach (var item in amenites)
            {
                models.Add(new GetAmenityViewModel
                {
                    AmenityId = item.AmenityId,
                    Name = item.Name
                });
            }

            return models;
        }


        public IEnumerable<GetAdressByAmenityViewModel> Get(int amenityId)
        {
            var adresses = _amenitiesRepository.Get(amenityId);
            var models = new List<GetAdressByAmenityViewModel>();

            foreach (var item in adresses)
            {
                models.Add(new GetAdressByAmenityViewModel
                {
                    AmenityId = amenityId,
                    Adress = new AdressModel
                    {
                        AdressId = item.AdressId,
                        City = item.City,
                        Country = item.Country,
                        Region = item.Region,
                        Street = item.Street,
                        AppartmentNumber = item.AppartmentNumber,
                        EntranceNumber = item.EntranceNumber,
                        HouseNumber = item.HouseNumber
                    },
                });
            }
            return models;
        }

        public bool Delete(int id)
        {
            return _amenitiesRepository.Delete(id);
        }

        public bool Put(PutAmenityViewModel putAmenityViewModel)
        {
            Amenity amenity = new Amenity()
            {
                AmenityId = putAmenityViewModel.AmenityId,
                Name = putAmenityViewModel.Name
            };

            return _amenitiesRepository.Put(amenity);
        }

        public bool Post(PostAmenityViewModel postAmenityViewModel)
        {
            Amenity amenity = new Amenity()
            {
                Name = postAmenityViewModel.Name
            };

           return _amenitiesRepository.Post(amenity);
        }
    }
}
