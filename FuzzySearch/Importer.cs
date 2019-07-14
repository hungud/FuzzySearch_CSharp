using FuzzySearch.dataCenter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzySearch
{
    class Importer
    {
        public static void AddDirectory(string path)
        {
            string[] paths = Directory.GetDirectories(path);
            string[] filePaths = Directory.GetFiles(path);
            foreach (string filePath in filePaths)
            {
                Index.AddIndex(filePath);
            }
            foreach (string aPath in paths)
            {
                AddDirectory(aPath);
            }
        }
    }
}
