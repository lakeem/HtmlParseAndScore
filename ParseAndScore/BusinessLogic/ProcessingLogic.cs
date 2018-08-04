using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace ParseAndScore
{
    public class ProcessingLogic
    {
        IDataAccess _dataAccess;

        public ProcessingLogic(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public HtmlFileInfo ProcessingFile(string filePath)
        {

            var htmlDoc = getFileFromPath(filePath);
            var scoreTable = new ScoreSet();
            var pageInfoList = new HtmlFileInfo(); 
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

            pageInfoList.FileName = Path.GetFileName(filePath);
            pageInfoList.ProcessingDate = DateTime.Now;

            try
            {
                _dataAccess.UpdateScores_OldWay(pageInfoList);
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
                results = _dataAccess.GetAllScoresFromFile(fileName);
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
                results = _dataAccess.GetAllScoresFromDateRange(startDate, endDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error occured updating the database {0}", ex.Message);
                throw;
            }
            return results;
        }

        public List<ResponseInfo> RetrieveAllScores()
        {
            var results = new List<ResponseInfo>();
            try
            {
                results = _dataAccess.GetAllScores();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error occured updating the database {0}", ex.Message);
                throw;
            }
            return results;
        }

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
            var doc = new HtmlDocument();
            doc.Load(filePath);
            return doc;
        }

    }
}
