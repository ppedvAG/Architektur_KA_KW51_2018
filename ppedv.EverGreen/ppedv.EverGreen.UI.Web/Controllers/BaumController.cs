using ppedv.EverGreen.Logic;
using ppedv.EverGreen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            return View();
        }

        // POST: Baum/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
            return View();
        }

        // POST: Baum/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
