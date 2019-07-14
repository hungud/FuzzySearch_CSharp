using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzySearch.dataCenter
{
    class Index
    {
        private static List<Index> indexes;
       
        private static tokenizers.ITokenizer tokenizer;
        private File file;
        private HashSet<string> tokens = new HashSet<string>();

        private Index(File file)
        {
            this.file = file;
        }

        public static void start(tokenizers.ITokenizer tokenizer)
        {
            Index.tokenizer = tokenizer;
            indexes = new List<Index>();
        }

        public static bool addIndex(File file)
        {
            try
            {
                Index newIndex = new Index(file);
                newIndex.preProcess();
                indexes.add(newIndex);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString);
                return false;
            }
        }

        public static void lookUp(HashSet<string> queryTokens)
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
                    Console.WriteLine(index.file.getPath());
                }
            }
        }

        public static tokenizers.ITokenizer getTokenizer()
        {
            return tokenizer;
        }

        private void PreProcess()
        {
            Scanner scanner = new Scanner(file);
            while (scanner.hasNextLine()) {
                tokens.Add(tokenizer.GetTokens(scanner.nextLine()));
            }
        }
    }
}
