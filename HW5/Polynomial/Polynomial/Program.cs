using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				//Create 1st polynomial
				Console.WriteLine(Environment.NewLine + "Создадим первый многочлен.");
				List<int> termsForFirstPoly = Input.AksToAddTerm();
				Polynomial polynomial1 = new Polynomial(termsForFirstPoly);
				Console.WriteLine(polynomial1.GetPolynomialString());

				//Create 2nd polynomial
				Console.WriteLine(Environment.NewLine + "Создадим второй многочлен.");
				List<int> termsForSecondPoly = Input.AksToAddTerm();
				Polynomial polynomial2 = new Polynomial(termsForSecondPoly);
				Console.WriteLine(polynomial2.GetPolynomialString());

				//Sum 
				Console.WriteLine("\nСумма созданных многочленов:");
				Polynomial sumOfPolynomials = polynomial1 + polynomial2;
				Console.WriteLine(sumOfPolynomials.GetPolynomialString());

				//Diff
				Console.WriteLine("Разность созданных многочленов:");
				Polynomial diffOfPolynomials = polynomial1 - polynomial2;
				Console.WriteLine(diffOfPolynomials.GetPolynomialString());

				//Multiply
				Console.WriteLine("Первый многочлен х10:");
				Polynomial multiPolynomial = polynomial1 * 10;
				Console.WriteLine(multiPolynomial.GetPolynomialString());

				Console.ReadKey();
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (FormatException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			
		}
	}
}
