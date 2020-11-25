using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace _10_Generic
{
    class UniqueCollection<T>
    {
        List<T> data;
        public UniqueCollection()
        {
            data = new List<T>();
        }

        /// <summary>
        /// Метод добавления объектов
        /// </summary>
        /// <param name="item">добавляемый объект</param>
        public void Add(T item)
        {
            try
            {
                if (!data.Contains(item))
                {
                    data.Add(item);
                }
                else
                {
                    throw new ArgumentException($"Объект {item} не добавлен. Коллекция уже содержит такой объект");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

       /// <summary>
       /// удаление объекта
       /// </summary>
       
        public void Remove(T item)
        {
            data.Remove(item);
        }

        /// <summary>
        /// Реализация GetEnumerator() для работы foreach
        /// </summary>

        public IEnumerator<T> GetEnumerator()
        {
            return data.GetEnumerator();
        }     
    }
}
