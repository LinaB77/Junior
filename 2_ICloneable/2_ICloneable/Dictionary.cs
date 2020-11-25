using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace _2_ICloneable
{
    class Dictionary : Book, ICloneable
    {
        /// <summary>
        /// Категория книги
        /// </summary>
        public СategoryBook Type { get; set; }
      
        public Dictionary()
        {
        }

        public Dictionary(string name, string author, int numberPages, int yearPubl, Location local, СategoryBook categoryBook)
            : base(name, author, numberPages, yearPubl, local)
        {
            Type = categoryBook ?? new СategoryBook("не задано",  0); 
        }

        /// <summary>
        /// метод интерфейса ICloneable, осуществляющий глубокое копирование
        /// </summary>
        /// <returns>копия объекта Dictionary</returns>
        public override object Clone()
        {
            СategoryBook categoryBook = new СategoryBook (this.Type?.NameСategory ?? "не задано", this.Type?.IndexCategory ?? 0);
            return new Dictionary
            {
                Name=this.Name, Author = this.Author, NumberPages = this.NumberPages,
                YearPubl = this.YearPubl, Local = this.Local, Type=categoryBook
            };
        }        
        
        /// <summary>
        /// Вывод на экран
        /// </summary>
        new public void Display()
        {
            base.Display();
            Console.WriteLine($"Категория: {Type.NameСategory}, Индекс: {Type.IndexCategory}");
        }
    }
}
