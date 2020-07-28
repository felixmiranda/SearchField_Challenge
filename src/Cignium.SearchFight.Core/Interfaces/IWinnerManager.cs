using System.Collections.Generic;
using App.SearchFight.Core.Models;

namespace App.SearchFight.Core.Interfaces
{
    public interface IWinnerManager
    {
        
        IEnumerable<SearchEngineWinner> GetSearchEngineWinners(IList<Search> searchData);

        
        SearchEngineWinner GetGrandWinner(IList<Search> searchData);
    }
}
