using System;


namespace _7_Comparable
{
    /// <summary>
    /// Класс квадрат, реализующий интерфейс IComparable
    /// </summary>
    class Square : IComparable<Square>
    {
        protected double area;
        /// <summary>
        /// Площадь квадрата
        /// </summary>
        public double Area
        {
            get
            {
                return this.area;
            }
            set
            {
                this.area = value;
            }
        }
       /// <summary>
       /// Периметр квадрата
       /// </summary>
        public double Perimeter
        {
            get
            {
                return Math.Sqrt(this.area)*4;
            }
            set
            {
               this.area = Math.Pow((value/4),2);
            }
        }

        /// <summary>
        /// Реализация метода CompareTo интерфейса IComparable
        /// </summary>
        /// <param name="square"></param>
        /// <returns>int (= return 0, >return 1, < return-1)</returns>
        public int CompareTo(Square square)
        {
            return this.Area.CompareTo(square.Area);
        }
    }
    
}
