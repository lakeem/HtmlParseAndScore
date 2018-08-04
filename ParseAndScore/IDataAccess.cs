using System;
using System.Collections.Generic;

namespace ParseAndScore
{
    public interface IDataAccess
    {
        List<ResponseInfo> GetAllScores();
        List<ResponseInfo> GetAllScoresFromDateRange(DateTime start, DateTime end);
        List<ResponseInfo> GetAllScoresFromFile(string fileName);
        void UpdateScoresCommand(HtmlFileInfo pageInfo);
        void UpdateScores_OldWay(HtmlFileInfo pageInfo);
    }
}