using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polynomial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial.Tests
{
	[TestClass()]
	public class PolynomialTests
	{
		[TestMethod()]
		public void Sum()
		{
			//Arrange
			List<int> firstList = new List<int>() { 1, 2, 3 };
			List<int> secondList = new List<int>() { 1 };
			Polynomial polynomial1 = new Polynomial(firstList);
			Polynomial polynomial2 = new Polynomial(secondList);

			//Act
			Polynomial result = polynomial1 + polynomial2;

			//Assert
			Assert.AreEqual(2,result.Terms[0]);
		}
		[TestMethod()]
		public void Diff()
		{
			//Arrange
			List<int> firstList = new List<int>() { 1, 2, 3 };
			List<int> secondList = new List<int>() { 1 };
			Polynomial polynomial1 = new Polynomial(firstList);
			Polynomial polynomial2 = new Polynomial(secondList);

			//Act
			Polynomial result = polynomial1 - polynomial2;

			//Assert
			Assert.AreEqual(0, result.Terms[0]);
		}
		[TestMethod()]
		public void Mult()
		{
			//Arrange
			List<int> firstList = new List<int>() { 1, 2, 3 };
			Polynomial polynomial1 = new Polynomial(firstList);


			//Act
			Polynomial result = polynomial1 *33;

			//Assert
			Assert.AreEqual(33, result.Terms[0]);
		}
	}
}