using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.VisualBasic;

namespace _6_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LINQ на примере группы автолюбителей\n");
            List<Motorist> motoristsList = Generation();
            bool isWork = true;
            while (isWork)
            {
                Console.WriteLine("\nВведите номер команды:");
                Console.WriteLine("1. Любители отечественных марок, имеющие еще одно авто \n" +
                                  "2. Сортировка по имени и марке авто  \n" +
                                  "3. Группировка по марке авто\n" +
                                  "4. Наличие автолюбителей, верных своим авто более 20 лет\n" +
                                  "5. Минимальный\\максимальный стаж вождения\n" +
                                  "6. Выход из программы");
               
                int action = Convert.ToInt32(Console.ReadLine());
                switch (action)
                {
                    case 1: 
                        OnlyCar(motoristsList);
                        break;
                    case 2: 
                        Sort(motoristsList);
                        break;
                    case 3: 
                        Group(motoristsList);
                        break;
                    case 4:
                        AllAny(motoristsList);
                        break;
                    case 5: 
                        MinMax(motoristsList);
                        break;
                    case 6:
                        isWork = false;
                        continue;
                    default:
                        Console.WriteLine("\nВы ввели неверную команду");
                        continue;
                }
            }
        }

        /// <summary>
        /// Метод генерирует 100 случайных объектов класса Motorist
        /// </summary>
        /// <returns>List<Motorist></returns>
        public static List<Motorist> Generation()
        {
            List<Motorist> motoristsList = new List<Motorist>();
            string[] names =
            {
                "Иван", "Петр", "Андрей", "Валерий", "Сергей", "Александр", "Степан", "Владимир", "Николай",
                "Владислав", "Кирилл", "Мефодий", "Михаил", "Евгений", "Дмитрий", "Павел", "Вячеслав", "Василий",
                "Захар", "Виктор", "Яков", "Никита", "Станислав", "Вадим", "Виктория", "Ирина"
            };
            string[] brands =
            {
                "Audi", "BMW", "Lada", "Нива", "Volvo", "Suzuki", "Lexus", "ZAZ", "Porsche", "Mercedes", "KIA",
                "Hummer", "Hyundai", "Honda", "Nissan", "Ford", "Volkswagen", "Toyota"
            };
            int namesCount = names.Length;
            int brandsCount = brands.Length;
            var rand = new Random();
            DateTime date;
            int experience;

            for (int i = 0; i < 100; i++)
            {
                date = DateTime.Today.AddDays(-rand.Next(10950));
                experience = rand.Next(DateTime.Today.Year - date.Year, 41);
                motoristsList.Add(new Motorist
                {
                    Name = names[rand.Next(0, namesCount)], Brand = brands[rand.Next(0, brandsCount)], BuyDate = date,
                    Experience = experience, OnlyCar = rand.Next(2) == 0 ? false : true
                });
            }
            return motoristsList;
        }

        /// <summary>
        /// Выборка автолюбителей имеющих еще одно авто, кроме отечественого автомобиля
        /// </summary>
        /// <param name="motoristsList">List<Motorist></param>
        public static void OnlyCar(List<Motorist> motoristsList)
        {
            Console.WriteLine("\n-------Любители отечественных марок, имеющие еще одно авто:");
            var selectedOnlyCar = (from motorist in motoristsList
                                   where !motorist.OnlyCar &&
                                         (motorist.Brand == "Лада" || motorist.Brand == "Нива" || motorist.Brand == "ZAZ")
                                   select motorist).ToList();

            foreach (Motorist motorist in selectedOnlyCar)
            {
                Console.WriteLine($"{motorist.Name} - {motorist.Brand}, купил {motorist.BuyDate.ToShortDateString()}");
            }
        }

        /// <summary>
        /// Сортировка по имени и марке авто
        /// </summary>
        /// <param name="motoristsList">List<Motorist></param>
        public static void Sort(List<Motorist> motoristsList)
        {
            Console.WriteLine("\n-------Сортировка по имени и марке авто:");
            var sortList = motoristsList.OrderBy(motorist => motorist.Name).ThenBy(motorist => motorist.Brand).ToList();
            foreach (Motorist motorist in sortList)
            { 
                Console.WriteLine($"{motorist.Name} - {motorist.Brand}"); 
            }
        }

        /// <summary>
        /// Группировка по марке авто
        /// </summary>
        /// <param name="motoristsList">List<Motorist></param>
        public static void Group(List<Motorist> motoristsList)
        {

            Console.WriteLine("\n-------Группировка по марке авто:");
            var groupList = motoristsList.GroupBy(motorist => motorist.Brand)
                .Select(group =>
                    new
                    {
                        NameGr = group.Key,
                        CountGr = group.Count(),
                        Name = group.Select(onwer => onwer)
                    }).ToList();

            foreach (var group in groupList)
            {
                Console.WriteLine($"\n{group.NameGr} - {group.CountGr}:");
                foreach (Motorist motorist in group.Name)
                    Console.WriteLine($"   {motorist.Name}");
            }

        }
        /// <summary>
        /// Наличие автолюбителей, верных своим авто более 20 лет
        /// </summary>
        /// <param name="motoristsList">List<Motorist></param>
        public static void AllAny(List<Motorist> motoristsList)
        {

            Console.WriteLine("\n-------Автолюбители, верные своим авто более 20 лет:");
            bool rezultAllAny = motoristsList.All(m => (DateTime.Today.Year - m.BuyDate.Year) > 20);
            if (rezultAllAny)
            { 
                Console.WriteLine("Все автолюбители, более 20 лет пользуются своим авто"); 
            }
            else
            {
                Console.WriteLine("Не все автолюбители, более 20 лет пользуются своим авто");
            }

            rezultAllAny = motoristsList.All(m => (DateTime.Today.Year - m.BuyDate.Year) > 20);
            if (rezultAllAny)
            {
                Console.WriteLine("Есть автолюбители верные своим авто более 20 лет");
            }
            else
            {
                Console.WriteLine("Есть автолюбители, которые предпочитают менять авто чаще, чем раз в 20 лет)))");
            }
        }

        /// <summary>
        ///  Минимальный\максимальный стаж вождения
        /// </summary>
        /// <param name="motoristsList">List<Motorist></param>
        public static void MinMax(List<Motorist> motoristsList)
        {
            Console.WriteLine("\n-------Стаж водителей:");
            int minExperience = motoristsList.Min(m => m.Experience);
            Console.WriteLine($"Минимальный стаж вождения: {minExperience}");
            int maxExperience = motoristsList.Max(m => m.Experience);
            Console.WriteLine($"Максимальный стаж вождения: {maxExperience}");
        }
    }
}
