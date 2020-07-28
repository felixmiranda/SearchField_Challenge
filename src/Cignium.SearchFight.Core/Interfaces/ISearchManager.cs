using System.Threading.Tasks;
using System.Collections.Generic;
using App.SearchFight.Core.Models;

namespace App.SearchFight.Core.Interfaces
{
    public interface ISearchManager
    {
        
        Task<IList<Search>> GetSearchResults(IList<string> terms);
    }
}
