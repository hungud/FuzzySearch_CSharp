using FuzzySearch.dataCenter;
using FuzzySearch.tokenizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Diagnostics;

namespace FuzzySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            ITokenizer queryTokenizer = new ExactMatcher(new char[] { ' ' }, 0, 0);
            Index.start(new NGramSearcher(new char[] { ' ' }, 2, 50));
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Importer.AddDirectory("files");
            Console.WriteLine("preProcess finished In "+stopWatch.ElapsedMilliseconds);
            while (true)
            {
                string query = Console.ReadLine();
                if (query=="exit")
                    return;
                foreach (string queryToken in queryTokenizer.GetTokens(query))
                {
                    stopWatch.Reset();
                    Console.WriteLine("****" + queryToken);
                    SameStringBuilder sameStringBuilder = new SameStringBuilder(queryToken);
                    sameStringBuilder.ProduceSames(+1);
                    Console.WriteLine("Produce Sames Finished In "+stopWatch.ElapsedMilliseconds+" ms");
                    Console.WriteLine("Number Of Sames:" + sameStringBuilder.getSames().Count);
                    stopWatch.Reset();
                    Index.LookUp(sameStringBuilder.getSames());
                    Console.WriteLine("Look Up finished In "+stopWatch.ElapsedMilliseconds+" ms");
                }
            }
        }
    }
}
