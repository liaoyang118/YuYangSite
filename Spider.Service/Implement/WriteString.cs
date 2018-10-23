using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spider.Service.Interface;

namespace Spider.Service.Implement
{
    public class WriteString : IWriteContent
    {
        private IConsoleLog _console;

        public WriteString(IConsoleLog console)
        {
            _console = console;
        }

        public void WriteErrorContet(string content)
        {
            _console.ConsoleLog("错误日志：" + content);
        }

        public void WriteNotifyContet(string content)
        {
            //_console.ConsoleLog("通知日志：" + content);
        }

        public void WriteSuccessContet(string content)
        {
            //_console.ConsoleLog("成功日志：" + content);
        }
    }
}
