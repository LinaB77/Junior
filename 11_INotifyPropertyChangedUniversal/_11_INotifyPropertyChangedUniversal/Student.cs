using System;
using System.Collections.Generic;
using System.Text;

namespace _11_INotifyPropertyChangedUniversal
{
    class Student : Person
    {
       /// <summary>
       /// шифр группы
       /// </summary>
        string groupNumber;
        public string GroupNumber
        {
            get { return groupNumber; }
            set { SetProperty(ref groupNumber, value); }
        }
    }
}
