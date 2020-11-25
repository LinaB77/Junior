using System;
using System.Collections;
using System.Collections.Generic;

namespace _5_EnumerableEnumerator
{
    /// <summary>
    /// Класс Дом реализует инферфейс IEnumerable
    /// </summary>
    public class House<T>: IEnumerable<T>
    {
        private List<T> roomsList;
        public House(List<T> list)
        {
            roomsList = list;           
        }

        /// <summary>
        /// Реализация метода GetEnumerator
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            return new HouseEnum<T>(roomsList);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)roomsList).GetEnumerator();
        }
    }
}
