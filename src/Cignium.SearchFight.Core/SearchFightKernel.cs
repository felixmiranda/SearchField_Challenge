using System.Threading.Tasks;
using System.Collections.Generic;
using App.SearchFight.Core.Impl;
using App.SearchFight.Core.Models;
using App.SearchFight.Core.Interfaces;


namespace App.SearchFight.Core
{
    public static class SearchFightKernel
    {
        #region Attributes

        public static List<string> Reports { get; private set; }

        #endregion

        #region Services

        static readonly ISearchManager SearchManager;
        static readonly IWinnerManager WinnerManager;
        static readonly IReportManager ReportManager;

        #endregion

        #region Constructors

        static SearchFightKernel()
        {
            
            SearchManager = new SearchManager();
            WinnerManager = new WinnerManager();
            ReportManager = new ReportManager();


            Reports = new List<string>();
        }

        #endregion

        #region Public Methods

        public static async Task ExecuteSearchFight(IList<string> terms)
        {
            var searchData = await SearchManager.GetSearchResults(terms);
            var searchEngineWinners = WinnerManager.GetSearchEngineWinners(searchData);
            var grandWinner = WinnerManager.GetGrandWinner(searchData);

            Reports.AddRange(ReportManager.GetSearchResultsReport(searchData));
            Reports.AddRange(ReportManager.GetWinnersReport(searchEngineWinners));
            Reports.Add(ReportManager.GetGrandWinnerReport(grandWinner));
        }

        #endregion
    }
}
