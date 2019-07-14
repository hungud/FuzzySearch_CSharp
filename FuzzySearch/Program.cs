using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> hash = new HashSet<string>();
            hash.Add("ttt");
            hash.Add("Hello");
            HashSet<string> b = new HashSet<string>();
            b.Add("eee");
            b.Add("Hello");
            b.UnionWith(hash);
            foreach (string str in hash)
            {
                Console.WriteLine(str);
            }
            /*Dictionary<string, string> hash = new Dictionary<string, string>();

            hash["mehdi"] = "jarrahi";*/
            /*string a = "Hello baby";
            string[] b = a.Split(new char[]{ ' ','a'});
            Console.WriteLine(b.Length);
            string line = Console.ReadLine();
            Console.WriteLine(line);*/
            Console.ReadLine();
        }
    }
}
