using System;
using System.Collections.Generic;
using System.Text;

namespace _2_ICloneable
{
    /// <summary>
    /// Класс, описывающий категорию книги
    /// </summary>
    class СategoryBook
    {
        /// <summary>
        /// Название категории
        /// </summary>
        public string NameСategory { get;  set; }
        /// <summary>
        /// Индекс категории
        /// </summary>
        public int IndexCategory { get;  set; }

        public СategoryBook(string name, int index)
        {
            this.NameСategory = name;
            this.IndexCategory = index;
        }
    }
}
