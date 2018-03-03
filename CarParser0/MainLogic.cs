using CarParser0.Logger;
using System;

namespace CarParser0
{
    class MainLogic
    {
        private static ILogger Logger;

        static void Main(string[] args)
        {
            try
            {
                Initialization();

                Console.WriteLine("Test");

                //input module
                //config parameters e.g. path
                //output list of Models

                Console.ReadLine();

                Logger.Log("End of execution");
            }
            finally{
                Console.WriteLine("Error");
                Console.WriteLine("Error");
                Console.WriteLine("Error");
                Console.WriteLine("Error");
                Console.WriteLine("Error");
            }
            
        }

        static void Initialization()
        {
            //Logger = new LoggerToTextFile("Log.txt", new TimeProvider());
            Logger = new LoggerToExcel("C:\\Users\\Anik\\Desktop\\Log.xlsx", new TimeProvider()); //have to be complete path

            Logger.Log("Initialized");
        }
    }
}
