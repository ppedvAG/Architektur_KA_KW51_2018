using ppedv.EverGreen.Model;
using ppedv.EverGreen.Model.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ppedv.EverGreen.Data.XML
{
    public class XmlRepository : IRepository
    {

        string tannenFile = "tannen.xml";
        string herkunftsFile = "herkunft.xml";
        string baumArtenFile = "baumArten.xml";

        List<Tannenbaum> tannen = new List<Tannenbaum>();
        List<Herkunft> herkunfts;
        List<BaumArt> baumArten;
  

        public XmlRepository()
        {
            if (File.Exists(tannenFile))
                using (var sr = new StreamReader(tannenFile))
                {
                    var serial = new XmlSerializer(typeof(List<Tannenbaum>));
                    tannen = (List<Tannenbaum>)serial.Deserialize(sr);
                }
        }


        public void Add<T>(T entity) where T : Entity
        {
            if (entity is Tannenbaum tb)
            {
                tannen.Add(tb);
                tb.Id = tannen.Max(x => x.Id) + 1;
            }
        }

        public void Delete<T>(T entity) where T : Entity
        {
            if (entity is Tannenbaum tb && tannen.Contains(tb))
                tannen.Remove(tb);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            if (typeof(T) == typeof(Tannenbaum))
                return tannen.Cast<T>();

            throw new NotImplementedException();
        }

        public T GetById<T>(int id) where T : Entity
        {
            if (typeof(T) == typeof(Tannenbaum))
                return tannen.FirstOrDefault(x => x.Id == id) as T;

            throw new NotImplementedException();
        }

        public void Save()
        {
            using (var sr = new StreamWriter(tannenFile))
            {
                var serial = new XmlSerializer(typeof(List<Tannenbaum>));
                serial.Serialize(sr, tannen);
            }
        }

        public void Update<T>(T entity) where T : Entity
        {

        }
    }
}
