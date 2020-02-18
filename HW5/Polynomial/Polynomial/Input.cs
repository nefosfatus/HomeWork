using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
	public static class Input
	{
		/// <summary>
		/// Ask user to add polynomial
		/// </summary>
		/// <returns>List of terms</returns>
		public static List<int> AksToAddTerm()
		{
			Console.WriteLine(Environment.NewLine + "Введите основания одночленов (через запятую)");
			string userInput = Console.ReadLine();
			string[] splitedData = userInput.Split(',');
			List<int> parsedData = new List<int>();
			foreach(var number in splitedData)
			{
				int parsedNumber;
				bool parseResult = int.TryParse(number, out parsedNumber);
				if (parseResult)
				{
					parsedData.Add(parsedNumber);
				}
				if (!parseResult)
				{
					throw new ArgumentException("Не верный формат вводимых данных");
				}
			}
			return parsedData;
		}
	}
}
