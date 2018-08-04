using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseAndScore
{
    //Class used to capture the output from stored records for display
    //The Tag Scores are sent as KV pairs about linked in the db.

    public class ResponseInfo
    {
        public int TotalScore { get; set; }

        public int MaxScore { get; set; }

        public int MinScore { get; set; }

        public double AverageScore { get; set; }

        public string ProcessingDate { get; set; }

        public string FileName { get; set; }

        public string Id { get; set; }

        public string Tag {get;set;}

        public string Score {get;set;}
    }
}
