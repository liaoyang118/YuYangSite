using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.Service.Communicant
{
    /// <summary>
    /// 通知者 接口
    /// </summary>
    public interface ISubject
    {
        void NotifyAll();

        void Notify(Type type);
    }
}
