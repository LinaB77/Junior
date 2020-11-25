using System;
using System.Collections.Generic;
using System.Text;

namespace OOP1
{

    /// <summary>
    /// Класс-наследник, описывающий квадрат
    /// </summary>
    public class FigureSquare : Figure
    {
        protected override int CalcArea()
        {
            return Side * Side;
        }
    }
}
