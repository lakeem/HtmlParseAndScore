using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Tvp;
using Microsoft.SqlServer.Server;

namespace ParseAndScore
{
   public  class DataAccess : IDataAccess
    {
        public List<ResponseInfo> GetAllScoresFromFile(string fileName)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnection("TestingDatabaseI")))
            {
                var output= connection.Query<ResponseInfo>(Helper.GetAllScoresFromFile + " @FileName", new { FileName = fileName}).ToList();
                return output;
            }            
        }

        public List<ResponseInfo> GetAllScoresFromDateRange(DateTime start, DateTime end)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnection("TestingDatabaseI")))
            {
                var output = connection.Query<ResponseInfo>(Helper.GetAllScoresFromDateRange +" @startDate, @endDate ",
                    new { startDate = start, endDate = end } ).ToList();
                return output;
            }
        }

        public List<ResponseInfo> GetAllScores()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnection("TestingDatabaseI")))
            {
                var output = connection.Query<ResponseInfo>(Helper.getAllRecordsInDatabase).ToList();
                return output;
            }
        }

        public void UpdateScoresCommand(HtmlFileInfo pageInfo)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.GetConnection("TestingDatabaseI")))
            {
                HtmlFileInfo newInfo = new HtmlFileInfo { AverageScore = pageInfo.AverageScore, FileName= pageInfo.FileName,
                 MaxScore = pageInfo.MaxScore, MinScore = pageInfo.MinScore,
                   ProcessingDate = pageInfo.ProcessingDate, TotalScore = pageInfo.TotalScore};
                List<HtmlFileInfo> pageList = new List<HtmlFileInfo>();
                pageList.Add(newInfo);
                connection.Execute("dbo.uspUpdateCommand @AverageScore, @FileName, @MaxScore, @MinScore, @ProcessingDate, @TotalScore", 
                      pageList);
            }
        }

        public void UpdateScores_OldWay(HtmlFileInfo pageInfo)
        {
            var cs = Helper.GetConnection("TestingDatabaseI");
            using (SqlConnection con = new SqlConnection(cs) )
            {
                SqlCommand cmd = new SqlCommand("dbo.uspUpdateCommandII", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@HtmlKeyValueList";
                param.Value = CreateHtmlDataTatalbe(pageInfo.HtmlKeyValueList);
                param.TypeName = "TagScoreTableType";
                cmd.Parameters.Add(param);
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@AverageScore", Value = pageInfo.AverageScore });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@FileName", Value = pageInfo.FileName });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@MaxScore", Value = pageInfo.MaxScore });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@MinScore", Value = pageInfo.MinScore });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@ProcessingDate", Value = pageInfo.ProcessingDate });
                cmd.Parameters.Add(new SqlParameter { ParameterName = "@TotalScore", Value = pageInfo.TotalScore });

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }


        //TODO debug the Dapper tv functionality next time you're bored
        private static  List<SqlDataRecord> DataTalbeConverstion(List<KeyValuePair<string, int>> list)
        {
            var htmlKVTagValues = new List<SqlDataRecord>();
            var myMetaData = new SqlMetaData[] { new SqlMetaData("Tag", SqlDbType.VarChar), new SqlMetaData("Score", SqlDbType.Int) };
            foreach (var item in list)
            {
                var record = new SqlDataRecord(myMetaData);
                record.SetString(0, item.Key);
                record.SetInt32(0, item.Value);
                htmlKVTagValues.Add(record);
            }
            return htmlKVTagValues;
        }


        //Helper for the datatable old way
        private static DataTable CreateHtmlDataTatalbe(List<KeyValuePair<string,int>> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Score");
            dt.Columns.Add("Tag");
            foreach (var item in list)
            {
                dt.Rows.Add(item.Key, item.Value);
            }
            return dt;
        }
    }
}
