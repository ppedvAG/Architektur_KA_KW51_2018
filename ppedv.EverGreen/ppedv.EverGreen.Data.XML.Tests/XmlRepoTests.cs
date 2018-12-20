using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.EverGreen.Model;

namespace ppedv.EverGreen.Data.XML.Tests
{
    [TestClass]
    public class XmlRepoTests
    {
        [TestMethod]
        public void XmlRepoTests_Can_CRUD_Baum()
        {
            var baum = new Tannenbaum() { Height = 17 };
            var newHeight = 452;

            {//INSERT
                var repo = new XmlRepository();
                repo.Add(baum);
                repo.Save();
            }


            {//check Read
                var repo = new XmlRepository();

                Assert.IsTrue(repo.GetAll<Tannenbaum>().Any(x => x.Height == baum.Height));
                var loaded = repo.GetById<Tannenbaum>(baum.Id);
                Assert.IsNotNull(loaded);
                Assert.AreEqual(baum.Height, loaded.Height);

                //UPDATE
                loaded.Height = 452;
                repo.Save();
            }

            {//check UPDATE + DELETE
                var repo = new XmlRepository(); 
                var loaded = repo.GetById<Tannenbaum>(baum.Id);
                Assert.AreEqual(newHeight, loaded.Height);

                repo.Delete(loaded);
                repo.Save();
            }

            {//check DELETE
                var repo = new XmlRepository();
                var loaded = repo.GetById<Tannenbaum>(baum.Id);
                Assert.IsNull(loaded);
            }
        }

        [TestMethod]
        public void XmlRepo_add_sets_the_id()
        {
            var baum = new Tannenbaum() { Height = 17 };
            Assert.AreEqual(0, baum.Id);

            var repo = new XmlRepository();
            repo.Add(baum);
            Assert.AreNotEqual(0, baum.Id);
        }
    }
}
