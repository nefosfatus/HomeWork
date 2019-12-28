using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_ConvertToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create instances
            Input input = new Input();
            Converter converter = new Converter();

            //Initialize user input
            input.getUserInput();
            uint userInput = input.UserInput;

            //Сonvert user input to binary form
            string binaryString = converter.ConvertUserInput(userInput);
            string ownBinaryString = converter.ConvertUserInputByAlgorythm(userInput);

            //User output
            Console.WriteLine("(Стандарт)Ваше число в двоичной форме:   " + binaryString);
            Console.WriteLine("(Алгоритм)Ваше число в двоичной форме:   " + ownBinaryString);
            Console.ReadKey();
        }


    }

    /// <summary>
    /// Class for work with user
    /// </summary>
    class Input
    {
        public uint UserInput { get; set; }
        /// <summary>
        /// Method reuests user input and saves it.
        /// </summary>
        public void getUserInput()
        {
            Console.WriteLine("Введите целое число:");
            UserInput = uint.Parse(Console.ReadLine());
        }
    }

    /// <summary>
    /// Class for convert to binary string 
    /// </summary>
    class Converter
    {
        /// <summary>
        /// Convert by library method
        /// </summary>
        /// <param name="userInputValue">user input</param>
        /// <returns>binary string</returns>
        public string ConvertUserInput(uint userInputValue)
        {
            string binaryString = Convert.ToString(userInputValue, 2);
            return binaryString;
        }
        /// <summary>
        /// Convert by algorythm
        /// </summary>
        /// <param name="userInputValue">user input</param>
        /// <returns>binary string</returns>
        public string ConvertUserInputByAlgorythm(uint userInputValue)
        {
            string binaryString = "";
            uint store;
            while (userInputValue > 0)
            {
                store = userInputValue % 2;
                userInputValue /= 2;
                binaryString = store.ToString() + binaryString;

            }
            return binaryString;
        }
    }
}
