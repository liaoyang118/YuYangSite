using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spider.Service.Interface;
using Site.Log;

namespace Spider.Service.Implement
{
    public class TextConsole : IConsoleLog
    {
        public void ConsoleLog(string content)
        {
            LogHelp.Info(content);
        }
    }
}
