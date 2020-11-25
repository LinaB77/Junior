using System;
using System.Collections.Generic;
using System.Text;

namespace _8_Equivalence
{
    class Person
    {
        /// <summary>
        /// ФИО
        /// </summary>
        public string FIO { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateBith { get; set; }
        /// <summary>
        /// Место рождения
        /// </summary>
        public string PlaceBirth { get; set; }
        /// <summary>
        /// Номер паспорта
        /// </summary>
        public string  PassportID { get; set; }

        /// <summary>
        /// Переопределение метода GetHashCode()
        /// </summary>
        /// <returns>хеш-код</returns>
        public override int GetHashCode()
        {
            if (PassportID != null && DateBith.Day != 0)
            { return PassportID.GetHashCode() ^ DateBith.Day; }
            else
            {
                Console.WriteLine("Некорректные входные данные. Укажите номер паспорта и/или день рождения");
                return 0;
            }
        }

        /// <summary>
        /// Переопределение метода Equals
        /// </summary>
        /// <param name="obj">объект для сравнения</param>
        /// <returns>bool результат сравнения</returns>
        public override bool Equals(object obj)
         {
             if (obj is Person && obj!=null)
             {
                 Person person = (Person) obj; 
                 bool compar = (this.FIO == person.FIO && this.DateBith == person.DateBith && this.PassportID==person.PassportID && this.PlaceBirth==person.PlaceBirth);
                 return compar;
             }
             else
             {
                 Console.WriteLine($"Сравнение объекта {this.GetType()} и {obj.GetType()} некорректно");
                 return false;
             }
         }

        /// <summary>
        /// Перегрузка оператора ==
        /// </summary>
        /// <param name="person1">объект сравнения</param>
        /// <param name="person2">объект сравнения</param>
        /// <returns>результат сравнения</returns>
        public static bool operator ==(Person person1, Person person2) => Equals(person1, person2);
        
        /// <summary>
        /// Перегрузка оператора !=
        /// </summary>
        /// <param name="person1">объект сравнения</param>
        /// <param name="person2">объект сравнения</param>
        /// <returns>результат сравнения</returns>
        public static bool operator !=(Person person1, Person person2) => !Equals(person1, person2);
    }
}
