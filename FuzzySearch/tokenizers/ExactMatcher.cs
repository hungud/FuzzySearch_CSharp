using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzySearch.tokenizers
{
    class ExactMatcher : ITokenizer
    {
        private char[] splitters;

        public ExactMatcher(char[] splitters)
        {
            this.splitters = splitters;
        }


        public HashSet<string> GetTokens(string text)
        {
            string[] tokens = text.ToLower().Split(splitters);
            return new HashSet<string>(tokens);
        }
    }
}
