using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace _16_QueueTask
{
    class Program
    {
        static async Task Main()
        {
            int amount = 10; // количество задач в очереди на обработку
            QueueTasks queue = new QueueTasks(amount);
            
            await queue.BeginAsync();
            Console.WriteLine("Для выхода из программы нажмите enter");

            Console.ReadLine();
        }       
    }
}