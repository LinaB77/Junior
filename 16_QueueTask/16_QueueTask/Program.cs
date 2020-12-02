using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace _16_QueueTask
{
    class Program
    {  
        /// <summary>
        /// потокобезопасная очередь
        /// </summary>
        public static BlockingCollection<Task> queueTasks;
        private static SemaphoreSlim semaphore;
        static int timer = 0;

        static void Main(string[] args)
        {
            queueTasks = new BlockingCollection<Task>();
            Task.Factory.StartNew(() => Start(5));
            Task[] listTasks = new Task[10];
            for (int i = 0; i < 10; i++)
            {
                listTasks[i] = Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Add(() =>
                        {
                            semaphore.Wait();
                            try
                            {
                                Console.WriteLine($"Имитация работы задачи. Id задачи {Task.CurrentId}");
                                Thread.Sleep(2000);
                            }
                            finally
                            {
                                semaphore.Release();
                            }
                        });
                    }
                });
            }

            Task.WaitAll(listTasks);
            queueTasks.CompleteAdding();
            Console.ReadLine();
        }
       
        /// <summary>
        /// Остановить обработку очереди и выполнять задачи
        /// </summary>
        private static void Stop()
        {
            Console.WriteLine("Обработка очереди остановлена. Выполняются запущенные ранее 30 задач\n");
            Clean();
        }
       
        /// <summary>
        /// Очистить очередь задач
        /// </summary>
        private static void Clean()
        {
            BlockingCollection<Task> bufferTasks = new BlockingCollection<Task>();
            foreach (Task task in queueTasks.GetConsumingEnumerable())
            {
                bufferTasks.Add(task);
            }
            queueTasks = bufferTasks;
            Console.WriteLine("Очередь очищена\n");
            Console.WriteLine("Запуск работы экзекутера\n");
            Task.Factory.StartNew(() => Start(5));
        }

        /// <summary>
        /// Запустить обработку очереди и установить максимальное кол-во параллельных задач
        /// </summary>
        /// <param name="maxConcurrent">максимальное кол-во одновременно выполняемых задач</param>
        private static void Start(int maxConcurrent)
        {
            semaphore = new SemaphoreSlim(0, maxConcurrent);
            semaphore.Release(maxConcurrent);
            int count = 0;
            foreach (Task task in queueTasks.GetConsumingEnumerable())
            {
                if (count == 30)
                {
                    Stop();
                    break;
                }
                else
                {
                    task.Start();
                    count++;
                }
            }
        }

        /// <summary>
        /// Добавить задачу в очередь
        /// </summary>
        /// <param name="action"></param>
        private static void Add(Action action)
        {
            try
            {
                if (!queueTasks.IsAddingCompleted)
                {
                    Interlocked.Increment(ref timer);
                    Thread.Sleep(timer * 100);
                    queueTasks.TryAdd(new Task(() => action()));
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Дальнейшее добавление задач заблокировано");
            }
        }
    }
}