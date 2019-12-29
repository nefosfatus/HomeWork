using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Euclidian_Algorithm
{
    /// <summary>
    /// Class for work with user input
    /// </summary>
    class Input
    {
        /// <summary>
        /// Asks for a number from the user
        /// </summary>
        /// <returns>User's number</returns>
        public int AskNumber()
        {
            try
            {
                Console.WriteLine("Введите число");
                var answer = int.Parse(Console.ReadLine());
                return answer;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Пожалуйста введите целое число");
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        /// <summary>
        /// Get count of numbers for GCD
        /// </summary>
        /// <returns>count of numbers for GCD</returns>
        public int GetUserInput()
        {
            try
            {
                Console.WriteLine("Здравствуйте, для скольки чисел нужно найти НОД?");
                int countOfNumbers = int.Parse(Console.ReadLine());
                if (countOfNumbers > 5)
                {
                    Console.WriteLine("Извините программа поддерживает вычисление НОД до 5-ти чисел");
                    return 0;
                }
                else if (countOfNumbers <= 0)
                {
                    Console.WriteLine("Введите число больше нуля");
                    return 0;
                }
                else
                {
                    return countOfNumbers;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Пожалуйста, введите целое число");
                Console.WriteLine(ex.Message);
                return 0;
            }

        }
    }
}
