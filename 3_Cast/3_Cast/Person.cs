
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Cast
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        /// <summary>
        /// переопределение оператора явного преобразования от string к Person
        /// </summary>
        /// <param name="transform"></param>
        public static explicit operator Person(string transform)
        {
            if (transform == "")
            {
                return new Person("","");
            }
            else
            {
                string[] words = transform.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return new Person(words[0], words[1]);
            }
        }

        /// <summary>
        /// переопределение оператора неявного преобразования от Person к string
        /// </summary>
        /// <param name="person"></param>
        public static implicit operator string(Person person)
        {
            if (person != null)
            {
                return person.FirstName +" "+ person.LastName;              
            }
            else
            {
                return "";
            }
        }
    }
}
