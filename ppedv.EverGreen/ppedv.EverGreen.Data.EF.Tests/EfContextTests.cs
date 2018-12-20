using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.EverGreen.Model;

namespace ppedv.EverGreen.Data.EF.Tests
{
    [TestClass]
    public class EfContextTests
    {
        [TestMethod]
        public void EfContext_can_create_database()
        {
            using (var con = new EfContext("Server=.;Database=EverGreen_CREATETEST;Trusted_Connection=true;"))
            {
                if (con.Database.Exists())
                    con.Database.Delete();

                con.Database.Create();
                Assert.IsTrue(con.Database.Exists());
            }
        }

        [TestMethod]
        public void EfContext_can_add_Tannenbaum()
        {
            var baum = new Tannenbaum() { Height = 170, Width = 90, Price = 35.50m };

            using (var con = new EfContext())
            {
                con.Tannenbaum.Add(baum);
                con.SaveChanges();
            }


            using (var con = new EfContext())
            {
                var loaded = con.Tannenbaum.Find(baum.Id);

                Assert.IsNotNull(loaded);
                Assert.AreEqual(baum.Height, loaded.Height);
            }
        }
    }
}
