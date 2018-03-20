using CarParser0.ConfigF;
using CarParser0.ConfigNS;
using System;

namespace CarParser0.InputReaderFolder
{
    public class InputProviderFactory
    {
        public static IInputProvider CreateInputReader(Configuration config)
        {
            switch (config.ReaderType)
            {
                case InputType.CSV:
                    return new CSVReader(config.ReaderPath);

                case InputType.EXCEL:
                    throw new NotImplementedException("Excel input is not yet implemented");

                case InputType.SQL:
                    throw new NotImplementedException("SQL DB input is not yet implemented");
            }

            throw new Exception("Could not find appropriative type to instantiate");
        }
    }
}
