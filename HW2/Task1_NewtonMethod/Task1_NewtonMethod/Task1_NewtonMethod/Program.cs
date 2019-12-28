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
    /// <summary>
    /// Class for work with user
    /// </summary>
    class Input
    {
        public double Value { get; set; }
        public double Root { get; set; }
        /// <summary>
        /// Method reuests user input and saves it.
        /// </summary>
        public void GetUserInput()
        {
            try
            {
                Console.WriteLine("Введите число");
                Value = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите корень вычисляемого числа");
                Root = double.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
        }
        
    }

    /// <summary>
    /// Class for calculations
    /// </summary>
    class MainCalculator
    {
        //Start parameters
        private double x0 = 1;
        const double approximation = 0.00000001;
        /// <summary>
        /// For calculation by the Newton Method
        /// </summary>
        /// <param name="val">Value</param>
        /// <param name="root">Roor</param>
        /// <returns>Calculated Value</returns>
        public double NewtonMethod(double val, double root)
        {
            double previosXn = x0;
            var delta = x0;

            try
            {
                while (approximation<delta)
                {
                    double functionX = ((Math.Pow(previosXn, root)) - val); // f(Xn-1) funcion
                    double derivativeFuncionX = (root * (Math.Pow(previosXn,root-1))); //f'(Xn-1) funciton
                    double Xn = previosXn - (functionX / derivativeFuncionX); // Xn = Xn-1 - f(Xn-1)/f'(Xn-1)
                    delta = Math.Abs(Xn - previosXn); // delta between last two calculation
                    previosXn = Xn;
                }
                return previosXn;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        /// <summary>
        /// For calculation by the Math library method
        /// </summary>
        /// <param name="val">user Value</param>
        /// <param name="root">user Root</param>
        /// <returns>Calculated Value</returns>
        public double StandartMethod(double val, double root)
        {
            try
            {
            double Xn = Math.Pow(val, (1 / root));
            return Xn;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        /// <summary>
        /// For compare two method results
        /// </summary>
        /// <param name="myMethodResult">Newton's method result</param>
        /// <param name="otherMerthodResult">Math method result</param>
        public void CompareMethods(double myMethodResult, double otherMerthodResult)
        {
            Console.WriteLine("Вычеслено методом Ньютона: " + myMethodResult);
            Console.WriteLine("Вычеслено стандартной библиотекой: " + otherMerthodResult);
            var differenceBetweenMethods = Math.Abs(myMethodResult - otherMerthodResult);
            Console.WriteLine("Разница между вычисленными значениями: " + differenceBetweenMethods);
        }
        
    }     

}

