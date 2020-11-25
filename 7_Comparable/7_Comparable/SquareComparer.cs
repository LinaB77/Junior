using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _7_Comparable
{
    /// <summary>
    /// Класс реализует интерфейс IComparer
    /// </summary>
    class SquareComparer : IComparer<Square>
    {
        public int Compare(Square square1, Square square2)
        {
          return new CaseInsensitiveComparer().Compare(square2.Perimeter, square1.Perimeter);
        }
    }
}
