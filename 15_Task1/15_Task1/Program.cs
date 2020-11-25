using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _15_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch time = new Stopwatch();
            Console.WriteLine("\n-----Последовательное выполнение");
            time.Start();
            ArrayAverage(10000000);
            ArrayAverage(100000000);
            time.Stop();
            Console.WriteLine($"--Время при последовательном выполнении: {time.Elapsed.TotalMilliseconds} мс.");

            Console.WriteLine("-----Параллельное выполнение");           
            time.Restart();
            Parallel.Invoke(()=>ArrayAverage(10000000), ()=>ArrayAverage(100000000));            
            time.Stop();
            Console.WriteLine($"--Время при Parallel.Invoke: {time.Elapsed.TotalMilliseconds} мс.\n");

             time.Restart();
            Task task1 = Task.Factory.StartNew(() => ArrayAverage(100));
            Task task2 = Task.Factory.StartNew(() => ArrayAverage(10));
            Task.WaitAll(task1,task2);
            time.Stop();            
            Console.WriteLine($"--Время при выполнении task: {time.Elapsed.TotalMilliseconds} мс.");
        }

        /// <summary>
        /// генерирует num-мерный массив и подсчитывает среднее арифметическое
        /// </summary>
        /// <param name="num">размерность массива</param>
        private static void ArrayAverage(int num)
        {            
            int[] array = new int[num];
            for (int i = 0; i < num; i++)
            {
                array[i]= new Random().Next(0,100);
            }
            double average=array.Average();
            Console.WriteLine($"Среднее арифметическое {num}-мерного массива: {average}");
        }       
    }
}
