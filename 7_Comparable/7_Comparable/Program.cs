using System;
using System.Collections.Generic;
using System.Linq;

namespace _7_Comparable
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Square[] squaresArray = new Square[10];
            for (int i=0;i<10;i++)
            {
                squaresArray[i]=new Square{Area=rand.Next(10,50)};
            }
            
            Console.WriteLine("Сортировка площади квадратов по убыванию:");
            var sortArray = squaresArray.OrderByDescending(s => s).ToArray();
            foreach (Square square in sortArray)
            {
                Console.WriteLine($"{square.Area}");
            }

            Console.WriteLine("\nСортировка периметра квадратов также по убыванию:");
            Array.Sort(squaresArray, new SquareComparer());
            foreach (Square square in squaresArray)
            {
                Console.WriteLine("{0:f}",square.Perimeter);
            }
        }
    }
}
