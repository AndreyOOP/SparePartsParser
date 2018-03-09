using CarParser0.DTO;
using CarParser0.Logger;
using System;
using System.Collections.Generic;

namespace CarParser0.SiteParser
{
    public class Parser
    {
        List<IAbstractSiteParser> parsers;
        List<String> ids;
        ILogger logger;

        List<SiteInfo> parsedInfo;
        List<SiteInfo> singleParserInfo;

        public Parser(List<IAbstractSiteParser> parsers, List<String> ids, ILogger logger)
        {
            this.parsers = parsers;
            this.ids = ids;
            this.logger = logger;

            parsedInfo = new List<SiteInfo>();
        }

        /*It is better to change sequence of ids & parsers > now each model open & close IE instance
         or use method with only one parser just in main add new implementations if needed*/
        public List<SiteInfo> Execute()
        {
            logger.Log("Start execution");

            foreach (String id in ids)
            {
                foreach (IAbstractSiteParser parser in parsers)
                {
                    try
                    {
                        singleParserInfo = parser.Parse(id);

                        if (singleParserInfo.Count > 0)
                        {
                            parsedInfo.AddRange(singleParserInfo);

                            Log(id, parser.GetType().ToString(), "Ok");


                            //todo add save here, saver have to be injected; no return needed
                            foreach (SiteInfo i in singleParserInfo)
                            {
                                Console.WriteLine(i);
                                logger.Log(i.ToString());
                            }
                        }
                        else
                        {
                            Log(id, parser.GetType().ToString(), "No Data Found");
                        }
                    }
                    catch (Exception ex)
                    {
                        Log(id, parser.GetType().ToString(), "Error: " + ex);
                    }
                }
            }

            logger.Log("End execution");

            return parsedInfo;
        }

        //Execute and save

        private void Log(string id, string type, string msg)
        {
            String message = String.Format("Id: {0}, Parser: {1}, {2}", id, type, msg);

            logger.Log(message);
        }
    }
}
