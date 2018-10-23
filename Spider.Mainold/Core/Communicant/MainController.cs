using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.Main.Core.Communicant
{
    public delegate void StopTask();

    /// <summary>
    /// 任务通知控制
    /// </summary>
    public class MainController : ISubject
    {
        /// <summary>
        /// 停止任务事件
        /// </summary>
        public event StopTask StopTaskEvent;

        /// <summary>
        /// 按任务通知指定订阅观察者
        /// </summary>
        /// <param name="name"></param>
        public void Notify(Type type)
        {
            Delegate[] delegateList = StopTaskEvent.GetInvocationList();
            foreach (Delegate item in delegateList)
            {
                if (item.Target.GetType() == type)
                {
                    item.DynamicInvoke();
                    break;
                }
            }
        }

        /// <summary>
        /// 通知者，通知方法,通知所有订阅观察者
        /// </summary>
        public void NotifyAll()
        {
            StopTaskEvent();
        }
    }
}
