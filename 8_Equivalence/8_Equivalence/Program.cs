using System;
using System.Security.Cryptography;

namespace _8_Equivalence
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person(){FIO="Иванов Иван Иванович",DateBith = new DateTime(1987,17,25), PassportID ="", PlaceBirth="Терновка" };
            Person person2 = new Person(){FIO="Иванов Иван Иванович",DateBith = new DateTime(1987, 11, 25), PassportID = "KH 058941", PlaceBirth="Незавертайловка" };
            Person person3 = new Person(){FIO="Игнатьев Сергей Федорович",DateBith = new DateTime(1988,5,4), PassportID = "FT 852974", PlaceBirth="Тирасполь" };
            Person person4 = new Person(){FIO="Игнатьев Сергей Федорович",DateBith = new DateTime(1988,5,4), PassportID = "FT 852974", PlaceBirth="Тирасполь" };
           
            Display(person1,person2);
            Display(person3, person4);            

            Console.WriteLine("\nДля String оператор == перегружен и сравнивает  значения объектов string, а не ссылки");
            string s1 = "hello";
            string s2 = "Hello!";
            string s3 = s1;
            Console.WriteLine(s1 == s2);//false
            Console.WriteLine(s3 == s1);//true

            Console.WriteLine("\nИспользование переопределенных оператов и метода сранения объектов пользовательского класса");
            Console.WriteLine(person3 == person4);//true
            Console.WriteLine(person3.Equals(person4));//true
            Console.WriteLine(person1 !=person2);//true
            Console.WriteLine(person1.Equals(person2));//false

        }

        static void Display(Person person1, Person person2)
        {
            Console.WriteLine($"Объект: {person1.FIO} - {person1.DateBith} - {person1.PassportID} - {person1.PlaceBirth}");
            Console.WriteLine($"Объект: {person2.FIO} - {person2.DateBith} - {person2.PassportID} - {person2.PlaceBirth}");
            Console.WriteLine($"Его хеш-код: {person1.GetHashCode()}");
            Console.WriteLine($"Его хеш-код: {person2.GetHashCode()}");
            if (person1.GetHashCode() == person2.GetHashCode())
            {
                Console.Write("Хеш-коды равны; ");
            }
            else
            {
                Console.Write("Хеш-коды не равны; ");
            }
            if (person1.Equals(person2))
            {
                Console.WriteLine("объекты равны\n");               
            }
            else 
            { 
                Console.WriteLine("объекты не равны\n");
            }
           
        }

    }
}
