using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Site.Log
{
    public class LogHelp
    {
        private static ILog ErrorLogger;
        private static ILog InfoLogger;
        static LogHelp() 
        {
            ErrorLogger = LogManager.GetLogger("error");
            InfoLogger = LogManager.GetLogger("info");
        }

        public static void Info(string content)
        {
            InfoLogger.Info(content);
        }

        public static void Error(string content)
        {
            ErrorLogger.Error(content);
        }



    }
}
