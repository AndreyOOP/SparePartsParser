using CarParser0.ConfigF;
using CarParser0.ConfigNS;
using System;

namespace CarParser0.InputReaderFolder
{
    class InputReaderFactory
    {
        public static IReader CreateReader(Config config)
        {
            if (config.ReaderType == InputType.CSV)
            {
                return new CSVReader(config.ReaderPath);
            }

            throw new Exception("Could not find appropriative type to instantiate");
        }
    }
}
