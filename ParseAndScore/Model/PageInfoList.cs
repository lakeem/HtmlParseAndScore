using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseAndScore
{
    [Serializable]
    public class HtmlFileInfo
    {
        public List<KeyValuePair<string,int>> HtmlKeyValueList { get; set; }

        public int TotalScore { get; set; }

        public int MaxScore { get; set; }

        public int MinScore { get; set; }

        public double AverageScore { get; set; }
        
        public DateTime ProcessingDate { get; set; }
        
        public string FileName { get; set; }

        public int Id { get; set; }
    }
}
