using System;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Calc_Sum_4_and_8_Results_12()
        {
            //Arrange
            var calc = new Calc();

            //Act
            int result = calc.Sum(4, 8);

            //Assert
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void Calc_Sum_0_and_0_Results_0()
        {
            //Arrange
            var calc = new Calc();

            //Act
            int result = calc.Sum(0, 0);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [DataRow(3, 2, 5)]
        [DataRow(-1, -2, -3)]
        [DataRow(-13, 2, -11)]
        public void Calc_Sum(int a, int b, int soll)
        {
            var calc = new Calc();

            Assert.AreEqual(soll, calc.Sum(a, b));
        }


        [TestMethod]
        public void Calc_Sum_MAX_and_1_throws_OverflowsException()
        {
            var calc = new Calc();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MaxValue, 1));
        }


        [TestMethod]
        [DataRow(0, Size.Small)]
        [DataRow(-1, Size.Small)]
        [DataRow(99, Size.Small)]
        [DataRow(100, Size.Normal)]
        [DataRow(499, Size.Normal)]
        [DataRow(500, Size.Big)]
        public void Calc_GetSize(int num, Size expected)
        {
            var calc = new Calc();

            Assert.AreEqual(expected, calc.GetSize(num));
        }


        [TestMethod]
        public void Calc_IsWeekend()
        {
            var calc = new Calc();

            Assert.IsFalse(calc.IsWeekend(new DateTime(2018, 12, 17)));//Mo
            Assert.IsFalse(calc.IsWeekend(new DateTime(2018, 12, 18)));//Di
            Assert.IsFalse(calc.IsWeekend(new DateTime(2018, 12, 19)));//Mi
            Assert.IsFalse(calc.IsWeekend(new DateTime(2018, 12, 20)));//Do
            Assert.IsFalse(calc.IsWeekend(new DateTime(2018, 12, 21)));//Fr
            Assert.IsTrue(calc.IsWeekend(new DateTime(2018, 12, 22)));//Sa
            Assert.IsTrue(calc.IsWeekend(new DateTime(2018, 12, 23)));//So

        }

        [TestMethod]
        public void Calc_IsWeekendToday()
        {
            var calc = new Calc();

            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2018, 12, 17);//Mo
                Assert.IsFalse(calc.IsWeekendToday());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2018, 12, 18);//Di
                Assert.IsFalse(calc.IsWeekendToday());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2018, 12, 19);//Mi
                Assert.IsFalse(calc.IsWeekendToday());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2018, 12, 20);//Do
                Assert.IsFalse(calc.IsWeekendToday());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2018, 12, 21);//Fr
                Assert.IsFalse(calc.IsWeekendToday());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2018, 12, 22);//Sa
                Assert.IsTrue(calc.IsWeekendToday());
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2018, 12, 23);//So
                Assert.IsTrue(calc.IsWeekendToday());
            }
        }
    }
}
