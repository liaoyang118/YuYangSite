using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity.Configuration;
using Unity;

namespace Spider.Service.Tool
{
    /// <summary>
    /// Unity助手类
    /// </summary>
    public class UnityHelper
    {
        /// <summary>
        /// 容器对象
        /// </summary>
        private static IUnityContainer UnityContainer;

        /// <summary>
        /// 获取容器
        /// </summary>
        /// <returns></returns>
        public static IUnityContainer GetIUnityContainer()
        {
            if (UnityHelper.UnityContainer != null) return UnityHelper.UnityContainer;

            ////加载IOC容器
            IUnityContainer container = new UnityContainer();
            //获取指定名称的配置节
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            //载入名称为SpiderClass 的container节点
            container.LoadConfiguration(section, "SpiderClass");
            UnityContainer = container;

            return UnityContainer;
        }


    }
}
