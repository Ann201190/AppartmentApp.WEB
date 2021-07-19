using AppartmentApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AppartmentApp.DataAccess.Connection
{
   public class AppConnection
    {
        public string _connectionString = "server=ANUCELL\\SQLEXPRESS2019;database=Appartament;trusted_connection=true;";
    }
}
