using System;

namespace SerializableApp
{
    /// <summary>
    /// Класс, описывающий авто
    /// </summary>
    public class Avto
    {        
        /// <summary>
        ///Пробег
        /// </summary>
        public int Mileage { get; set; }
        /// <summary>
        /// Список владельцев
        /// </summary>
        public Person[] Onwers { get; set; }
        /// <summary>
        /// Марка авто
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// Дата выпуска авто
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        public Avto() { }

    }
}
