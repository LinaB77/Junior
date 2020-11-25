using System;

namespace _12_ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = 5556633;
            TimeSpan timeSpan = t.InTimeSpan();
            Console.WriteLine(timeSpan.ToString(@"dd\:hh\:mm\:ss"));
            Console.WriteLine(timeSpan.SecondsFromTimeSpan());
        }
    }
}
