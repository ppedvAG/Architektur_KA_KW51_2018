﻿using ppedv.EverGreen.Logic;
using ppedv.EverGreen.Model;
using ppedv.EverGreen.UI.Web.Models;
using System;
using System.Web.Mvc;

namespace ppedv.EverGreen.UI.Web.Controllers
{
    public class BaumController : Controller
    {
        Core core = new Core();

        // GET: Baum
        public ActionResult Index()
        {
            return View(core.Repository.GetAll<Tannenbaum>());
        }

        // GET: Baum/Details/5
        public ActionResult Details(int id)
        {
            return View(core.Repository.GetById<Tannenbaum>(id));
        }

        // GET: Baum/Create
        public ActionResult Create()
        {
            return View(new Tannenbaum() { Fällzeit = DateTime.Now, Price = 12m });
        }

        // POST: Baum/Create
        [HttpPost]
        public ActionResult Create(Tannenbaum baum)
        {
            try
            {
                // TODO: Add insert logic here
                core.Repository.Add(baum);
                core.Repository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Baum/Edit/5
        public ActionResult Edit(int id)
        {
            BaumViewModel bvm = new BaumViewModel()
            {
                Baum = core.Repository.GetById<Tannenbaum>(id),
                BaumArten = core.Repository.GetAll<BaumArt>(),
                Herkünften = core.Repository.GetAll<Herkunft>()
            };


            return View(bvm);
        }

        // POST: Baum/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Tannenbaum baum)
        {
            try
            {
                core.Repository.Update(baum);
                core.Repository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Baum/Delete/5
        public ActionResult Delete(int id)
        {
            return View(core.Repository.GetById<Tannenbaum>(id));
        }

        // POST: Baum/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var loaded = core.Repository.GetById<Tannenbaum>(id);
                if (loaded != null)
                {
                    core.Repository.Delete(loaded);
                    core.Repository.Save();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
