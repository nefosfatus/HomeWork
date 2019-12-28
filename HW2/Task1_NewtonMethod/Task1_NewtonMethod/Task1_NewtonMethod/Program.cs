using MathNet.Symbolics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace Task1_NewtonMethod
{
    class Program
    {
        static void Main(string[] args)
        {

            MainCalculator calculator = new MainCalculator();
            Input userInput = new Input();

            userInput.GetUserInput();

            double userValue = userInput.Value;
            double userRoot = userInput.Root;
            double myValue = calculator.NewtonMethod(userValue, userRoot);
            double mathValue = calculator.StandartMethod(userValue, userRoot);
            calculator.CompareMethods(myValue, mathValue);

            Console.ReadKey();
        }



    }
    /// <summary>
    /// Класс для работы с входными данными
    /// </summary>
    class Input
    {
        public double Value { get; set; }
        public double Root { get; set; }
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

    class MainCalculator
    {
        private double x0 = 1;
        const double approximation = 0.00000001;

        public double NewtonMethod(double val, double root)
        {
            double xk = x0;
            var delta = x0;
            var counter = 0;

            while (approximation<delta)
            {
                double funcX = ((Math.Pow(xk, root)) - val);
                double derivativeX = (root * (Math.Pow(xk,root-1)));
                double Xn = xk - (funcX / derivativeX);
                delta = Math.Abs(Xn - xk);
                xk = Xn;
                Console.WriteLine(Xn);
                counter++;
            }
            return xk;
        }
        public double StandartMethod(double val, double root)
        {
            double Xn = Math.Pow(val, (1 / root));
            return Xn;
        }

        public void CompareMethods(double myMethodResult, double otherMerthodResult)
        {
            Console.WriteLine("Вычеслено методом Ньютона: " + myMethodResult);
            Console.WriteLine("Вычеслено стандартной библиотекой: " + otherMerthodResult);
            var differenceBetweenMethod = Math.Abs(myMethodResult - otherMerthodResult);
            Console.WriteLine("Разница между вычисленными значениями: " + differenceBetweenMethod);
        }
        
    }     

}

