using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_ConvertToBinary
{
    /// <summary>
    /// Class for work with user
    /// </summary>
    class Input
    {
        public uint UserInput { get; set; }
        /// <summary>
        /// Method reuests user input and saves it.
        /// </summary>
        public void getUserInput()
        {
            Console.WriteLine("Введите целое число:");
            UserInput = uint.Parse(Console.ReadLine());
        }
    }
}
