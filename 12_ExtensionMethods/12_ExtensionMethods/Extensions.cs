using System;
using System.Collections.Generic;
using System.Text;

namespace _12_ExtensionMethods
{
    public static class Extensions
    {
        /// <summary>
        /// Метод принимает int - число секунд и возвращает объект TimeSpan
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static TimeSpan InTimeSpan(this int seconds)
        {
            TimeSpan resultand = TimeSpan.FromSeconds(seconds);
            return resultand;
        }

        /// <summary>
        /// Метод принимает TimeSpan и возращает int - число секунд
        /// </summary>
        public static int SecondsFromTimeSpan(this TimeSpan timeSpan)
        {
            return (int)timeSpan.TotalSeconds;
        }
    }
}
