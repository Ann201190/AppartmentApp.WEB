using AppartmentApp.DataAccess.Connection;
using AppartmentApp.DataAccess.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AppartmentApp.DataAccess.Repositories
{
    public class AmenitiesRepository
    {
        private readonly AppConnection _appContext;
        public AmenitiesRepository()
        {
            _appContext = new AppConnection();
        }

        public IEnumerable<Amenity> Get()
        {
            using (var connection = new SqlConnection(_appContext._connectionString))
            {
                var result = connection.Query<Amenity>("GetAmenites", commandType: CommandType.StoredProcedure);
                return result;
            }            
        }

        public IEnumerable<Adress> Get(int amenityId)
        {
            using (var connection = new SqlConnection(_appContext._connectionString))
            {
                var result = connection.Query<Adress>("GetAdressByAmenityId", new { AmenityId = amenityId }, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public bool Post(Amenity amenity)
        {
            using (var connection = new SqlConnection(_appContext._connectionString))
            {
                var result = connection.Query<Adress>("PostAmenity", new { Name = amenity.Name }, commandType: CommandType.StoredProcedure);         
            }
            return true;
        }

        public bool Put(Amenity amenity)
        {
            using (var connection = new SqlConnection(_appContext._connectionString))
            {
                var result = connection.Query<Adress>("PutAmenity", new { AmenityId= amenity.AmenityId, Name = amenity.Name }, commandType: CommandType.StoredProcedure);
            }
            return true;
        }

        public bool Delete(int Id)
        {
            using (var connection = new SqlConnection(_appContext._connectionString))
            {
                var result = connection.Query<Adress>("DeleteAmenity", new { AmenityId = Id}, commandType: CommandType.StoredProcedure);
            }
            return true;
        }
    }
}
