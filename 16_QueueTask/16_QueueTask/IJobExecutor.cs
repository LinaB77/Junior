using System;
using System.Collections.Generic;
using System.Text;

namespace _16_QueueTask
{
    interface IJobExecutor
    {
        /// <summary>
        /// Кол-во задач в очереди на обработку
        /// </summary>
        int Amount { get; }
       
        /// <summary>
        /// Запустить обработку очереди и установить максимальное кол-во параллельных задач
        /// </summary>
        /// <param name="maxConcurrent">максимальное кол-во одновременно выполняемых задач</param>
        void Start(int maxConcurrent);
        
        /// <summary>
        /// Остановить обработку очереди и выполнять задачи
        /// </summary>
        void Stop();
        
        /// <summary>
        /// Добавить задачу в очередь
        /// </summary>
        /// <param name="action"></param>
        void Add(Action action);
      
        /// <summary>
        /// Очистить очередь задач
        /// </summary>
        void Clear();
    }
}
