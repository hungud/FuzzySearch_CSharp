using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzySearch.tokenizers
{
    class NGramSearcher : ITokenizer
    {
        public HashSet<string> GetTokens(string text)
        {
            /*String[] tokens = text.split(splitters);
            return new HashSet<string>(Arrays.asList(tokens));*/
            return new HashSet<string>();
        }
    }
}
