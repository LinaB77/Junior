using System;

namespace _11_StreamNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            Analyzer analyzer = new Analyzer();
            analyzer.NumberDifferently += Analyzer_NumberDifferently;
            Console.WriteLine("Введите число от 1 до 100, которое будет служить условием отличия на x процентов:");
            analyzer.GivenNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите процент, на который должны отличаться случайные числа из потока чисел:");
            analyzer.GivenPercentage = Convert.ToInt32(Console.ReadLine());
           //генерация и анализ 100 случайних чисел
            for (int i = 0; i < 100; i++)
            {
                number = new Random().Next(100);
                Console.WriteLine(number);
                analyzer.AnalizeNumber(number);
            }
            analyzer.NumberDifferently -= Analyzer_NumberDifferently;
        }
        /// <summary>
        /// Обработчик события
        /// </summary>
        /// <param name="sender">объект, вызвавший событие</param>
        /// <param name="e">информация о событии</param>
        private static void Analyzer_NumberDifferently(object sender, UserEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
