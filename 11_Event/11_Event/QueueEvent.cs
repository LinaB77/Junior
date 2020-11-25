using System;
using System.Collections.Generic;
using System.Text;

namespace _11_Event
{
    class QueueEvent
    {
        public event EventHandler<UserEventArgs> QueueOverflowedOrDevastated;
        private int count;
        Queue<int> queueSimple;
      
        public QueueEvent(int count)
        {
            queueSimple = new Queue<int>();
            this.count = count; 
        }

        /// <summary>
        /// Добавление случайного элемента в очередь
        /// </summary>
        public void Add()
        {
            if (queueSimple.Count == count - 1)
            {
                queueSimple.Enqueue(new Random().Next(100));
                OnQueueOverflowed(new UserEventArgs { Message = $"В очередь добавлен {count} элемент. Достигнуто пороговое число элементов" });
            }
            else
            {
                queueSimple.Enqueue(new Random().Next(100));
                Console.WriteLine($"Добавлен элемент номер {queueSimple.Count}");
            }
        }

        /// <summary>
        /// Удаление элемента из очереди
        /// </summary>
        public void Remove()
        {
            if (queueSimple.Count == 0)
                OnQueueOverflowed(new UserEventArgs { Message = "Нечего удалять, очередь пуста" });
            else
            {
                if (queueSimple.Count > 1)
                {
                    Console.WriteLine($"Удален элемент номер {queueSimple.Count}");
                    queueSimple.Dequeue();
                   
                }
                else
                {
                    OnQueueOverflowed(new UserEventArgs { Message = $"Удален элемент номер {queueSimple.Count}. Очередь пуста" });
                    queueSimple.Dequeue();                    
                }
            }
        }

        /// <summary>
        /// Вызов события
        /// </summary>
        /// <param name="e">объект класса UserEventArgs, информация о событии</param>
        private void OnQueueOverflowed(UserEventArgs e)
        {
            QueueOverflowedOrDevastated?.Invoke(this,e);
        }
    }
}
