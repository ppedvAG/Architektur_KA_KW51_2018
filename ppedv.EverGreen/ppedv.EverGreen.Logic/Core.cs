using ppedv.EverGreen.Model;
using ppedv.EverGreen.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.EverGreen.Logic
{
    public class Core
    {
        public IRepository Repository { get; private set; }


        public BaumArt GetBaumArtMitGrößtenBäumen()
        {
            return Repository.GetAll<BaumArt>().OrderByDescending(x => x.Trees.Sum(y => y.Height)).FirstOrDefault();
        }

        public void CreateDemoData()
        {
            foreach (var item in GetDemoData())
            {
                Repository.Add(item);
            }
            Repository.Save();
        }

        public IEnumerable<Tannenbaum> GetDemoData()
        {
            var ba1 = new BaumArt() { Name = "Weißtanne", Farbe = "Grün", Form = "Normal" };
            var ba2 = new BaumArt() { Name = "Kilikische Tanne", Farbe = "Grün", Form = "Normal" };
            var ba3 = new BaumArt() { Name = "Nordmanntanne", Farbe = "Grün", Form = "Normal" };

            var h1 = new Herkunft() { Beschreibung = "Europa" };
            var h2 = new Herkunft() { Beschreibung = "Kaukasus" };
            var h3 = new Herkunft() { Beschreibung = "Anti-Taurus," };


            for (int i = 0; i < 10; i++)
            {
                yield return new Tannenbaum()
                {
                    BaumArt = ba1,
                    Herkunft = h1,
                    Height = 300 + (i * 33),
                    Price = 3.3m * i,
                    Width = 200 + (i * 22),
                    Fällzeit = DateTime.Now.AddDays(i * 70 * -1)
                };

                yield return new Tannenbaum()
                {
                    BaumArt = ba2,
                    Herkunft = h2,
                    Height = 200 + (i * 33),
                    Price = 4.7m * i,
                    Width = 100 + (i * 22),
                    Fällzeit = DateTime.Now.AddDays(i * 70 * -1)
                };

                yield return new Tannenbaum()
                {
                    BaumArt = ba3,
                    Herkunft = h3,
                    Height = 400 + (i * 33),
                    Price = 2.4m * i,
                    Width = 150 + (i * 22),
                    Fällzeit = DateTime.Now.AddDays(i * 70 * -1)
                };
            }
        }

        public Core(IRepository repo) //<----dependency injection in here
        {
            Repository = repo;
        }

        public Core() : this(new Data.EF.EfRepository())
        { }

        //public Core() : this(new Data.XML.XmlRepository())
        //{ }
    }
}
