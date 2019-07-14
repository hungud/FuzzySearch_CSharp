using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzySearch.tokenizers
{
    class ExactMatcher : ITokenizer
    {
        private string splitters;
        private int minLength;
        private int maxLength;

        public ExactMatcher(string splitters, int minLength, int maxLength)
        {
            this.splitters = splitters;
            this.minLength = minLength;
            this.maxLength = maxLength;
        }


        public HashSet<string> GetTokens(string text)
        {
            /*String[] tokens = text.split(splitters);
            return new HashSet<string>(Arrays.asList(tokens));*/
            return new HashSet<string>();
        }
    }
}
