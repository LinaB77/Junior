using System;
using System.Collections;
using System.Collections.Generic;


namespace _5_EnumerableEnumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Room> roomsL = new List<Room>()
            {
                new Room("Столовая", 1),
                new Room("Душевая", 2),
                new Room("Спальня", 3),
                new Room("Коридор", 2),
                new Room("Котельная", 1)
            };

            House<Room> roomsList = new House<Room>(roomsL);
            ListForeach(roomsList); 
            ListWhile(roomsList);
        }
        /// <summary>
        /// Обход элементов списка при помощи оператора foreach
        /// </summary>        
        public static void ListForeach(House<Room> roomsList)
        {
            Console.WriteLine("Обход элементов списка при помощи оператора foreach");
            foreach (Room r in roomsList)
            {
                Console.WriteLine(r.Name + ", Количество: " + r.Number);
            }
        }

        /// <summary>
        /// Обход элементов списка при помощи оператора while
        /// </summary>       
        public static void ListWhile(House<Room> roomsList)
        {
            Console.WriteLine("\nОбход элементов списка при помощи оператора while");
            IEnumerator iEnum = roomsList.GetEnumerator();
            while (iEnum.MoveNext())
            {
                Room r = (Room)iEnum.Current;
                Console.WriteLine(r.Name + ", Количество: " + r.Number);
            }
        }

    }
}
