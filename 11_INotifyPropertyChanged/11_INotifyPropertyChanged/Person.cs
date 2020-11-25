using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace _11_INotifyPropertyChanged
{
    class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string fio;
        private int age;
        private string placeJob;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Фамилия, имя отчество
        /// </summary>
        public string FIO
        {
            get
            {
                return this.fio;
            }
            set
            {
                if (value != this.fio)
                {
                    this.fio = value;
                    NotifyPropertyChanged();
                }
            } 
        }   
        /// <summary>
        /// Количество лет
        /// </summary>
        public int Age {
            get { return this.age; }
            set
            {
                if (value != this.age)
                {
                    this.age = value;
                    NotifyPropertyChanged();
                }
            }
        }
        /// <summary>
        /// место работы
        /// </summary>
        public string  PlaceJob
        { 
            get=>placeJob;
            set {
                if (value != this.placeJob)
                {
                    this.placeJob = value;
                    NotifyPropertyChanged();
                }
            }
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
                Person person = (Person)obj;
                bool compar = (this.FIO == person.FIO && this.PlaceJob == person.PlaceJob && this.Age == person.Age);
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
            return this.FIO + ", " + this.Age + ", " + this.PlaceJob;
        }
    }
}
