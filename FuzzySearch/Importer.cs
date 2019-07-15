using FuzzySearch.dataCenter;
using FuzzySearch.tokenizers;
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
        public Index index { get; }
        public Importer(string path, Index index)
        {
            this.index = index;
            AddDirectory(path);
        }
        private void AddDirectory(string path)
        {
            string[] paths = Directory.GetDirectories(path);
            string[] filePaths = Directory.GetFiles(path);
            foreach (string filePath in filePaths)
            {
                index.AddFile(filePath);
            }
            foreach (string aPath in paths)
            {
                AddDirectory(aPath);
            }
        }
    }
}
