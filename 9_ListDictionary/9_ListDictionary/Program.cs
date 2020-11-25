using System;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel.DataAnnotations;

namespace _9_ListDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Справочник места работы");
            Dictionary<Person, string> catalog = new Dictionary<Person, string>()
            {
                {new Person() { FIO = "Иванов Иван Иванович", DateBith = new DateTime(1987,11,25), PassportID = "KH 058941", PlaceBirth="Терновка" },"Google"},
                {new Person() { FIO = "Игнатьев Сергей Федорович", DateBith = new DateTime(1987, 11, 27), PassportID = "FH 951958", PlaceBirth = "Тирасполь" }, "Dex"},
                {new Person() { FIO = "Фомина Инна Васильевна", DateBith = new DateTime(1990, 5, 16), PassportID = "PH 925987", PlaceBirth = "Москва" }, "Рамблер"},
                {new Person() { FIO = "Липатников Михаил Степанович", DateBith = new DateTime(1989, 3, 20), PassportID = "SD 005903", PlaceBirth = "Незавертайловка" }, "Microsoft"},
                {new Person() { FIO = "н", DateBith = new DateTime(1000,10,10), PassportID = "н", PlaceBirth = "н" }, "Facebook"}
            };
            Person worker = new Person() { FIO = "Иванов Иван Иванович", DateBith = new DateTime(1987, 11, 25), PassportID = "KH 058941", PlaceBirth = "Терновка" };
            catalog[worker] = "Яндекс";

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\nВведите данные физического лица.");
                             
                Person person = Input();               
                string placeJob = "";
                if (catalog.TryGetValue(person, out placeJob))
                {
                    Console.WriteLine($"Текущее место работы: {placeJob}\n");
                }
                else
                {
                    Console.WriteLine("В справочнике нет информации о данном лице\n");
                }
                Console.WriteLine("Завершить поиск в справочнике? (y/n)");
                while (true)
                {
                    var inputKey = Console.ReadKey();
                    if (inputKey.Key == ConsoleKey.Y)
                    {
                        flag = false;
                        break;
                    }
                   else if (inputKey.Key == ConsoleKey.N)
                    {
                        break;
                    }
                   else if (inputKey.Key != ConsoleKey.Y && inputKey.Key != ConsoleKey.N)
                    {
                        Console.WriteLine("\nДля выхода из программы нажмите Y, для продолжения поиска N\n");
                    }
                }
            }
        }

       
        public static Person Input()
        {
            Person person = new Person();
            Console.WriteLine("1. ФИО: ");
            person.FIO = Convert.ToString(Console.ReadLine());           
            Console.WriteLine("2. Номер паспорта: ");
            person.PassportID = Convert.ToString(Console.ReadLine());
            Console.WriteLine("3. Место рождения: ");
            person.PlaceBirth = Convert.ToString(Console.ReadLine());
            Console.WriteLine("4. Дата рождения (yyyy.mm.dd): ");
            DateTime dateBith;
            if (DateTime.TryParse(Console.ReadLine(), out dateBith))
                person.DateBith = dateBith;
            else
                Console.WriteLine("Введена некорректная дата рождения");
            return person;
        }
    }
}
