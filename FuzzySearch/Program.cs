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
            long time=0;
            //Index.start(new NGramSearcher(new char[] { ' ' }, 2, 50));
            Index.start(new ExactMatcher(new char[] { ' ' }, 2, 50));
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            time = stopWatch.ElapsedMilliseconds;
            Importer.AddDirectory("files");
            Console.WriteLine("preProcess finished In "+ (stopWatch.ElapsedMilliseconds - time) + " ms");
            while (true)
            {
                string query = Console.ReadLine();
                if (query=="exit")
                    return;
                foreach (string queryToken in queryTokenizer.GetTokens(query))
                {
                    Console.WriteLine("****" + queryToken);
                    SameStringBuilder sameStringBuilder = new SameStringBuilder(queryToken);
                    time = stopWatch.ElapsedMilliseconds;
                    sameStringBuilder.ProduceSames(+2);
                    Console.WriteLine("Produce Sames Finished In "+(stopWatch.ElapsedMilliseconds-time) + " ms");
                    Console.WriteLine("Number Of Sames:" + sameStringBuilder.sames.Count);
                    time = stopWatch.ElapsedMilliseconds;
                    Index.LookUp(sameStringBuilder.sames);
                    Console.WriteLine("Look Up finished In "+(stopWatch.ElapsedMilliseconds-time) + " ms");
                }
            }
        }
    }
}
