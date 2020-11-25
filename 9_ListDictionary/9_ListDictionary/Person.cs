using System;


namespace _9_ListDictionary
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
        public string PassportID { get; set; }

        /// <summary>
        /// Переопределение метода GetHashCode()
        /// </summary>
        /// <returns>хеш-код</returns>
        public override int GetHashCode()
        {
           return PassportID.GetHashCode()^DateBith.Day;
        }

        /// <summary>
        /// Переопределение метода Equals
        /// </summary>
        /// <param name="obj">объект для сравнения</param>
        /// <returns>bool результат сравнения</returns>
        public override bool Equals(object obj)
         {
             if (obj is Person)
             {
                 Person person = (Person) obj; 
                 bool compar = (this.FIO == person.FIO && this.DateBith == person.DateBith && this.PassportID==person.PassportID && this.PlaceBirth==person.PlaceBirth);
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
    }
}
