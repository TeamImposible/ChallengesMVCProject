using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Challenger.Controllers
{
    public class ChallengeController : Controller
    {
        // GET: Challenge
        public ActionResult Index()
        {
            return View();
        }

        // GET: Challenge/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Challenge/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Challenge/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Challenge/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Challenge/Edit/5
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

        // GET: Challenge/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Challenge/Delete/5
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
