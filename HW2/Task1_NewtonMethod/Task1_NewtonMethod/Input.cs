using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_NewtonMethod
{
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
}
