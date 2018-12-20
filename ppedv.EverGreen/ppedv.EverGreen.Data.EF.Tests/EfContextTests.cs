using System;
using AutoFixture;
using FluentAssertions;
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
        public void EfContext_can_CRUD_Tannenbaum()
        {
            var baum = new Tannenbaum() { Height = 170, Width = 90, Price = 35.50m };
            int newHeight = 199;

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

                loaded.Height = newHeight;
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Tannenbaum.Find(baum.Id);
                Assert.AreEqual(newHeight, loaded.Height);

                con.Tannenbaum.Remove(loaded);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Tannenbaum.Find(baum.Id);
                Assert.IsNull(loaded);
            }

        }

        [TestMethod]
        public void EfContext_can_ADD_Tannenbaum_AutoFix_Fluent()
        {
            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            var baum = fix.Create<Tannenbaum>();

            using (var con = new EfContext())
            {
                con.Tannenbaum.Add(baum);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Tannenbaum.Find(baum.Id);
                loaded.Should().NotBeNull();
                loaded.Height.Should().Be(baum.Height);

                loaded.Should().BeEquivalentTo(baum, op =>
                {
                    op.IgnoringCyclicReferences();
                    op.Using<DateTime>(cfg => cfg.Subject.Should().BeCloseTo(cfg.Expectation, 100)).WhenTypeIs<DateTime>();
                    return op;
                });
            }

        }
    }
}
