using FuzzySearch.dataCenter;
using FuzzySearch.tokenizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Diagnostics;
using FuzzySearch.analysers;

namespace FuzzySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            ITokenizer tokenizer = new ExactMatcher(new char[] { ' ', ',', '-', '_', '#' });
            Index index = new Index(tokenizer);
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            long time = stopWatch.ElapsedMilliseconds;
            Importer importer = new Importer("files", index);
            Console.WriteLine("preProcess finished In " + (stopWatch.ElapsedMilliseconds - time) + " ms");
            FuzzyAnalyser analyser = new FuzzyAnalyser(tokenizer, index, +2);
            while (true)
            {
                string query = Console.ReadLine();
                if (query == "exit")
                    return;
                time = stopWatch.ElapsedMilliseconds;
                Dictionary<string, HashSet<string>> result = analyser.Analysis(query);
                Console.WriteLine("Look Up finished In " + (stopWatch.ElapsedMilliseconds - time) + " ms");
                foreach (string token in result.Keys)
                {
                    Console.WriteLine("** " + token + " :");
                    foreach (string filePath in result[token])
                    {
                        Console.WriteLine("    " + filePath);
                    }
                }
            }
        }
    }
}
