using Task1_Vector;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VectorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            Vector vector = new Vector() { xAxisNumber=10,yAxisNumber=15,zAxisNumber=20};
            const double number = 5;

            //act
            Vector answer = vector * number;

            //assert 
            Assert.AreEqual(50, answer.xAxisNumber);
            Assert.AreEqual(75, answer.yAxisNumber);
            Assert.AreEqual(100, answer.zAxisNumber);
        }

        [TestMethod]
        public void TestMethod2()
        {
            //arrange
            Vector vector = new Vector() { xAxisNumber = 10, yAxisNumber = 15, zAxisNumber = 20 };
            const double number = 5;

            //act
            Vector answer = vector / number;

            //assert 
            Assert.AreEqual(2, answer.xAxisNumber);
            Assert.AreEqual(3, answer.yAxisNumber);
            Assert.AreEqual(4, answer.zAxisNumber);
        }

        [TestMethod]
        public void TestMethod3()
        {
            //arrange
            Vector vector = new Vector() { xAxisNumber = 10, yAxisNumber = 15, zAxisNumber = 20 };
            Vector vector2 = new Vector() { xAxisNumber = 8, yAxisNumber = 6, zAxisNumber = 4 };

            //act
            Vector answer = vector + vector2;

            //assert 
            Assert.AreEqual(18, answer.xAxisNumber);
            Assert.AreEqual(21, answer.yAxisNumber);
            Assert.AreEqual(24, answer.zAxisNumber);
        }

        [TestMethod]
        public void TestMethod4()
        {
            //arrange
            Vector vector = new Vector() { xAxisNumber = 10, yAxisNumber = 15, zAxisNumber = 20 };
            Vector vector2 = new Vector() { xAxisNumber = 8, yAxisNumber = 6, zAxisNumber = 4 };

            //act
            Vector answer = vector - vector2;

            //assert 
            Assert.AreEqual(2, answer.xAxisNumber);
            Assert.AreEqual(9, answer.yAxisNumber);
            Assert.AreEqual(16, answer.zAxisNumber);
        }
        [TestMethod]
        public void TestMethod5()
        {
            //arrange
            Vector vector = new Vector() { xAxisNumber = 10, yAxisNumber = 15, zAxisNumber = 20 };
            Vector vector2 = new Vector() { xAxisNumber = 8, yAxisNumber = 6, zAxisNumber = 4 };

            //act
            Vector answer = vector * vector2;

            //assert 
            Assert.AreEqual(-60, answer.xAxisNumber);
            Assert.AreEqual(60, answer.yAxisNumber);
            Assert.AreEqual(-60, answer.zAxisNumber);
        }
    }
}
