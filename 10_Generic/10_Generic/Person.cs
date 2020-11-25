using System;
using System.Collections.Generic;
using System.Text;

namespace _10_Generic
{
    class Person
    {
        /// <summary>
        /// Фамилия, имя отчество
        /// </summary>
        public string FIO { get; set; }   
        /// <summary>
        /// Место рождения
        /// </summary>
        public string PlaceBirth { get; set; }
        /// <summary>
        /// номер паспорта
        /// </summary>
        public string  PassportID { get; set; }
        
        /// <summary>
        /// Переопределение метода Equals
        /// </summary>
        /// <param name="obj">объект для сравнения</param>
        /// <returns>bool результат сравнения</returns>
        public override bool Equals(object obj)
        {
            if (obj is Person)
            {
                Person person = (Person)obj;
                bool compar = (this.FIO == person.FIO && this.PassportID == person.PassportID && this.PlaceBirth == person.PlaceBirth);
                return compar;
            }
            else return false;
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
        /// <summary>
        /// переопределение метода ToString() для распечатки объектов класса
        /// </summary>
        /// <returns>строка, содержащая все поля объекта</returns>
        public override string ToString()
        {
            return this.FIO + ", " + this.PlaceBirth + ", " + this.PassportID;
        }
    }
}
