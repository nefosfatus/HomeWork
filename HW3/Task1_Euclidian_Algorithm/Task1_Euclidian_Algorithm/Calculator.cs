using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task1_Euclidian_Algorithm.Time;

namespace Task1_Euclidian_Algorithm
{
    /// <summary>
    /// Class for computing 
    /// </summary>
    public class Calculator
    {
        Input calculatorInput = new Input();
        private int cache { get; set; }
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
                using (var bench = new Benchmark("Время выполнения вычисления по алгоритму Ньютона: ")) //Execution time
                {
                    //Compute greater number 
                    int greaterNumber = Math.Max(firstNumber, secondNumber);
                    int smallerNumber = Math.Min(firstNumber, secondNumber);

                    while (smallerNumber != 0)
                    {
                        cache = greaterNumber % smallerNumber;
                        greaterNumber = smallerNumber;
                        smallerNumber = cache;
                    }
                    return Math.Abs(greaterNumber);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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

            var GCD = GetGreatestCommonDivisor(firstNumber, secondNumber, thirdNumber);
            var GCD3 = GetGreatestCommonDivisor(fourthNumber, GCD);

            return GCD3;
        }
        /// <summary>
        /// Overload for main method for 5 numbers
        /// </summary>
        public int GetGreatestCommonDivisor(int firstNumber, int secondNumber, int thirdNumber, int fourthNumber, int fifthNumber)
        {

            var GCD = GetGreatestCommonDivisor(firstNumber, secondNumber, thirdNumber, fourthNumber);
            var GCD4 = GetGreatestCommonDivisor(fifthNumber, GCD);

            return GCD4;
        }

        /// <summary>
        /// Method to choose which overload to use
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
            if (amountOfNumbers == 2)
            {
                var firstInput = calculatorInput.AskNumber();
                var secondInput = calculatorInput.AskNumber();
                var GCD = GetGreatestCommonDivisor(firstInput, secondInput);

                return GCD;
            }
            if (amountOfNumbers == 3)
            {
                var firstInput = calculatorInput.AskNumber();
                var secondInput = calculatorInput.AskNumber();
                var thirdInput = calculatorInput.AskNumber();
                var GCD = GetGreatestCommonDivisor(firstInput, secondInput, thirdInput);

                return GCD;
            }
            if (amountOfNumbers == 4)
            {
                var firstInput = calculatorInput.AskNumber();
                var secondInput = calculatorInput.AskNumber();
                var thirdInput = calculatorInput.AskNumber();
                var fourthInput = calculatorInput.AskNumber();
                var GCD = GetGreatestCommonDivisor(firstInput, secondInput, thirdInput, fourthInput);

                return GCD;
            }
            if (amountOfNumbers == 5)
            {
                var firstInput = calculatorInput.AskNumber();
                var secondInput = calculatorInput.AskNumber();
                var thirdInput = calculatorInput.AskNumber();
                var fourthInput = calculatorInput.AskNumber();
                var fifthInput = calculatorInput.AskNumber();
                var GCD = GetGreatestCommonDivisor(firstInput, secondInput, thirdInput, fourthInput, fifthInput);

                return GCD;
            }
            return 0;
            
        }
        /// <summary>
        /// Main method calculates GCD according to the Stain algorithm
        /// </summary>
        /// <param name="firstInput">First number</param>
        /// <param name="secondInput">Second number</param>
        /// <returns>GCD</returns>
        public int GetGCDbySteinAlgorithm(int firstInput, int secondInput)
        {
            using (var bench = new Benchmark("Время выполнения вычисления по алгоритму Стейна: ")) //Execution time
            {
                if (firstInput == secondInput)
                {
                    return firstInput;
                }
                if (firstInput == 0 || secondInput == 0)
                {
                    return secondInput;
                }
                if (firstInput == 1 || secondInput == 1)
                {
                    return 1;
                }
                if (((firstInput & 1) == 0) && ((secondInput & 1) == 0)) //if both even
                {
                    var answer = 2 * GetGCDbySteinAlgorithm(firstInput / 2, secondInput / 2);
                    return answer;
                }
                if (((firstInput & 1) == 0) && ((secondInput & 1) != 0))    //if only first even
                {
                    var answer = GetGCDbySteinAlgorithm(firstInput / 2, secondInput);
                    return answer;
                }
                if (((firstInput & 1) != 0) && ((secondInput & 1) == 0))  //if only second even
                {
                    var answer = GetGCDbySteinAlgorithm(firstInput, secondInput / 2);
                    return answer;
                }
                if (((firstInput & 1) != 0) && ((secondInput & 1) != 0))       //if both odd
                {
                    var answer = GetGCDbySteinAlgorithm(secondInput, Math.Abs(firstInput - secondInput));
                    return answer;
                }
                return 0;
            }
        }
    }
}
