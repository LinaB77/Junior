using System;

namespace _5_EnumerableEnumerator
{
    public class Room
    {
        /// <summary>
        /// Класс Помещение
        /// </summary>
        /// <param name="name">название</param>
        /// <param name="number">количество</param>
        public Room(string name, int number)
        {
            this.Name = name;
            this.Number = number;
        }

        public string Name;
        public int Number;
    }
}
