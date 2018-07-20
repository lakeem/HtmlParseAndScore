using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseAndScore
{
    public class ScoreSet
    {
        //Hardcoded for now, this could be replaced with reading values 
        //from a config file and manager depending on the app usage
        public Dictionary<string, int> ScoreTable
        {
            get
            {
                var table = new Dictionary<string, int>();
                table.Add("div", 3);
                table.Add("p", 1);
                table.Add("h1", 3);
                table.Add("h2", 2);
                table.Add("html", 1);
                table.Add("body", 5);
                table.Add("header", 10);
                table.Add("footer", 10);
                table.Add("font", -1);
                table.Add("center", -2);
                table.Add("big", -2);
                table.Add("strike", -1);
                table.Add("tt", -1);
                table.Add("frameset", -5);
                table.Add("frame", -5);
                return table;
            }
        }
    }
}
