using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace _11_INotifyPropertyChangedUniversal
{
    /// <summary>
    /// класс, реализующий интерфейс INotifyPropertyChanged
    /// создан, чтобы использовать в разных классах и не дублировать каждый раз код
    /// </summary>
    class NotifyPropertyChangedBaseClass : INotifyPropertyChanged
    { 
        /// <summary>
        /// Событие для уведомления об изменения значения свойств
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Вызывается аксессором Set свойства, при необходимости устанавливает значение
        /// </summary>
        /// <typeparam name="T">тип свойства</typeparam>
        /// <param name="field">ссылка на поле</param>
        /// <param name="value">значение, которое нужно установить</param>
        /// <param name="propertyName">название свойства</param>
        /// <returns>true, если значение изменено и false, если значение, которое нужно установить соответствует текущему</returns>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Вызов события
        /// </summary>
        /// <param name="propertyName">название свойства, которое было изменено</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
