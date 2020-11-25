using System;
using System.Diagnostics;

namespace _4_BoxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {            
            object obj=null;
            //Измерение скорости операции упаковки
            Stopwatch time = new Stopwatch();          
            time.Start();
            for (int i = 0; i < 1000000; i++)
            {
                obj = i;
            }
            time.Stop();
            Console.WriteLine($"Время выполнения упаковки: {time.Elapsed.TotalMilliseconds} мс.");

            try
            {
                //Измерение скорости операции распаковки
                time.Restart();
                for (int i = 0; i < 1000000; i++)
                {
                    int upbox = (int)obj;
                }               
                time.Stop();
                Console.WriteLine($"Время выполнения распаковки: {time.Elapsed.TotalMilliseconds} мс.");
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("Ошибка преобразования.\n" + e.Message);
            }
        }
    }
}
