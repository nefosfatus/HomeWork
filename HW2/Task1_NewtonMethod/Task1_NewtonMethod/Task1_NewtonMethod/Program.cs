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
        }



    }
    /// <summary>
    /// Класс для работы с входными данными
    /// </summary>
    class Input
    {
        public void GetUserInput() 
        {
            Console.WriteLine("Введите уравнение");
            var userEquation = Console.ReadLine();
            Console.WriteLine("Введите необходимую точность");
            var accuracy = decimal.Parse(Console.ReadLine());
            var userEquationParsed = Infix.ParseOrThrow(userEquation);
        }
        
        

    }
}
