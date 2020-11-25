using System;
using System.Collections;
using System.Collections.Generic;


namespace _5_EnumerableEnumerator
{
    /// <summary>
    /// Класс реализует интерфейс IEnumerator
    /// </summary>
    public class HouseEnum<T> : IEnumerator<T>
    {
        public List<T> roomsList;

        int position = -1;

        public HouseEnum(List<T> list)
        {
            roomsList = list;
        }

        /// <summary>
        /// Перемещает указатель на следующий элемент списка
        /// </summary>
        /// <returns>true если последовательность не закончилась и false в противном случае</returns>
        public bool MoveNext()
        {
            position++;
            return (position < roomsList.Count);
        }

        /// <summary>
        /// Сброс указателя
        /// </summary>
        public void Reset()
        {
            position = -1;
        }

      /// <summary>
        /// Возвращает текущий элемент списка, соответственно позиции указателя
        /// </summary>
        public T Current
        {
            get
            {
                if (position == -1 || position >= roomsList.Count)
                {
                    throw new InvalidOperationException();
                }
                return roomsList[position];
            }
        }
        object IEnumerator.Current 
        {
            get
            {
                if (position == -1 || position >= roomsList.Count)
                {
                    throw new InvalidOperationException();
                }
                return roomsList[position];
            }
        }

        public void Dispose() { }
    }
}
