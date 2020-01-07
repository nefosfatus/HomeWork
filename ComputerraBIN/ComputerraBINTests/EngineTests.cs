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
        public void GetNewPositionTest()
        {
            Engine engine = new Engine();
            Point point = new Point()  {CoordinateX=2,CoordinateY=2};
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
            Assert.Fail();
        }
    }
}