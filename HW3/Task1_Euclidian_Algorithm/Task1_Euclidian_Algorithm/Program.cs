using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_Euclidian_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create instances
            Calculator calculator = new Calculator();
            Input input = new Input();

            //Initialize user input
            int amountOfNumbers = input.GetUserInput();

            //Calculate Greatest Common Divisor
            var GCD = calculator.ChooseOverload(amountOfNumbers);

            //User output
            Console.WriteLine("НОД для Ваших чисел: " + GCD);
            Console.ReadLine();

        }
    }
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

    class Calculator
    {
        Input calculatorInput = new Input();
        public int cache { get; set; }
        public int GetGreatestCommonDivisor(int firstNumber, int secondNumber)
        {
            try
            {
                int greaterNumber = Math.Max(firstNumber, secondNumber);
                int smallerNumber = Math.Min(firstNumber, secondNumber);

                while (smallerNumber != 0)
                {
                    cache = greaterNumber % smallerNumber;
                    greaterNumber = smallerNumber;
                    smallerNumber = cache;
                }
                return greaterNumber;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public int GetGreatestCommonDivisor(int firstNumber, int secondNumber, int thirdNumber)
        {

            var GCD = GetGreatestCommonDivisor(firstNumber, secondNumber);
            var GCD2 = GetGreatestCommonDivisor(thirdNumber, GCD);
 
            return GCD2;
        }

        public int GetGreatestCommonDivisor(int firstNumber, int secondNumber, int thirdNumber, int fourthNumber)
        {

            var GCD = GetGreatestCommonDivisor(firstNumber, secondNumber);
            var GCD2 = GetGreatestCommonDivisor(thirdNumber, GCD);
            var GCD3 = GetGreatestCommonDivisor(fourthNumber, GCD2);

            return GCD3;
        }

        public int GetGreatestCommonDivisor(int firstNumber, int secondNumber, int thirdNumber, int fourthNumber, int fifthNumber)
        {

            var GCD = GetGreatestCommonDivisor(firstNumber, secondNumber);
            var GCD2 = GetGreatestCommonDivisor(thirdNumber, GCD);
            var GCD3 = GetGreatestCommonDivisor(fourthNumber, GCD2);
            var GCD4 = GetGreatestCommonDivisor(fifthNumber, GCD3);

            return GCD4;
        }
        public int ChooseOverload(int amountOfNumbers)
        {
            if (amountOfNumbers == 1)
            {
                var GCD = calculatorInput.AskNumber();
                return GCD;
            }
            else if (amountOfNumbers == 2)
            {
                var firstInput = calculatorInput.AskNumber();
                var secondInput = calculatorInput.AskNumber();
                var GCD = GetGreatestCommonDivisor(firstInput, secondInput);

                return GCD;
            }
            else if (amountOfNumbers == 3)
            {
                var firstInput = calculatorInput.AskNumber();
                var secondInput = calculatorInput.AskNumber();
                var thirdInput = calculatorInput.AskNumber();
                var GCD = GetGreatestCommonDivisor(firstInput, secondInput,thirdInput);

                return GCD;
            }
            else if (amountOfNumbers == 4)
            {
                var firstInput = calculatorInput.AskNumber();
                var secondInput = calculatorInput.AskNumber();
                var thirdInput = calculatorInput.AskNumber();
                var fourthInput = calculatorInput.AskNumber();
                var GCD = GetGreatestCommonDivisor(firstInput, secondInput, thirdInput, fourthInput);

                return GCD;
            }
            else if (amountOfNumbers == 5)
            {
                var firstInput = calculatorInput.AskNumber();
                var secondInput = calculatorInput.AskNumber();
                var thirdInput = calculatorInput.AskNumber();
                var fourthInput = calculatorInput.AskNumber();
                var fifthInput = calculatorInput.AskNumber();
                var GCD = GetGreatestCommonDivisor(firstInput, secondInput, thirdInput, fourthInput,fifthInput);

                return GCD;
            }
            else
            {
                return 0;
            }
        }

    }

}
