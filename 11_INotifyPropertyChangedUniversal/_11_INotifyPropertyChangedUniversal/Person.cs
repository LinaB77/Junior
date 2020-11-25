using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace _11_INotifyPropertyChangedUniversal
{
    class Person : NotifyPropertyChangedBaseClass
    {       
        private string fio;
        private int age;
        private string placeJob;

        /// <summary>
        /// Фамилия, имя отчество
        /// </summary>
        public string FIO
        {
            get { return this.fio; }
            set { SetProperty(ref fio, value); } 
        }   
        /// <summary>
        /// Количество лет
        /// </summary>
        public int Age 
        {
            get { return this.age; }
            set { SetProperty(ref age, value); }
        }
        /// <summary>
        /// место работы
        /// </summary>
        public string  PlaceJob
        { 
            get => placeJob;
            set => SetProperty(ref placeJob, value); 
        }     
    }
}
