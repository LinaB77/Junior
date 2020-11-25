using System;
using System.Collections.Generic;
using System.Text;

namespace OOP1
{
    /// <summary>
    /// Класс-наследник, описывающий параллелепипед
    /// </summary>
    public class FigureSquareParallelepiped : FigureSquare
    {
        /// <value>Высота геометрической фигуры</value>
        public int Height { get; set; }

        protected override int CalcArea()
        {
            return (base.CalcArea()) * 4 + 2 * Height * Side;
        }

        /// <summary>
        /// Вычисление объема фигуры
        /// </summary>
        /// <returns>объем</returns>
        private int CalcVolume()
        {
            return Height * (base.CalcArea());
        }

        public override void Print()
        {
            Console.WriteLine(Name);
            int area = CalcArea();
            Console.WriteLine("Площадь: {0}", area);
            Console.WriteLine("Объем: {0}", CalcVolume());
        }
    }
}
