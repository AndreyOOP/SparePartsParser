using CarParser0.DataStore;
using CarParser0.DTO;
using CarParser0.Interfaces;
using CarParser0.Logger;
using System;
using System.Collections.Generic;

namespace CarParser0.SiteParser
{
    public class Parser
    {
        List<String> Ids;
        List<IAbstractSiteParser> Parsers;
        IDataStore DataSaver;
        ILogger Logger;

        List<SiteInfo> parsedInfo;
        

        public Parser(List<String> Ids, List<IAbstractSiteParser> Parsers, IDataStore DataSaver, ILogger Logger)
        {
            this.Ids = Ids;
            this.Parsers = Parsers;
            this.DataSaver = DataSaver;
            this.Logger = Logger;
        }

        public void Execute()
        {
            foreach (IAbstractSiteParser parser in Parsers)
            {
                foreach (String id in Ids)
                {
                    try
                    {
                        parsedInfo = parser.Parse(id);

                        if (parsedInfo.Count > 0)
                        {
                            Logger.Log("Information for id " + id + " succesfully parsed");

                            foreach (SiteInfo i in parsedInfo)
                                DataSaver.Save(i);
                        }
                        else
                        {
                            Logger.Log("No Data Found " + id);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Log("Exception during id " + id + " parsing " + ex);
                    }
                }
            }
        }
    }
}
