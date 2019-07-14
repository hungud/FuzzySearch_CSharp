using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzySearch.tokenizers
{
    class NGramSearcher : ITokenizer
    {
        private char[] splitters;
        private int minLength;
        private int maxLength;

        public NGramSearcher(char[] splitters, int minLength, int maxLength)
        {
            this.splitters = splitters;
            this.minLength = minLength;
            this.maxLength = maxLength;
        }

        public HashSet<string> GetTokens(string text)
        {
            string[] tokens = text.Split(splitters);
            HashSet<string> allStrings = new HashSet<string>();
            foreach (string str in tokens)
            {
                allStrings.UnionWith(GetAllSubStrings(str));
            }
            return allStrings;
        }

        public HashSet<string> GetAllSubStrings(string str)
        {
            HashSet<string> strings = new HashSet<string>();
            int length = strings.Count;
            for (int i = 0; i < length; i++)
            {
                for (int j = minLength; j < maxLength; j++)
                {
                    int startIndex = i;
                    int endIndex = i + j;
                    if (endIndex < length + 1)
                    {
                        strings.Add(str.Substring(startIndex, endIndex));
                       
                    }

                }
            }
            return strings;
        }
    }
}
