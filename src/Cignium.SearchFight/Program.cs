using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.SearchFight.Core;

namespace App.SearchFight
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No terms were specified for the Search Fight. Please execute again with the search terms.");
                return;
            }

            Console.WriteLine("Executing Search Fight....");
            MainAsync(args).GetAwaiter().GetResult();
        }

        private static async Task MainAsync(IEnumerable<string> args)
        {
            await SearchFightKernel.ExecuteSearchFight(args.ToList());
            SearchFightKernel.Reports.ForEach(Console.WriteLine);            
        }
    }
}