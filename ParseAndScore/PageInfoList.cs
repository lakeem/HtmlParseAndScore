using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseAndScore
{
    public class PageInfoList
    {

        public List<KeyValuePair<string,int>> htmlKeyValueList { get; set; }

        public int totalValue { get; set; }
    }
}
