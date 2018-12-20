using ppedv.EverGreen.Model;
using ppedv.EverGreen.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.EverGreen.Data.EF
{
    public class EfRepository : IRepository
    {
        EfContext con = new EfContext();

        public void Add<T>(T entity) where T : Entity
        {
            // if (typeof(T) == typeof(Tannenbaum))
            //     con.Tannenbaum.Add(entity as Tannenbaum);
            con.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            con.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return con.Set<T>().ToList();
        }

        public T GetById<T>(int id) where T : Entity
        {
            return con.Set<T>().Find(id);
        }

        public void Save()
        {
            con.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            //nur für disconnected szenarie wie z.b. WCF oder ASP.NET 
            //lokale desktopanwendungen rufen direkt Save(Changes()) auf und der ChangeTracker EF übernimmt die arbeit
            var loaded = GetById<T>(entity.Id);
            if (loaded != null)
                con.Entry(loaded).CurrentValues.SetValues(entity);
        }
    }
}
