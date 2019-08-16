using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo
{
    public class FileStore : IStore
    {
        private readonly string _filePath;

        public FileStore(string filePath)
        {
            _filePath = filePath;
        }

        public int result { get; set; }

        public void Save(int result)
        {
            using (var writer = File.CreateText(_filePath))
            {
                writer.WriteLine(result);
            }
        }
    }
}
