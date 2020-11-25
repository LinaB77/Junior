using System;
using System.Collections.Generic;

namespace _11_Event
{
    class Program
    {
        static void Main(string[] args)
        {       
            Console.WriteLine("Введите пороговое количество элементов очереди");          
            bool valid = true;
            int threshold = Convert.ToInt32(Console.ReadLine());
            QueueEvent queueEvent = new QueueEvent(threshold);
            queueEvent.QueueOverflowedOrDevastated += Display;

            Console.WriteLine("\nВведите \n+ для добавления элемента \n- для удаления элемента \n0 для выхода из программы");
            while (valid)
            {
                string command = Convert.ToString(Console.ReadLine());
                switch (command)
                {
                    case "+":
                        queueEvent.Add();                        
                        break;
                    case "-":
                        queueEvent.Remove();
                                               
                        break;
                    case "0":
                        valid = false;
                        continue;
                }               
            }
        }
        /// <summary>
        /// Обработчик сообытия QueueOverflowedOrDevastated
        /// </summary>
        /// <param name="sender">объект, вызвавший событие</param>
        /// <param name="e">объект класса UserEventArgs, информация о событии</param>
        public static void Display(object sender, UserEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
