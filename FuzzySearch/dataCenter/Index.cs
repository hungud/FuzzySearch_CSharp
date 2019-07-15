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
        private static Dictionary<string,HashSet<string>> listOfWordAddresses = new Dictionary<string, HashSet<string>>();
       
        private static ITokenizer tokenizer;
        private string filePath;

        private Index(string fileName)
        {
            this.filePath = fileName;
            if(true){
}
        }

        public static void start(tokenizers.ITokenizer tokenizer)
        {
            Index.tokenizer = tokenizer;
            //indexes = new List<Index>();
        }

        public static bool AddIndex(string fileName)
        {
            try
            {
                Index newIndex = new Index(fileName);
                newIndex.PreProcess();
                //indexes.Add(newIndex);
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
            foreach (string queryToken in queryTokens)
                {
                if(!listOfWordAddresses.ContainsKey(queryToken))
                    {
                        continue;
                    }
                foreach (string address in listOfWordAddresses[queryToken])
                    {
                    Console.WriteLine(queryToken+" found in file "+address);
                    }
                return;

                }
            /*
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
            */
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
                HashSet<string> newTokens = tokenizer.GetTokens(line);
                foreach(string newToken in newTokens)
                    {
                    if(!listOfWordAddresses.ContainsKey(newToken))
                    {
                        listOfWordAddresses[newToken] = new HashSet<string>();
                    }
                    listOfWordAddresses[newToken].Add(filePath);
                    }
                //tokens.UnionWith(newTokens);
            }
        }
    }
}
