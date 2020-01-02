
using Task1_Euclidian_Algorithm;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1_Euclidian_Algorithm_Unit_Tests
{
    [TestClass]
    public class CalculatorTests   
    {
        /// <summary>
        /// Initialization for work with Calculator
        /// </summary>
        private Calculator _calculator = new Calculator();

        /// <summary>
        /// Calculate GCD by Stain algoritm input: positive numbers
        /// </summary>
        [TestMethod]

        public void GetGCDbySteinAlgorithmTest()
        {

            //act
            var result1 = _calculator.GetGCDbySteinAlgorithm(125, 25);
            
            //assert
            Assert.AreEqual(25, result1);
        }
        /// <summary>
        /// Calculate GCD by Stain algoritm input: positive and negative numbers
        /// </summary>
        [TestMethod]
        public void GetGCDbySteinAlgorithmTestWithNegativeInput()
        {
            //arrenge
            int firstValue = 125;
            int secondValue = -25;

            //act
            var result1 = _calculator.GetGCDbySteinAlgorithm(firstValue, secondValue);
            
            //assert
            Assert.AreEqual(25, result1);
        }
        /// <summary>
        /// Calculate GCD by Stain algoritm input: negative numbers
        /// </summary>
        [TestMethod]
        public void GetGCDbySteinAlgorithmTestWithNegativeInput2()
        {
            //arrenge
            int firstValue = -125;
            int secondValue = -25;

            //act
            var result1 = _calculator.GetGCDbySteinAlgorithm(firstValue, secondValue);

            //assert
            Assert.AreEqual(25, result1);
        }
        /// <summary>
        /// Calculate GCD by Newton algoritm input: positive numbers
        /// </summary>
        [TestMethod]
        public void GetGreatestCommonDivisorTest()
        {
            //arrenge
            int firstValue = 125;
            int secondValue = 25;

            //act
            var result1 = _calculator.GetGreatestCommonDivisor(firstValue, secondValue);

            //assert
            Assert.AreEqual(25, result1);
        }
        /// <summary>
        /// Calculate GCD by Newton algoritm input: positive and negative numbers
        /// </summary>
        [TestMethod]
        public void GetGreatestCommonDivisorTestWithNegative()
        {
            //arrenge
            int firstValue = 125;
            int secondValue = -25;

            //act
            var result1 = _calculator.GetGreatestCommonDivisor(firstValue, secondValue);

            //assert
            Assert.AreEqual(25, result1);
        }
        /// <summary>
        /// Calculate GCD by Newton algoritm input: negative numbers
        /// </summary>
        [TestMethod]
        public void GetGreatestCommonDivisorTestWithNegative2()
        {
            //arrenge
            int firstValue = -125;
            int secondValue = -25;

            //act
            var result1 = _calculator.GetGreatestCommonDivisor(firstValue, secondValue);

            //assert
            Assert.AreEqual(25, result1);
        }
    }
}
