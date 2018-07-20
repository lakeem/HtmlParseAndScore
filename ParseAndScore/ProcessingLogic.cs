using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseAndScore
{
    //todo set up for dependancy injection
    public class ProcessingLogic
    {
        public ProcessingLogic()
        {
        }

        public PageInfoList ProcessingFile(string filePath)
        {

            //read in html doc
            
            var htmlDoc = getFileFromPath(filePath);
            //create or load the set of KV info for tag values
            var scoreTable = new ScoreSet();
            var pageInfoList = new PageInfoList();
            pageInfoList.htmlKeyValueList = new List<KeyValuePair<string, int>>();


            //add an if block to check if record has been updated
   

            //if no-make a db call & display()
            //if yes - extract and store



            foreach (var kv in scoreTable.ScoreTable)
            {

                //if the key is in the doc...
                //then get a count of how many are in the doc
                var tagScore = GetTagCount(htmlDoc, kv);
                pageInfoList.htmlKeyValueList.Add(tagScore);        
                
            }
            pageInfoList.totalValue = TotalTagScore(pageInfoList.htmlKeyValueList);
            //TODO store in Database


            return pageInfoList;
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



        private static HtmlDocument getFileFromPath(string filePath)
        {
            var path = filePath + @".html";
            var doc = new HtmlDocument();
            doc.Load(path);
            return doc;
        }


        private static int TotalTagScore(List<KeyValuePair<string, int>> kvList)
        {
            var total = 0;
            foreach (var item in kvList)
            {
                total = total + item.Value;
            }
            return total;
        }
    }
}
