using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Untity
{
    public static class ExtendTool
    {
        public static int ToInt32(this string value, int defaultValue)
        {
            int result = 0;
            bool isSuccess = int.TryParse(value, out result);
            if (!isSuccess)
            {
                return defaultValue;
            }
            return result;
        }

        public static bool ToBool(this string value, bool defaultValue)
        {
            bool result = false;
            bool isSuccess = bool.TryParse(value, out result);
            if (!isSuccess)
            {
                return defaultValue;
            }
            return result;
        }

        public static int ToInt32(this bool value)
        {
            if (value)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// 截取指定长度的省略字段
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string SubOmitString(this string value, int length)
        {
            if (value.Length > length - 3)
            {
                return string.Format("{0}...", value.Substring(0, length - 3));
            }
            return value;
        }

        /// <summary>
        /// 值转换为对应的枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ValueToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        /// <summary>
        /// 获取指定枚举常数值对应的名称
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ValueToEnumName<T>(this int value)
        {
            return Enum.GetName(typeof(T), value);
        }

    }
}
