using System;
using System.Collections.Generic;
using System.IO;

namespace CarParser0.InputReaderFolder //to test it
{
    public class CSVReader : IReader
    {
        private String path;

        public CSVReader(String path)
        {
            this.path = path;
        }

        public List<string> ReadData()
        {
            String fileData = File.ReadAllText(path);

            fileData = fileData.Replace(" ", String.Empty);

            return new List<string>( fileData.Split(','));
        }
    }
}
