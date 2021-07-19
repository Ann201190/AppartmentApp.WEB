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


        /* public List<Appartament> Get()
         {
             using (var connection = new SqlConnection(_appContext._connectionString))
             {
                  var sql = @"SELECT a.AppartamentId, a.Price, a.Name, a.RoomNumber, a.Area , i.Name as InternetProvider FROM  Appartaments a JOIN InternetProviders i ON a.InternetProvider = i.InternetProvidersId";              

                  var data = connection.Query<Appartament, InternetProvider, Appartament>(sql, (appartament, internetProvider) => {appartament.InternetProvider = internetProvider;
                      return appartament; }, splitOn: "InternetProvidersId").ToList();
                 return data;
             }
         }*/

        public List<Appartament> Get()
        {
            using (var connection = new SqlConnection(_appContext._connectionString))
            {
                var sql = @"SELECT a.AppartamentId, a.Price, a.Name, a.RoomNumber, a.Area , i.Name as InternetProvider FROM  Appartaments a JOIN InternetProviders i ON a.InternetProvider = i.InternetProvidersId";

                var res = connection.Query<Appartament, InternetProvider, Appartament>(sql, (appartament, internetProvider) =>
                {
                    appartament.InternetProvider = internetProvider;
                    return appartament;
                }, splitOn: "InternetProvidersId");
            }

        }
         

        /*   public List<Appartament> Get()
           {
               List<Appartament> appartament = new List<Appartament>();
               try
               {
                   using (SqlConnection sqlConnection = new SqlConnection(_appContext._connectionString))
                   {
                       sqlConnection.Open();

                       using (SqlCommand command = new SqlCommand("Select * from Appartaments", sqlConnection))
                       {
                           using (SqlDataReader dataReader = command.ExecuteReader())
                           {
                               while (dataReader.Read())
                               {
                                   Appartament temp = new Appartament();
                                   temp.Id =Convert.ToInt32(dataReader.GetValue(0));
                                   temp.Price = Convert.ToSingle(dataReader.GetValue(1));
                                   temp.Name = dataReader.GetValue(2).ToString();
                                   temp.RoomNumber = Convert.ToInt32(dataReader.GetValue(3));
                                   temp.Area = Convert.ToSingle(dataReader.GetValue(4));
                                   temp.InternetProvider = (dataReader.GetValue(5) as InternetProvider);
                                   temp.Adress = (dataReader.GetValue(6) as Adress);
                                   temp.TypeOfAppartment = (dataReader.GetValue(7) as AppartmentType);
                                   appartament.Add(temp);
                               }
                               return appartament;
                           }
                       }
                   }
               }
               catch (Exception ex)
               {
                   throw new Exception(ex.Message);
               }
           }*/





        /* public async Task<List<Appartament>> Get()
         {

             using (SqlConnection connection = new SqlConnection())
             {
                 try
                 {
                     connection.ConnectionString = _appContext._connectionString;
                     connection.Open();
                 }
                 catch (Exception)
                 {
                     connection.Close();
                 }
                 SqlCommand command = new SqlCommand();
                 var result = await connection.QueryAsync<Appartament>("Select * from Appartaments", commandType: CommandType.Text);
                 return result.ToList();
             }
         }*/


    }
}



