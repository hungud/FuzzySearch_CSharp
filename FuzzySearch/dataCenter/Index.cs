using FuzzySearch.tokenizers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzySearch.dataCenter
{
    class Index
    {
        private static List<Index> indexes;
       
        private static tokenizers.ITokenizer tokenizer;
        private string filePath;
        private HashSet<string> tokens = new HashSet<string>();

        private Index(string fileName)
        {
            this.filePath = fileName;
        }

        public static void start(tokenizers.ITokenizer tokenizer)
        {
            Index.tokenizer = tokenizer;
            indexes = new List<Index>();
        }

        public static bool AddIndex(string fileName)
        {
            try
            {
                Index newIndex = new Index(fileName);
                newIndex.PreProcess();
                indexes.Add(newIndex);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public static void LookUp(HashSet<string> queryTokens)
        {
            foreach (Index index in indexes)
            {
                bool consists = false;
                foreach (string token in queryTokens)
                {
                    if (index.tokens.Contains(token))
                    {
                        consists = true;
                        break;
                    }
                }
                if (consists)
                {
                    Console.WriteLine(index.filePath);
                }
            }
        }

        public static ITokenizer getTokenizer()
        {
            return tokenizer;
        }

        private void PreProcess()
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach(string line in lines)
            {
                tokens.UnionWith(tokenizer.GetTokens(line));
            }
        }
    }
}
