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
using System.IO;
using Newtonsoft.Json;

namespace FuzzySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            ITokenizer tokenizer = new ExactMatcher(new char[] { ' ', ',', '-', '_', '#' });
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            long time;
            Index index = readDataBase("data.txt");
            FuzzyAnalyser analyser = new FuzzyAnalyser(tokenizer, index, +2);
            while (true)
            {
                string query = Console.ReadLine();
                if (query == "exit")
                    return;
                if (query == "update")
                {
                    updateDataBase(tokenizer, "files","data.txt");
                    index = readDataBase("data.txt");
                    analyser = new FuzzyAnalyser(tokenizer, index, +2);
                    continue;
                }
                time = stopWatch.ElapsedMilliseconds;
                Dictionary<string, HashSet<string>> result = analyser.Analysis(query);
                Console.WriteLine("Analysis finished In " + (stopWatch.ElapsedMilliseconds - time) + " ms");
                printQueryResult(result);
            }
        }

        static void updateDataBase(ITokenizer tokenizer,string path,string fileName)
        {
            Index index = new Index(tokenizer);
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            long time = stopWatch.ElapsedMilliseconds;
            Importer importer = new Importer(path, index);
            Console.WriteLine("Process dataBase finished in " + (stopWatch.ElapsedMilliseconds - time) + " ms.");
            time = stopWatch.ElapsedMilliseconds;
            File.WriteAllText(fileName, JsonConvert.SerializeObject(index));
            Console.WriteLine("Writing to file finished in " + (stopWatch.ElapsedMilliseconds - time) + " ms");
        }

        static Index readDataBase(string fileName)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            string text = File.ReadAllText(fileName);
            Index index = JsonConvert.DeserializeObject<Index>(text);
            stopWatch.Stop();
            Console.WriteLine("Deserialize date in " + stopWatch.ElapsedMilliseconds + " ms.");
            return index;
        }

        static void printQueryResult(Dictionary<string, HashSet<string>> result)
        {
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
