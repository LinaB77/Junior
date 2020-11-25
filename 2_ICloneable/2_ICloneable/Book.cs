using System;
using System.Collections.Generic;
using System.Text;

namespace _2_ICloneable
{  
    /// <summary>
    /// Класс, описывающий книгу
    /// </summary>
    public class Book : ICloneable
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///Автор
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// Количество страниц
        /// </summary>
        public int NumberPages { get; set; }
        /// <summary>
        /// Год издания
        /// </summary>
         public int YearPubl { get; set; } 
        /// <summary>
        /// Расположение в библиотеке
        /// </summary>
         public Location Local { get; set; }

        public Book(string name, string author, int numberPages, int yearPubl, Location local)
        {
            Name = name;
            Author = author;
            NumberPages = numberPages;
            YearPubl = yearPubl;
            Local = local;
        }

        public Book()
        {
        }

        /// <summary>
        /// метод интерфейса ICloneable, осуществляющий поверхностное (неглубокое) копирование/клонирование
        /// </summary>
        /// <returns>копия объекта Book</returns>
        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
        /// <summary>
        /// Вывод на экран
        /// </summary>
        public void Display()
        {
            Console.WriteLine($"----------------------------\n" +
                              $"Название книги: {Name}, Автор: {Author}\n" +
                              $"Количество страниц: {NumberPages}, Год издания: {YearPubl}\n" +
                              $"Номер стеллажа: {Local.Rack}, Шифр: {Local.Code}");
        }
    }
}
