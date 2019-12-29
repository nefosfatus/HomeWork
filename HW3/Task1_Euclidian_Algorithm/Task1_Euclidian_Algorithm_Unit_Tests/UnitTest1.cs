using Task1_Euclidian_Algorithm;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Task1_Euclidian_Algorithm_Unit_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            var calculator = new Calculator();

            //act
            var res1 = calculator.GetGCDbySteinAlgorithm(125, 25);
            var res2 = calculator.GetGreatestCommonDivisor(125, 25);
            var res3 = calculator.GetGreatestCommonDivisor(-8888, 25);

            Assert.AreEqual(25, res1);
            Assert.AreEqual(25, res2);
            Assert.AreEqual(25, res3);
        }
    }
}
