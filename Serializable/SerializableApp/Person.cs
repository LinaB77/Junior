using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SerializableApp
{
    [Serializable]
    public class Person
    {
        /// <summary> 
        /// ФИО, при Json сериализации имя свойства будет заменено на FullName
        /// </summary>
        /// Full name
        [JsonPropertyName("FullName")]
        public string FIO { get; set; }
        /// <summary>
        /// дата рождения
        /// </summary>
        public DateTime DateBith { get; set; }
        /// <summary>
        /// место рождения
        /// </summary>
        public string PlaceBirth { get; set; }
        /// <summary>
        /// Номер паспорта. При Json сериализации данное свойство будет игнорироваться
        /// </summary>
        [JsonIgnore]
        public string PassportID { get; set; }        
    }
}
