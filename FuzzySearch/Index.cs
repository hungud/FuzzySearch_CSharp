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
        private Dictionary<string, HashSet<string>> listOfWordAddresses = new Dictionary<string, HashSet<string>>();

        private ITokenizer tokenizer;

        public Index(ITokenizer tokenizer)
        {
            this.tokenizer = tokenizer;
        }

        public bool AddFile(string filePath)
        {
            try
            {
                Process(filePath);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public HashSet<string> LookUp(string token)
        {
            if (listOfWordAddresses.ContainsKey(token))
                return listOfWordAddresses[token];
            else
                return new HashSet<string>();
        }

        private void Process(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                HashSet<string> newTokens = tokenizer.GetTokens(line);
                foreach (string newToken in newTokens)
                {
                    if (!listOfWordAddresses.ContainsKey(newToken))
                    {
                        listOfWordAddresses[newToken] = new HashSet<string>();
                    }
                    listOfWordAddresses[newToken].Add(filePath);
                }
            }
        }
    }

}
