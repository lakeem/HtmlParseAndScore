using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseAndScore
{
    public class ProcessingLogic
    {
        public ProcessingLogic()
        {
        }

        //TODO change output to a bool or void
        public PageInfoList ProcessingFile(string filePath)
        {

            var htmlDoc = getFileFromPath(filePath);
            var scoreTable = new ScoreSet();
            var pageInfoList = new PageInfoList(); 
            pageInfoList.HtmlKeyValueList = new List<KeyValuePair<string, int>>();

            foreach (var kv in scoreTable.ScoreTable)
            {
                var tagScore = GetTagCount(htmlDoc, kv);
                pageInfoList.HtmlKeyValueList.Add(tagScore);                        
            }
            pageInfoList.TotalScore = GetTotalScore(pageInfoList.HtmlKeyValueList);
            pageInfoList.MaxScore = GetMaxScore(pageInfoList.HtmlKeyValueList);
            pageInfoList.MinScore = GetMinScore(pageInfoList.HtmlKeyValueList);
            pageInfoList.AverageScore = GetAverageScore(pageInfoList.HtmlKeyValueList);
            pageInfoList.FileName = filePath;
            pageInfoList.ProcessingDate = DateTime.Now;

            try
            {
                var storeValues = new DataAccess();
                storeValues.UpdateScores_OldWay(pageInfoList);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error occured updating the database {0}", ex.Message );
                throw;
            }
            return pageInfoList;
        }

        public List<ResponseInfo> RetrieveHtmlScores(string fileName)
        {
            var results = new List<ResponseInfo>();
            try
            {
                var storeValues = new DataAccess();
                results = storeValues.GetAllScoresFromFile(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error occured updating the database {0}", ex.Message);
                throw;
            }
            return results;

        }

        public List<ResponseInfo> RetrieveScoresByDateRange(string start, string end)
        {
            var startDate = DateTime.Parse(start);
            var endDate = DateTime.Parse(end);
            var results = new List<ResponseInfo>();
            try
            {
                var storeValues = new DataAccess();
                results = storeValues.GetAllScoresFromDateRange(startDate, endDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error occured updating the database {0}", ex.Message);
                throw;
            }
            return results;
        }



        public void RetrieveAllScores(string start, string end)
        {
            var startDate = DateTime.Parse(start);
            var endDate = DateTime.Parse(end);
            var results = new List<ResponseInfo>();
            try
            {
                var storeValues = new DataAccess();
                results = storeValues.GetAllScores();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error occured updating the database {0}", ex.Message);
                throw;
            }
        }

        //Place in Helper class when done
        private static KeyValuePair<string,int> GetTagCount(HtmlDocument topNode, KeyValuePair<string, int> skv)
        {
            var nodeCount = 0;
            var testCount = topNode.DocumentNode.Descendants();
            foreach (var item in testCount)
            {
                if (item.OriginalName == skv.Key)
                {
                    nodeCount++;
                }
            }
            var tagValue = new KeyValuePair<string, int>(skv.Key, nodeCount * skv.Value);
            return tagValue;
        }

        private static int GetMaxScore(List<KeyValuePair<string, int>> kvList)
        {
           
            return kvList.Select(x => x.Value).Max();
        }

        private static int GetMinScore(List<KeyValuePair<string, int>> kvList)
        {

            return kvList.Select(x => x.Value).Min();
        }

        private static double GetAverageScore(List<KeyValuePair<string, int>> kvList)
        {

            return kvList.Select(x => x.Value).Average();
        }

        private static int GetTotalScore(List<KeyValuePair<string, int>> kvList)
        {

            return kvList.Select(x => x.Value).Sum();
        }

        private static HtmlDocument getFileFromPath(string filePath)
        {
            var path = filePath + @".html";
            var doc = new HtmlDocument();
            doc.Load(path);
            return doc;
        }

    }
}
