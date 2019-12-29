using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_ConvertToBinary
{
    /// <summary>
    /// Class for convert to binary string 
    /// </summary>
    class Converter
    {
        /// <summary>
        /// Convert by library method
        /// </summary>
        /// <param name="userInputValue">user input</param>
        /// <returns>binary string</returns>
        public string ConvertUserInput(uint userInputValue)
        {
            string binaryString = Convert.ToString(userInputValue, 2);
            return binaryString;
        }
        /// <summary>
        /// Convert by algorythm
        /// </summary>
        /// <param name="userInputValue">user input</param>
        /// <returns>binary string</returns>
        public string ConvertUserInputByAlgorythm(uint userInputValue)
        {
            string binaryString = "";
            uint store;
            while (userInputValue > 0)
            {
                store = userInputValue % 2;
                userInputValue /= 2;
                binaryString = store.ToString() + binaryString;

            }
            return binaryString;
        }
    }
}
