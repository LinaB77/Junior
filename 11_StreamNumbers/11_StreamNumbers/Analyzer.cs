using System;
using System.Collections.Generic;
using System.Text;

namespace _11_StreamNumbers
{
    class Analyzer
    {
        public event EventHandler<UserEventArgs> NumberDifferently;
        /// <summary>
        /// заданное число
        /// </summary>
        public int GivenNumber { get; set; }
        /// <summary>
        /// заданный процент
        /// </summary>
        public int GivenPercentage { get; set; }
        private int difference;
        
        /// <summary>
        /// Метод, анализирующий число. При выполнении условия вызывается событие
        /// </summary>
        /// <param name="number">число для анализа</param>
        public void AnalizeNumber(int number)
        {
            difference = GivenNumber * GivenPercentage/100;
            if (number > GivenNumber + difference || number < GivenNumber - difference)
            {
                OnNumberDifferently(new UserEventArgs { Message = $"Число {number} отличается от числа {GivenNumber} более чем на {GivenPercentage}%" });

            }
        }
        /// <summary>
        /// вызов события
        /// </summary>
        /// <param name="e">информация о событии</param>
        public void OnNumberDifferently(UserEventArgs e)
        { 
            NumberDifferently?.Invoke(this,e);
        }
    }
}
