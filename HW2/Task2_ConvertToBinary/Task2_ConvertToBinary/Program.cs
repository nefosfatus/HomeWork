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

}
