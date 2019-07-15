using FuzzySearch.dataCenter;
using FuzzySearch.tokenizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzySearch.analysers
{
    class FuzzyAnalyser
    {
        private int number;
        private ITokenizer tokenizer;
        private Index index;

        public FuzzyAnalyser(ITokenizer tokenizer, Index index, int number)
        {
            this.tokenizer = tokenizer;
            this.number = number;
            this.index = index;
        }

        public Dictionary<string, HashSet<string>> Analysis(string query)
        {
            HashSet<string> queryTokens = tokenizer.GetTokens(query);
            Dictionary<string, HashSet<string>> result = new Dictionary<string, HashSet<string>>();
            foreach (string token in queryTokens)
            {
                result[token] = new HashSet<string>();
                HashSet<string> sames = new SameStringBuilder(token).ProduceSames(number).sames;
                foreach (string sameToken in sames)
                {
                    result[token].UnionWith(index.LookUp(sameToken));
                }
            }
            return result;
        }
    }
}
