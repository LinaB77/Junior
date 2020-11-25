using System;
using System.Collections.Generic;
using System.Text;

namespace _2_ICloneable
{
    /// <summary>
    /// Расположение книги
    /// </summary>
    public struct Location
    {
        /// <summary>
        /// Номер стеллажа
        /// </summary>
        public int Rack { get; set; }
        /// <summary>
        /// Шифр
        /// </summary>
        public string Code { get; set; }

        public Location(int rack, string code)
        {
            this.Rack = rack;
            this.Code = code;
        }
    }
}
