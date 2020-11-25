using System;
using System.Collections.Generic;
using System.Text;

namespace _11_INotifyPropertyChangedUniversal
{
    class Teacher:Person
    {
        /// <summary>
        /// должность
        /// </summary>
        string position;
        public string Position
        {
            get { return position; }
            set { SetProperty(ref position, value); }
        }
    }
}
