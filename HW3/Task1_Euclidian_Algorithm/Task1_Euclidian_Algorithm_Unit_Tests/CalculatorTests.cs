
using Task1_Euclidian_Algorithm;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1_Euclidian_Algorithm_Unit_Tests
{
    [TestClass]
    public class CalculatorTests   
    {
        private Calculator _calculator = new Calculator();
        [TestMethod]
        public void GetGCDbySteinAlgorithmTest()
        {

            //act
            var res1 = _calculator.GetGCDbySteinAlgorithm(125, 25);
            
            //assert
            Assert.AreEqual(25, res1);
        }

        [TestMethod]
        public void GetGCDbySteinAlgorithmTestWithNegativeInput()
        {
            //arrenge
            int firstValue = 125;
            int secondValue = -25;

            //act
            var res1 = _calculator.GetGCDbySteinAlgorithm(firstValue, secondValue);
            
            //assert
            Assert.AreEqual(25, res1);
        }

        [TestMethod]
        public void GetGCDbySteinAlgorithmTestWithNegativeInput2()
        {
            //arrenge
            int firstValue = -125;
            int secondValue = -25;

            //act
            var res1 = _calculator.GetGCDbySteinAlgorithm(firstValue, secondValue);

            //assert
            Assert.AreEqual(25, res1);
        }
       
        [TestMethod]
        public void GetGreatestCommonDivisorTest()
        {
            //arrenge
            int firstValue = 125;
            int secondValue = 25;

            //act
            var res1 = _calculator.GetGreatestCommonDivisor(firstValue, secondValue);

            //assert
            Assert.AreEqual(25, res1);
        }
        [TestMethod]
        public void GetGreatestCommonDivisorTestWithNegative()
        {
            //arrenge
            int firstValue = 125;
            int secondValue = -25;

            //act
            var res1 = _calculator.GetGreatestCommonDivisor(firstValue, secondValue);

            //assert
            Assert.AreEqual(25, res1);
        }
    }
}
