using AppartmentApp.DataAccess.Connection;
using AppartmentApp.DataAccess.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Transactions;

namespace AppartmentApp.DataAccess.Repositories
{
    public class AppartmentsRepository
    {
        private readonly Connection.AppConnection _appContext;
        public AppartmentsRepository()
        {
            _appContext = new AppConnection();
        }
        public List<Appartament> Get()
        {
            using (var connection = new SqlConnection(_appContext._connectionString))
            {
                var sql = @"SELECT a.AppartamentId, a.Price, a.Name, a.RoomNumber, a.Area, i.InternetProviderId,  i.Name,ad.AdressId, ad.Country, ad.Region, ad.City, ad.Street, ad.HouseNumber,ad.AppartmentNumber, ad.EntranceNumber, i.InternetProviderId, t.AppartmentTypeId, t.NameType, am.AmenityId, am.Name FROM  Appartaments a 
                                   LEFT JOIN InternetProviders i  ON a.InternetProviderId = i.InternetProviderId
                                   LEFT JOIN Adresses ad ON a.AdressId = ad.AdressId
                                   LEFT JOIN AppartmentTypes t ON a.AppartmentTypeId = t.AppartmentTypeId
                                   LEFT JOIN AppartamentsAmenites aa ON a.AppartamentId = aa.AppartamentId
                                   LEFT JOIN Amenites am On am.AmenityId = aa.AmenityId";

                var data = connection.Query<Appartament, InternetProvider, Adress, AppartmentType, Amenity, Appartament>(sql, (appartament, internetProvider, adress, appartmentType, amenity) =>
                {
                    appartament.InternetProvider = internetProvider;
                    appartament.Adress = adress;
                    appartament.AppartmentType = appartmentType;
                    appartament.Amenites.Add(amenity);
                    return appartament;
                }, splitOn: "InternetProviderId, AdressId, AppartmentTypeId, AmenityId");

                var result = data.GroupBy(a => a.AppartamentId).Select(g =>
               {
                   var groupedAmenity = g.First();
                   groupedAmenity.Amenites = g.Select(a => a.Amenites.Single()).ToList();
                   return groupedAmenity;
               }).ToList();

                return result;
            }
        }

        public Appartament Get(int appartamentId)
        {
            using (var connection = new SqlConnection(_appContext._connectionString))
            {
                var data = connection.Query<Appartament, InternetProvider, Adress, AppartmentType, Amenity, Appartament>("GetAppartament",
                    (appartament, internetProvider, adress, appartmentType, amenity) =>
                {
                    appartament.InternetProvider = internetProvider;
                    appartament.Adress = adress;
                    appartament.AppartmentType = appartmentType;
                    appartament.Amenites.Add(amenity);
                    return appartament;
                },
                    new { AppartamentId = appartamentId },
                    splitOn: "InternetProviderId, AdressId, AppartmentTypeId, AmenityId",
                    commandType: CommandType.StoredProcedure).ToList();

                var result = data.GroupBy(a => a.AppartamentId).Select(g =>
                {
                    var groupedAmenity = g.First();
                    groupedAmenity.Amenites = g.Select(a => a.Amenites.Single()).ToList();
                    return groupedAmenity;
                }).FirstOrDefault();

                return result;
            }
        }

        public bool Put(Appartament appartament)
        {
            using (var connection = new SqlConnection(_appContext._connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var data = connection.Query<Appartament>("UpdateAppartament",
                    new
                    {
                        AppartamentId = appartament.AppartamentId,
                        Price = appartament.Price,
                        Name = appartament.Name,
                        RoomNumber = appartament.RoomNumber,
                        Area = appartament.Area,
                        InternetProviderId = appartament.InternetProvider.InternetProviderId,
                        Country = appartament.Adress.Country,
                        Region = appartament.Adress.Region,
                        City = appartament.Adress.City,
                        Street = appartament.Adress.Street,
                        HouseNumber = appartament.Adress.HouseNumber,
                        AppartmentTypeId = appartament.AppartmentType.AppartmentTypeId
                    },
                    commandType: CommandType.StoredProcedure, transaction: transaction);

                        StringBuilder stringBuilder = new StringBuilder();

                        if (appartament.Amenites != null)
                        {
                            stringBuilder.Append($@"DELETE from AppartamentsAmenites where AppartamentId = {appartament.AppartamentId}; ");
                            foreach (var a in appartament.Amenites)
                            {
                                stringBuilder.Append(@$"INSERT INTO AppartamentsAmenites ([AppartamentId], [AmenityId]) VALUES ({appartament.AppartamentId}, {a.AmenityId});");
                            }
                            connection.Execute(stringBuilder.ToString(), transaction: transaction);
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
                return true;
            }
        }
        public bool Post(Appartament appartament)
        {
            using (var connection = new SqlConnection(_appContext._connectionString))
            {
                appartament.Adress.AdressId = connection.QuerySingle<int>(@"INSERT INTO Adresses ([Country], [Region], [City], [AppartmentNumber], [HouseNumber], [EntranceNumber], [Street]) VALUES (@Country, @Region, @City, @AppartmentNumber, @HouseNumber, @EntranceNumber, @Street); SELECT CAST(SCOPE_IDENTITY() as int)",
                      new
                      {
                          Country = appartament.Adress.Country,
                          Region = appartament.Adress.Region,
                          City = appartament.Adress.City,
                          AppartmentNumber = appartament.Adress.AppartmentNumber,
                          HouseNumber = appartament.Adress.HouseNumber,
                          EntranceNumber = appartament.Adress.EntranceNumber,
                          Street = appartament.Adress.Street
                      });

                appartament.AppartamentId = connection.QuerySingle<int>(@"INSERT INTO Appartaments ([Price], [Name], [RoomNumber], [Area], [InternetProviderId], [AdressId], [AppartmentTypeId]) VALUES (@Price, @Name, @RoomNumber, @Area, @InternetProviderId, @AdressId, @AppartmentTypeId); SELECT CAST(SCOPE_IDENTITY() as int)",
                   new
                   {
                       Price = appartament.Price,
                       Name = appartament.Name,
                       RoomNumber = appartament.RoomNumber,
                       Area = appartament.Area,
                       InternetProviderId = appartament.InternetProvider.InternetProviderId,
                       AdressId = appartament.Adress.AdressId,
                       AppartmentTypeId = appartament.AppartmentType.AppartmentTypeId
                   });


                StringBuilder stringBuilder = new StringBuilder();

                foreach (var a in appartament.Amenites)
                {
                    stringBuilder.Append(@$"INSERT INTO AppartamentsAmenites ([AppartamentId], [AmenityId]) VALUES ({appartament.AppartamentId}, {a.AmenityId});");
                }
                connection.Execute(stringBuilder.ToString());


                if (appartament.AppartamentId!=null && appartament.AppartamentId!=null)
                {
                  return true;
                }
                else
                {
                    return false;
                }
            
            }
        }

    }
}