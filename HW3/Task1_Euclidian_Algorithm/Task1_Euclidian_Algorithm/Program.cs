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


            var asd = calculator.GetGCDbySteinAlgorithm(116150,232704);
            Console.WriteLine(asd);
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
    /// <summary>
    /// Class for computing 
    /// </summary>
    class Calculator
    {
        Input calculatorInput = new Input();
        public int cache { get; set; }
        /// <summary>
        /// Main method calculates GCD according to the Euclidean algorithm
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber">Second number </param>
        /// <returns>GCD</returns>
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
        /// <summary>
        /// Overload for main method for 3 numbers
        /// </summary>
        public int GetGreatestCommonDivisor(int firstNumber, int secondNumber, int thirdNumber)
        {

            var GCD = GetGreatestCommonDivisor(firstNumber, secondNumber);
            var GCD2 = GetGreatestCommonDivisor(thirdNumber, GCD);
 
            return GCD2;
        }
        /// <summary>
        /// Overload for main method for 4 numbers
        /// </summary>
        public int GetGreatestCommonDivisor(int firstNumber, int secondNumber, int thirdNumber, int fourthNumber)
        {

            var GCD = GetGreatestCommonDivisor(firstNumber, secondNumber);
            var GCD2 = GetGreatestCommonDivisor(thirdNumber, GCD);
            var GCD3 = GetGreatestCommonDivisor(fourthNumber, GCD2);

            return GCD3;
        }
        /// <summary>
        /// Overload for main method for 5 numbers
        /// </summary>
        public int GetGreatestCommonDivisor(int firstNumber, int secondNumber, int thirdNumber, int fourthNumber, int fifthNumber)
        {

            var GCD = GetGreatestCommonDivisor(firstNumber, secondNumber);
            var GCD2 = GetGreatestCommonDivisor(thirdNumber, GCD);
            var GCD3 = GetGreatestCommonDivisor(fourthNumber, GCD2);
            var GCD4 = GetGreatestCommonDivisor(fifthNumber, GCD3);

            return GCD4;
        }

        /// <summary>
        /// Method with choose which overload to use
        /// </summary>
        /// <param name="amountOfNumbers">Count of numbers which user sended</param>
        /// <returns>GCD</returns>
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
        public int GetGCDbySteinAlgorithm(int firstInput, int secondInput)
        {
            if (firstInput == secondInput)
            {
                return firstInput;
            }
            if (firstInput == 0)
            {
                return secondInput;
            }
            if (secondInput == 0)
            {
                return firstInput;
            }
            if(firstInput==1 || secondInput == 1)
            {
                return 1;
            }
            if(((firstInput&1)==0)&&((secondInput & 1) == 0))
            {
                var answer = 2 * GetGCDbySteinAlgorithm(firstInput / 2, secondInput / 2);
                return answer;
            }
            if (((firstInput & 1) == 0) && ((secondInput & 1) != 0))
            {
                var answer = GetGCDbySteinAlgorithm(firstInput / 2, secondInput);
                return answer;
            }
            if (((firstInput & 1) != 0) && ((secondInput & 1) == 0))
            {
                var answer = GetGCDbySteinAlgorithm(firstInput, secondInput/2);
                return answer;
            }
            if (((firstInput & 1) != 0) && ((secondInput & 1) != 0))
            {
                var answer = GetGCDbySteinAlgorithm(secondInput, Math.Abs(firstInput-secondInput));
                return answer;
            }
            else
            {
                return 0;
            }

        }

    }

}
