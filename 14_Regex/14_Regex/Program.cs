using System;
using System.Text.RegularExpressions;

namespace _14_Regex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---Регулярные выражения---");
            Console.WriteLine("\n1. Удаление повторяющихся пробелов\nВведите исходную строку:");
            string input = Console.ReadLine();
            Console.WriteLine($"Итог: {RemoveSpaces(input)}");

            Console.WriteLine("\n2. Проверить корректность номера телефона (+373 77767852, 77767852, 0 (777) 67852)");
            PhoneТumberМerification();

            Console.WriteLine("\n3. Выделить число из текста (1, 1000, 1 000 000, 100.23)");
            NumberFromText();

            Console.WriteLine("\n4. Выделить параметры из строки запроса http://ya.ru/api?r=1&x=23");
            ParametersFromRequest();

        }

        /// <summary>
        /// Выделяет параметры из строки запроса
        /// </summary>
        private static void ParametersFromRequest()
        {         
            string input = "http://ya.ru/api?r=1&x=23";            
            Console.WriteLine("Параметры:");            
            Regex regex = new Regex(@"(?<=\?|\&)(?:\w+\=\w+)");
            MatchCollection matches = regex.Matches(input);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value);
                }
            }
            else
                Console.WriteLine("Нет данных, удовлетворяющих условию поиска");
        }

        /// <summary>
        /// Выделяет  из текста числа типа 1, 1000, 1 000 000, 100.23
        /// </summary>
        private static void NumberFromText()
        {
            Console.WriteLine("Введите исходный текст:");
            string input = Console.ReadLine();
            Regex regex = new Regex(@"(?<!\.)(\b(?:[1-9](?:\d{1,2})?)\s?(?:[0-9]{3}\s?)*(?:\.[0-9]+)?\b|\b0\.(?:[1-9]+|0*[1-9]+)\b)(?!\.)");
            MatchCollection matches = regex.Matches(input);

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value);
                }
            }
            else
                Console.WriteLine("Нет данных, удовлетворяющих условию поиска");
        }

        /// <summary>
        ///Проверяет, что вводимое число - корректный номер телефона (+373 77767852, 77767852, 0 (777) 67852)
        /// </summary>
        private static void PhoneТumberМerification()
        {
            Regex regex = new Regex(@"^((0|\+373)[\s]?)?(\(?[7]{2}(5|[7-9]){1}\)?[\s]?)[0-9]{5}$");
            while (true)
            {
                Console.WriteLine("Введите номер:");
                string input = Console.ReadLine();     

                if (regex.IsMatch(input))
                {
                    Console.WriteLine("Номер телефона подтвержден");
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный номер телефона");                    
                }
            }
        }

        /// <summary>
        /// Удаление повторяющихся пробелов
        /// </summary>
        /// <param name="input">исходная строка</param>
        /// <returns>результирующая строка</returns>
        private static string RemoveSpaces(string input)
        {           
            Regex regex = new Regex(@"\s+");
            string rezult = regex.Replace(input, " ");
            return rezult;
        }
    }
}
