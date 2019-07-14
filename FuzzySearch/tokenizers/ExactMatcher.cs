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
        private int minLength;
        private int maxLength;

        public ExactMatcher(char[] splitters, int minLength, int maxLength)
        {
            this.splitters = splitters;
            this.minLength = minLength;
            this.maxLength = maxLength;
        }


        public HashSet<string> GetTokens(string text)
        {
            string[] tokens = text.Split(splitters);
            return new HashSet<string>(tokens);
        }
    }
}
