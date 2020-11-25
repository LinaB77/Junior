using System;
using System.ComponentModel;

namespace _11_INotifyPropertyChanged
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person() {FIO="Владыкин Павел Никитович",Age=25,PlaceJob="OfficeN" };
            person.PropertyChanged += Person_PropertyChanged;
            person.Age = 23;
        }

        private static void Person_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine($"Изменено свойство {e.PropertyName}");
        }
    }
}
