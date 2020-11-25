using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializableApp
{
    class Program
    {
        static void Main(string[] args)
        {           
            Person[] pers = new Person[]
            {
                 new Person() { FIO = "Игнатьев Сергей Федорович", DateBith = new DateTime(1987, 11, 27), PassportID = "FH 951958", PlaceBirth = "Тирасполь" },
                 new Person() { FIO = "Фомина Инна Васильевна", DateBith = new DateTime(1990, 5, 16), PassportID = "PH 925987", PlaceBirth = "Москва" },
                 new Person() { FIO = "Липатников Михаил Степанович", DateBith = new DateTime(1989, 3, 20), PassportID = "SD 005903", PlaceBirth = "Незавертайловка" }
            };

            //json сериализация
            JsonSerializerMethod(pers);

            //бинарная сериализация
            BinarySerializerMethod(pers);
           
            //xml сериализация
            XmlSerializerMethod();

           
        }
              
       
        /// <summary>
        /// бинарная сериализация/десериализация
        /// </summary>
        /// <param name="people">Person[]</param>
        public static void BinarySerializerMethod(Person[] people)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStreamBs = new FileStream("people.txt", FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fileStreamBs, people);
                Console.WriteLine("\nМассив объектов сериализован и записан в файл people.txt");
            }
            //бинарная десериализация
            Person[] restoredPeople;
            using (FileStream fileStreamBDs = new FileStream("people.txt", FileMode.OpenOrCreate))
            {
                restoredPeople = (Person[])binaryFormatter.Deserialize(fileStreamBDs);
                Console.WriteLine("Данные считаны из файла  people.txt и десериализованы в массив объектов Person");
            }
        }

        /// <summary>
        /// Json сериализация/десериализация
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        static async void JsonSerializerMethod(Person[] people)
        {           
            using (FileStream fileStreamJs = new FileStream("people.json", FileMode.OpenOrCreate))
            {              
                 JsonSerializer.SerializeAsync<Person[]>(fileStreamJs, people);
                Console.WriteLine("\nМассив объектов сериализован и записан в файл people.json");
            }

            // чтение данных
            using (FileStream fileStreamDJs = new FileStream("people.json", FileMode.OpenOrCreate))
            {
                Person[] restoredPeople = await JsonSerializer.DeserializeAsync<Person[]>(fileStreamDJs);
                Console.WriteLine("Данные считаны из файла people.json и десериализованы в массив объектов Person");
            }
        }

        /// <summary>
        /// Xml сериализация/десериализация
        /// </summary>
        private static void XmlSerializerMethod()
        {
            Person[] people = new Person[]
              {
                 new Person() { FIO = "Игнатьев Сергей Федорович", DateBith = new DateTime(1987, 11, 27), PassportID = "FH 951958", PlaceBirth = "Тирасполь" },
                 new Person() { FIO = "Фомина Инна Васильевна", DateBith = new DateTime(1990, 5, 16), PassportID = "PH 925987", PlaceBirth = "Москва" },
                 new Person() { FIO = "Липатников Михаил Степанович", DateBith = new DateTime(1989, 3, 20), PassportID = "SD 005903", PlaceBirth = "Незавертайловка" }
              };
            Avto[] avtos = new Avto[] 
            { 
                new Avto(){Brand="Audi", ReleaseDate=new DateTime(2010,2,11),Mileage=100000, Onwers=people},
                new Avto(){Brand="Reno", ReleaseDate=new DateTime(2017,5,23),Mileage=9000, Onwers=new Person[]{new Person { FIO = "Фомина Инна Васильевна", DateBith = new DateTime(1990, 5, 16), PassportID = "PH 925987", PlaceBirth = "Москва" } } },
                new Avto(){Brand="BMV", ReleaseDate=new DateTime(2016,11,06),Mileage=25000, Onwers=people}
            };

            XmlSerializer xmlFormatter = new XmlSerializer(typeof(Avto[]));
            using (FileStream fileStreamXs = new FileStream("avto.xml", FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(fileStreamXs, avtos);
                Console.WriteLine("\nМассив объектов сериализован и записан в файл avto.xml");

            }

            using (FileStream fileStreamXDs = new FileStream("avto.xml", FileMode.OpenOrCreate))
            {
                Avto[] restoredAvtos = (Avto[])xmlFormatter.Deserialize(fileStreamXDs);
                Console.WriteLine("Данные считаны из файла avto.xml и десериализованы в массив объектов Avto");
            }
        }
    }
}
