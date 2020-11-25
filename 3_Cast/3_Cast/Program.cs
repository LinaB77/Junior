using System;
using System.Diagnostics;

namespace _3_Cast
{
    class Program
    {
        static void Main(string[] args)
        {
            // явное/неявное преобразование к типу Person/string
            Person person1 = (Person)"Петя Петров";
            Person person2 = new Person("Иван", "Иванов");
            string transform = person2;

            Object person3 = new Person("Иван", "Иванов");
            Person person4 = person1;

            // сравнение объектов
            Debug.Assert(!person2.Equals("Иван Иванов"));//false
            Debug.Assert(person2 == "Иван Иванов");//true

            Debug.Assert(!person3.Equals((Person)"Иван Иванов"));//false
            Debug.Assert(person3!=person2);//false

            Debug.Assert(person4==person1);//true
            Debug.Assert(person4.Equals(person1));//true


        }
        /// <summary>
        /// вывод на экран
        /// </summary>
        /// <param name="compar"></param>
        private static void Display(bool compar)
        {
            if (compar)
            {
                Console.WriteLine("Объекты равны");
            }
            else 
            { 
                Console.WriteLine("Объекты не равны");
            }
        }
    }
}
