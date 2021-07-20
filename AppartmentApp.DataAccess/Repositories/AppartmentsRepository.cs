using AppartmentApp.DataAccess.Connection;
using AppartmentApp.DataAccess.Entities;
using Dapper;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                                    JOIN InternetProviders i  ON a.InternetProviderId = i.InternetProviderId
                                    JOIN Adresses ad ON a.AdressId = ad.AdressId
                                    JOIN AppartmentTypes t ON a.AppartmentTypeId = t.AppartmentTypeId
                                    JOIN AppartamentsAmenites aa ON a.AppartamentId = aa.AppartamentId
                                    JOIN Amenites am On am.AmenityId = aa.AmenityId";

                var data = connection.Query<Appartament, InternetProvider, Adress, AppartmentType, Amenity, Appartament>(sql, (appartament, internetProvider, adress, appartmentType, amenity) => {
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
    }
}



