using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComputerraBIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraBIN.Tests
{
    [TestClass()]
    public class EngineTests
    {
        [TestMethod()]
        public void GetNewPositionTest() //if near outfield
        {
            Engine engine = new Engine();
            Point point = new Point()  {CoordinateX=2,CoordinateY=3};
            int minX = 2;
            int maxX = 3;
            int minY = 2;
            int maxY = 3;
            int cycle = 1000;
            while (cycle != 0)
            {
                point = engine.GetNewPosition(point, minX, maxX, minY, maxY);

                cycle--;
            }
            
            Assert.AreEqual(point.CoordinateX,2);
        }
        [TestMethod()]
        public void GetNewPositionTest2() //if in field
        {
            Engine engine = new Engine();
            Point point = new Point() { CoordinateX = 28, CoordinateY =28  };
            int minX = 2;
            int maxX = 3;
            int minY = 2;
            int maxY = 3;
            int cycle = 1000;
            while (cycle != 0)
            {
                point = engine.GetNewPosition(point, minX, maxX, minY, maxY);

                cycle--;
            }
            Assert.AreEqual(point.CoordinateX, 2);
        }

        [TestMethod()]
        public void GetNewPositionTest3() //if in field
        {
            Random random = new Random();
            int a = 10;
            int cycle = 1000;
            while (cycle != 0)
            {
                a += random.Next(-1, 2);
                cycle--;
            }
            Assert.AreEqual(a, 2);
        }


    }
}