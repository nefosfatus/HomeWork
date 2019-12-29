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
}
