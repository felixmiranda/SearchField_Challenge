using System;
using System.Linq;
using System.Collections.Generic;
using App.SearchFight.Shared;
using App.SearchFight.Core.Models;
using App.SearchFight.Core.Interfaces;

namespace App.SearchFight.Core.Impl
{
    public class WinnerManager : IWinnerManager
    {
        public SearchEngineWinner GetGrandWinner(IList<Search> searchData)
        {
            if (searchData == null || !searchData.Any())
                throw new ArgumentException("The specified argument is invalid.", nameof(searchData));

            var searchWinner = searchData.GetMax(item => item.Results);
            return new SearchEngineWinner() { Engine = searchWinner.SearchEngine, Term = searchWinner.Term };
        }

        public IEnumerable<SearchEngineWinner> GetSearchEngineWinners(IList<Search> searchData)
        {
            if (searchData == null || !searchData.Any())
                throw new ArgumentException("The specified argument is invalid.", nameof(searchData));

            var searchEngines = searchData.GroupBy(data => data.SearchEngine,
                result => result, (searchEngine, results) => new SearchEngineWinner
                {
                    Engine = searchEngine,
                    Term = results.GetMax(item => item.Results).Term
                });

            return searchEngines;
        }
    }
}
