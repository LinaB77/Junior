using System;
using System.Collections.Generic;
using System.Text;

namespace _11_Event
{
    class UserEventArgs : EventArgs
    {
        /// <summary>
        /// сообщение с информацией о событии
        /// </summary>
        public string Message { get; set; }
    }
}
