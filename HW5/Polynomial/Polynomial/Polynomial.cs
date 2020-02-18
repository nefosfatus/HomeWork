using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
	public class Polynomial
	{
		/// <summary>
		/// Polynomial = term1 + term2 + ... + termN 
		/// <Terms> contains list of polymial's terms;
		/// </summary>
		public List<int> Terms { get; set; } = new List<int>();
		public Polynomial(List<int> terms)
		{
			this.Terms = terms;
		}
		/// <summary>
		/// To standart format
		/// </summary>
		/// <returns>Polynomial in standart string format</returns>
		public string GetPolynomialString()
		{
			string stringView = string.Empty;
			int degree = 0;
			foreach(var term in this.Terms)
			{
				if(degree==0)
					stringView = stringView + ($"({term})");
				if (degree > 0)
					stringView = stringView + ($"+({term}^{degree})");
				degree++;
			}
			return stringView;
		}
		/// <summary>
		/// Overload for sum operation
		/// </summary>
		/// <returns>leftPolynomial + rightPolynomial</returns>
		public static Polynomial operator +(Polynomial leftPolynomial, Polynomial rightPolynomial)
		{
			var firstPolynomialTerms = leftPolynomial.Terms;
			var secondPolynomialTerms = rightPolynomial.Terms;
			var result = firstPolynomialTerms.Zip(secondPolynomialTerms, (x, y) => x + y)
				.Concat(firstPolynomialTerms.Skip(secondPolynomialTerms.Count())).ToList();
			Polynomial polynomialAnswer = new Polynomial(result);
			return polynomialAnswer;
		}
		/// <summary>
		/// Overload for diff operation
		/// </summary>
		/// <returns>leftPolynomial - rightPolynomial</returns>
		public static Polynomial operator -(Polynomial leftPolynomial, Polynomial rightPolynomial)
		{
			var firstPolynomialTerms = leftPolynomial.Terms;
			var secondPolynomialTerms = rightPolynomial.Terms;
			var result = firstPolynomialTerms.Zip(secondPolynomialTerms, (x, y) => x - y)
				.Concat(firstPolynomialTerms.Skip(secondPolynomialTerms.Count())).ToList();
			Polynomial polynomialAnswer = new Polynomial(result);
			return polynomialAnswer;
		}
		/// <summary>
		/// Overload for multiply operation
		/// </summary>
		/// <returns>polynomial * variable</returns>
		public static Polynomial operator *(Polynomial polynomial, int coefficient)
		{
			var polynomialTerms = polynomial.Terms;
			List<int> result = new List<int>();
			int multipliedTerm;
			foreach (var term in polynomialTerms)
			{
				multipliedTerm = term*coefficient;
				result.Add(multipliedTerm);
			}
			Polynomial polynomialAnswer = new Polynomial(result);
			return polynomialAnswer;
		}
	}
}
