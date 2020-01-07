﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComputerraBIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerraBIN.Tests
{
    [TestClass]
    public class EmploeeGeneratorTests
    {
        [TestMethod]
        public void CreateEmploeesTest()
        {
            //
            EmploeeGenerator emploeeGenerator = new EmploeeGenerator();
            List<Emploee> emp = emploeeGenerator.CreateEmploees(5, 5, 5);

            //act
            var count = emp.Count;
            //assert
            Assert.AreEqual(15, count);
        }
        [TestMethod]
        public void GivePositionTest()
        {
            //
            EmploeeGenerator emploeeGenerator = new EmploeeGenerator();
            List<Emploee> emp = emploeeGenerator.CreateEmploees(5, 5, 5);
            emploeeGenerator.GiveName(emp);
            emploeeGenerator.GivePosition(emp,2,15,2,15);
            emploeeGenerator.GiveSalary(emp, 1000, 3000, 5000, 10000, 20000, 50000);

            //act
            var count = emp.Count;
            //assert
            Assert.AreEqual(15, count);
           
        }
    }
}