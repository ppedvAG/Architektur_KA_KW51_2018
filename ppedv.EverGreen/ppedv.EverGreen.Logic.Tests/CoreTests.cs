using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ppedv.EverGreen.Model;
using ppedv.EverGreen.Model.Contracts;

namespace ppedv.EverGreen.Logic.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void Core_GetBaumArtMitGrößtenBäumen()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<BaumArt>()).Returns(() =>
            {
                var ba1 = new BaumArt() { Farbe = "blau" };
                var ba2 = new BaumArt() { Farbe = "rot" };
                ba1.Trees.Add(new Tannenbaum() { Height = 55 });
                ba2.Trees.Add(new Tannenbaum() { Height = 30 });
                ba2.Trees.Add(new Tannenbaum() { Height = 30 });
                return new[] { ba1, ba2 };
            });

            var core = new Core(mock.Object);

            var result = core.GetBaumArtMitGrößtenBäumen();

            Assert.AreEqual("rot", result.Farbe);
        }
    }
}
