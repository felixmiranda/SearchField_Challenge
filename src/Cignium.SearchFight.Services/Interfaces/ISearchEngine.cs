using System.Threading.Tasks;

namespace App.SearchFight.Services.Interfaces
{
    public interface ISearchEngine
    {
       
        string Name { get; }

       
        Task<long> GetTotalResultsAsync(string query);
    }
}
