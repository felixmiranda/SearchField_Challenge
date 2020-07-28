using System.Collections.Generic;
using App.SearchFight.Core.Models;

namespace App.SearchFight.Core.Interfaces
{
    public interface IReportManager
    {
        
        IList<string> GetSearchResultsReport(IList<Search> searchData);

        
        IList<string> GetWinnersReport(IEnumerable<SearchEngineWinner> engineWinners);

        
        string GetGrandWinnerReport(SearchEngineWinner grandWinner);
    }
}
