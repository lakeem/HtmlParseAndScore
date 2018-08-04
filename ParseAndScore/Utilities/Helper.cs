using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseAndScore
{
    public static class Helper
    {
        public static string GetConnection(string connectionName)
        {        
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        //Strings for database call etc 
        public static string getAllRecordsInDatabase = "dbo.uspGetAllScoresInDatabase";
        public static string GetAllScoresFromFile = "dbo.uspGetAllScoresFromFile";
        public static string GetAllScoresFromDateRange = "dbo.uspGetAllScoresFromDateRange";
        public static string uspUpdateCommand = "dbo.uspUpdateCommandII";
    }



}
