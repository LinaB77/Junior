using System;

namespace _2_ICloneable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Пример поверхностного копирования");
            Console.ResetColor();
            Location local = new Location(7, "Прогр-23п/pr");
            Book book1 = new Book("Совершенный код", "Стив Макконнелл", 896, 2019, local);
            Book book2 = (Book)book1.Clone();
            book1.YearPubl = 2020;
            book1.Local = new Location(5, "23п/pr");
            book1.Display();
            book2.Display();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Пример глубокого копирования");
            Console.ResetColor();
            local = new Location(3, "Уч-27c/dict");
            Dictionary dictionary1 = new Dictionary(" Современный англо-русский и русско-английский словарь", "Владимир Мюллер", 768, 2020, local, null);
            Dictionary dictionary2 = (Dictionary)dictionary1.Clone();
            dictionary1.Type.NameСategory = "Учебная. Словари и разговорники";
            dictionary1.Display();
            dictionary2.Display();
        }
    }
}
