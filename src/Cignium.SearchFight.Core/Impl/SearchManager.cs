using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using App.SearchFight.Core.Models;
using App.SearchFight.Services.Impl;
using App.SearchFight.Core.Interfaces;
using App.SearchFight.Services.Interfaces;

namespace App.SearchFight.Core.Impl
{
    public class SearchManager : ISearchManager
    {
        #region Attributes
        
        private readonly IList<ISearchEngine> _searchEngines;

        #endregion

        #region Constructors
                
        public SearchManager()
        {
            _searchEngines = GetImplementedSearchEngines();
        }

        #endregion

        #region Private Methods

        private static IList<ISearchEngine> GetImplementedSearchEngines()
        {            
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                ?.Where(assembly => assembly.FullName.StartsWith("App.SearchFight"));

            return loadedAssemblies
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.GetInterface(typeof(ISearchEngine).ToString()) != null)
                .Select(type => Activator.CreateInstance(type) as ISearchEngine).ToList();
        }

        #endregion

        #region Public Methods

        public async Task<IList<Search>> GetSearchResults(IList<string> terms)
        {
            if (terms == null || !terms.Any())
                throw new ArgumentException("The specified argument is invalid.", nameof(terms));

            IList<Search> results = new List<Search>();

            foreach (var engine in _searchEngines)
            {
                foreach (var term in terms)
                {
                    results.Add(new Search
                    {
                        SearchEngine = engine.Name,
                        Term = term,
                        Results = await engine.GetTotalResultsAsync(term)
                    });
                }
            }

            return results;
        }

        #endregion
    }
}
