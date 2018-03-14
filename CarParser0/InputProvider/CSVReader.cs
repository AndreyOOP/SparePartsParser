using System;
using System.Collections.Generic;
using System.IO;

namespace CarParser0.InputReaderFolder
{
    public class CSVReader : IInputProvider
    {
        private String path;

        public CSVReader(String path)
        {
            this.path = path;
        }

        public List<string> GetInputData()
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("File with input data could not be found");

            String fileData = File.ReadAllText(path);

            fileData = fileData.Replace(" ", String.Empty);
            fileData = fileData.Replace("\r\n", String.Empty);

            return new List<string>( fileData.Split(','));
        }
    }
}
