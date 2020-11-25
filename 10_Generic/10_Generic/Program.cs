using System;
using System.Collections.Generic;

namespace _10_Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            UniqueCollection<int> numbers = new UniqueCollection<int>();
            numbers.Add(1);
            numbers.Add(3);
            numbers.Add(5);
            numbers.Add(5);
            numbers.Remove(2); 
            numbers.Remove(3);

            Console.WriteLine("Объекты коллекции чисел:");
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
            
            Console.WriteLine();
            UniqueCollection<Person> persons = new UniqueCollection<Person>();
            persons.Add(new Person() { FIO = "Иванов Иван Иванович", PassportID = "KH 058941", PlaceBirth = "Терновка" });
            persons.Add(new Person() { FIO = "Иванов Иван Иванович", PassportID = "KH 058941", PlaceBirth = "Терновка" });
            persons.Add(new Person() { FIO = "Игнатьев Сергей Федорович", PassportID = "FH 951958", PlaceBirth = "Тирасполь" });

            Console.WriteLine("Объекты коллекции Persons:");
            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
        }
    }
}
