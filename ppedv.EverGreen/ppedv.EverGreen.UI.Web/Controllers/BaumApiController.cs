using AutoMapper;
using ppedv.EverGreen.Logic;
using ppedv.EverGreen.Model;
using ppedv.EverGreen.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ppedv.EverGreen.UI.Web.Controllers
{
    public class BaumApiController : ApiController
    {
        Core core = new Core();


        static BaumApiController()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<BaumModel, Tannenbaum>()
                   .ForMember(x => x.Price, x => x.MapFrom(y => y.Preis))
                    .ForMember(x => x.Height, x => x.MapFrom(y => y.Höhe))
                    .ForMember(x => x.Width, x => x.MapFrom(y => y.Breite))
                    .ForMember(x => x.Fällzeit, x => x.MapFrom(y => y.Fällung))
                    .ReverseMap()
                    .ForMember(x => x.Name, x => x.MapFrom(y => y.BaumArt.Name));
            });
        }

        // GET: api/BaumApi
        public IEnumerable<BaumModel> Get()
        {
            foreach (var b in core.Repository.GetAll<Tannenbaum>())
            {
                var bm = Mapper.Map<BaumModel>(b);
                yield return bm;
            }
            //foreach (var b in core.Repository.GetAll<Tannenbaum>())
            //{
            //    var bm = new BaumModel()
            //    {
            //        Id = b.Id,
            //        Breite = b.Width,
            //        Höhe = b.Height,
            //        Preis = b.Price,
            //        Fällung = b.Fällzeit
            //    };

            //    if (b.BaumArt != null)
            //    {
            //        bm.BaumArtID = b.BaumArt.Id;
            //        bm.Name = b.BaumArt.Name;
            //    }
            //    yield return bm;
            //}
        }

        // GET: api/BaumApi/5
        public BaumModel Get(int id)
        {
            return Mapper.Map<BaumModel>(core.Repository.GetById<Tannenbaum>(id));

        }

        // POST: api/BaumApi
        public void Post([FromBody]BaumModel value)
        {
            core.Repository.Add(Mapper.Map<Tannenbaum>(value));
            core.Repository.Save();
        }

        // PUT: api/BaumApi/5
        public void Put(int id, [FromBody]BaumModel value)
        {
            core.Repository.Update(Mapper.Map<Tannenbaum>(value));
            core.Repository.Save();
        }

        // DELETE: api/BaumApi/5
        public void Delete(int id)
        {
        }
    }
}
