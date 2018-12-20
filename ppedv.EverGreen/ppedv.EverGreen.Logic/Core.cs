using ppedv.EverGreen.Model.Contracts;
using System;

namespace ppedv.EverGreen.Logic
{
    public class Core
    {
        public IRepository Repository { get; private set; }

        public Core(IRepository repo) //<----dependency injection in here
        {
            Repository = repo;
        }

        public Core() : this(new Data.EF.EfRepository())
        { }
    }
}
