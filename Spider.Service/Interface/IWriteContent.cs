using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.Service.Interface
{
    public interface IWriteContent
    {
        void WriteSuccessContet(string content);
        void WriteErrorContet(string content);
        void WriteNotifyContet(string content);
    }
}
