using System;
using System.Collections.Generic;
using System.Text;

namespace _6_LINQ
{
    /// <summary>
    /// Класс, описывает автомобилиста
    /// </summary>
    class Motorist
    {
        /// <summary>
        /// статическая переменная нумерует объекты
        /// </summary>
       private static int ID = 0;
        public Guid Id { get; } = Guid.NewGuid();
        /// <summary>
        /// Стаж вождения
        /// </summary>
        public int Experience { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Марка авто
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// Дата покупки авто
        /// </summary>
        public DateTime BuyDate { get; set; }
        /// <summary>
        /// Наличие другого авто
        /// </summary>
        public bool OnlyCar { get; set; }   

    }
}
