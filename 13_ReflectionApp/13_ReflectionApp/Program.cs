using System;
using System.Reflection;
using System.Runtime.Remoting;

namespace _13_ReflectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly asm = Assembly.LoadFrom("ReflectionLibrary.dll");
            Type type = asm.GetType("ReflectionLibrary.Circle", true, true);

            // создаем экземпляр класса Circle
            object obj = Activator.CreateInstance(type, new object[] {});                

            // получаем метод Area
            MethodInfo methodArea = type.GetMethod("Area");

            Console.WriteLine("-----Вызываем метод Area");
            object result = methodArea.Invoke(obj, null);
            Console.WriteLine($"Площадь круга (значение радиуса по умолчанию =1 ): {result}");
            Console.WriteLine();

            Console.WriteLine("\n-----Вызов приватного статического метода c параметром");
            Console.WriteLine("Введите радиус круга:");
            int radius = Convert.ToInt32(Console.ReadLine());
            MethodInfo methodM = type.GetMethod("DisplayAll", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
            methodM.Invoke(obj, new object[] {radius});

            Console.WriteLine("\n-----Создание экземпляра класса по строковому наименованию");
            ObjectHandle handle = Activator.CreateInstance("ReflectionLibrary", "ReflectionLibrary.Circle");
            Object objCircle = handle.Unwrap();
            Type typeC = objCircle.GetType();

            Console.WriteLine("\n-----Закрытые поля: Тип\\Имя\\Значение");
            foreach (FieldInfo field in typeC.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static))
            {
                Console.WriteLine($"{field.FieldType} {field.Name} {field.GetValue(objCircle)}");
            }
                               
            Console.WriteLine("\n-----Закрытые свойства: Тип\\Имя\\Значение");
            foreach (PropertyInfo prop in typeC.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static))
            {
                Console.WriteLine($"{prop.PropertyType} {prop.Name} {prop.GetValue(objCircle)}");
            }             
                     
            Console.ReadLine();
        }
    }
}
