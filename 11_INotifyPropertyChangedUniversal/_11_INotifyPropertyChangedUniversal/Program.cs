using System;
using System.ComponentModel;

namespace _11_INotifyPropertyChangedUniversal
{
    class Program
    {        
        static void Main(string[] args)
        {
            Person person = new Person() { FIO = "Владыкин Павел Никитович", Age = 25, PlaceJob = "OfficeN" };
            person.PropertyChanged += Person_PropertyChanged;
            person.Age = 23;
            person.PlaceJob = "Google";
           
            Student student = new Student();
            student.PropertyChanged += Person_PropertyChanged;
            student.GroupNumber = "2020PI";
            student.FIO = "Вася Пупкин";

            Teacher teacher = new Teacher();
            teacher.PropertyChanged += Person_PropertyChanged;
            teacher.Position = "Доцент";
            teacher.Age = 45;
        }

        private static void Person_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine($"Изменено свойство {e.PropertyName},\tобъект {sender.ToString()}");
        }
    }
}
