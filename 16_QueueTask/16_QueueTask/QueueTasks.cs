using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace _16_QueueTask
{
    public class QueueTasks : IJobExecutor
    {
        /// <summary>
        /// SemaphoreSlim ограничивает количество параллельно выполняющихся потоков 
        /// </summary>
        public SemaphoreSlim semaphore;
     
        /// <summary>
        /// Кол-во задач в очереди на обработку
        /// </summary>
        public int Amount { get; }
       
        /// <summary>
        /// счетчик добавления задач
        /// </summary>
        int totalCountTask=1;
       
        /// <summary>
        /// потокобезопасная очередь
        /// </summary>
        public BlockingCollection<Task> queueTasks = new BlockingCollection<Task>();

        /// <summary>
        /// флаг, сигнализирующий об очистке очереди
        /// </summary>
        bool IsClear = false;
        public QueueTasks(int amount)
        { 
            Amount = amount; 
        }
       
        /// <summary>
        /// Запуск двух потоков, одновременно добавляющих задачи в очередь и потока, обрабатывающего очередь
        /// </summary>       
        public async Task BeginAsync()
        {           
            Task produser1 = Task.Run(() => Add(Factorial));
            Task produser2 = Task.Run(() => Add(Factorial));
            Task consumer = Task.Run(() => Start(5));
            //Приостановка потока на 100 мс и остановка обработки очереди
            Thread.Sleep(100);
            Stop();
            try
            {
                await Task.WhenAll(consumer, produser1, produser2);
            }
            finally
            {
                produser1.Dispose();
                produser2.Dispose();
                consumer.Dispose();
                queueTasks.Dispose();               
            }
        }        


        /// <summary>
        /// Запустить обработку очереди и установить максимальное кол-во параллельных задач
        /// </summary>
        /// <param name="maxConcurrent">максимальное кол-во одновременно выполняемых задач</param>
        public void Start(int maxConcurrent)
        {
            semaphore = new SemaphoreSlim(0, maxConcurrent);
            semaphore.Release(maxConcurrent);
            try
            {
                while(true)
                {
                    if (!queueTasks.IsAddingCompleted)
                    {
                        Task task = queueTasks.Take();
                        if (!IsClear)
                        {
                            task.Start();     
                        }
                    }
                    else break;
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Дальнейший запуск задач заблокирован");                
            }          
        }
               
        /// <summary>
        /// Для демонстрации работы параллельных задач используется вычисление факториала
        /// </summary>
        void Factorial()
        {            
            semaphore.Wait();
            try
            {
                int result = 1;
                int n = new Random().Next(10);
                for (int i = 1; i <= n; i++)
                {
                    result *= i;
                }               
                Console.WriteLine($"Факториал {n} равен {result}. Id задачи {Task.CurrentId}");
                Thread.Sleep(1000);
            }
            finally
            {
                semaphore.Release();
                Console.WriteLine("Задача с номером Id {0} освободила семафор", Task.CurrentId);
            }
        }

        /// <summary>
        /// Остановить обработку очереди и выполнять задачи
        /// </summary>
        public void Stop() 
        {
            //останавливаем добавление задач
            if(!queueTasks.IsAddingCompleted)
            queueTasks.CompleteAdding();
            Console.WriteLine($"В очередь добавлено {totalCountTask} задач(и)");
            //останавливаем запуск задач, чтобы выполнялись только уже запущенные задачи
            Thread.Sleep(100);
            Clear();
        }

        /// <summary>
        /// Добавить задачу в очередь
        /// </summary>
        /// <param name="action"></param>
        public void Add(Action action)
        {
            while (true)
            {
                try
                {
                    if (!queueTasks.IsAddingCompleted)
                    {
                        queueTasks.Add(new Task(() => action()));                        
                        Interlocked.Increment(ref totalCountTask);
                        Thread.Sleep(1);
                    }
                    else
                        break;      
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Дальнейшее добавление задач заблокировано");
                    break;
                }
            }            
        }

        /// <summary>
        /// Очистить очередь задач
        /// </summary>
        public void Clear() 
        {
            IsClear = true;
            Console.WriteLine("Запущена очистка очереди. Выполняются запущенные раннее задачи");
        }
    }
}
