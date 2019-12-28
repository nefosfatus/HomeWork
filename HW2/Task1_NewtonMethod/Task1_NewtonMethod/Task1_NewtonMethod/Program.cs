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
            calculator.NewtonMethd(81,4);
            Console.ReadKey();
        }



    }
    /// <summary>
    /// Класс для работы с входными данными
    /// </summary>
    class Input
    {
        public void GetUserInput()
        {
            try
            {
                Console.WriteLine("Введите число");
                var userValue = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Введите корень вычисляемого числа");
                var userRoot = decimal.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
        }
        public decimal Value { get; }
        public decimal Root { get; }
    }

    class MainCalculator
    {
        private double x0 = 1;
        const double approximation = 0.000000000000001;

        public decimal NewtonMethd(double val, double root)
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
            return 6;
            


        }
        
    }     

}

