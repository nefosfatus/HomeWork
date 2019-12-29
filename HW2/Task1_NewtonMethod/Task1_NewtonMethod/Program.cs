using MathNet.Symbolics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace Task1_NewtonMethod
{
    /// <summary>
    /// Main class there will be called other programm components
    /// </summary>
    class Program
    {

        static void Main(string[] args)
        {
            //Create instances
            MainCalculator calculator = new MainCalculator();
            Input userInput = new Input();

            //Initialize user input
            userInput.GetUserInput();

            //Get user input
            double userValue = userInput.Value;
            double userRoot = userInput.Root;

            //Calculate by Newton method 
            double myValue = calculator.NewtonMethod(userValue, userRoot);
            //Calculate by Math library method
            double mathValue = calculator.StandartMethod(userValue, userRoot);
            //Compare mathods output
            calculator.CompareMethods(myValue, mathValue);

            Console.ReadKey();
        }
    }
}

