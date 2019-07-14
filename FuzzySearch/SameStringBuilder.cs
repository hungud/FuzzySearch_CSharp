using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzySearch
{
    class SameStringBuilder
    {
        private HashSet<string> sames;

        public SameStringBuilder(string input)
        {
            sames = new HashSet<string>
            {
                input
            };
        }

        public void ProduceSames(int changes)
        {
            for (; changes > 0; changes--)
                changeOneChar();
        }

        private void changeOneChar()
        {
            HashSet<string> newStrings = new HashSet<string>();
            foreach (string str in sames)
            {
                StringBuilder stringBuilder = new StringBuilder(str);
                //            deleting
                char c;
                for (int i = 0; i < stringBuilder.Length; i++)
                {
                    c = stringBuilder[i];
                    stringBuilder.Remove(i,1);
                    newStrings.Add(stringBuilder.ToString());
                    stringBuilder.Insert(i, c);
                }
                //            inserting
                for (int i = 'a'; i <= 'z'; i++)
                {
                    for (int j = 0; j < stringBuilder.Length + 1; j++)
                    {
                        stringBuilder.Insert(j, (char)i);
                        newStrings.Add(stringBuilder.ToString());
                        stringBuilder.Remove(j,1);
                    }
                }
            }
            sames.UnionWith(newStrings);
        }

        public HashSet<String> getSames()
        {
            return sames;
        }
    }
}
