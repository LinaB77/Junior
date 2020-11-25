using System;
using System.Collections.Generic;
using System.Text;

namespace OOP1
{
    /// <summary>
    /// Базовый класс, описывающий фигуры
    /// P.S. в этом проекте все слишком очевидно), но для порядка напишу
    /// </summary>
    public abstract class Figure
    {

        /// <value>Название геометрической фигуры</value>
        public string Name { get; set; }

        /// <value>Длина строны геометрической фигуры</value>
        public int Side { get; set; }

        /// <summary>
        /// Вычисление площади фигуры
        /// </summary>
        /// <returns>площадь</returns>
        protected abstract int CalcArea();

        /// <summary>
        /// Вывод на экран информации о фигуре
        /// </summary>
        public virtual void Print()
        {
            Console.WriteLine(Name);
            int area = CalcArea();
            Console.WriteLine("Площадь: {0}", area);
            Console.WriteLine();
        }
    }
}
