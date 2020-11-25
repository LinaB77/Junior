using System;
using System.Runtime.InteropServices;

namespace OOP1
{
    class Program
    {
        static void Main(string[] args)
        {
            var figures = new Figure[] { 
                new FigureSquare() { Name = "Квадрат",Side =5 },
                new FigureSquareParallelepiped() { Name = "Параллелепипед", Side = 1, Height =7 } };
            foreach (var figure in figures)
            {
                figure.Print(); 
            }
        }
    }
}
