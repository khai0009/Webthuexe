using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Webthuexe.Models;

namespace Webthuexe.Areas.Admin.Controllers
{
    public class HANGXEsController : Controller
    {
        private MyworldEntities db = new MyworldEntities();

        // GET: Admin/HANGXEs
        public ActionResult Index()
        {
            return View(db.HANGXEs.ToList());
        }

        // GET: Admin/HANGXEs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HANGXE hANGXE = db.HANGXEs.Find(id);
            if (hANGXE == null)
            {
                return HttpNotFound();
            }
            return View(hANGXE);
        }

        // GET: Admin/HANGXEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/HANGXEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAHANG,TENHANG")] HANGXE hANGXE)
        {
            if (ModelState.IsValid)
            {
                db.HANGXEs.Add(hANGXE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hANGXE);
        }

        // GET: Admin/HANGXEs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HANGXE hANGXE = db.HANGXEs.Find(id);
            if (hANGXE == null)
            {
                return HttpNotFound();
            }
            return View(hANGXE);
        }

        // POST: Admin/HANGXEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAHANG,TENHANG")] HANGXE hANGXE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hANGXE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hANGXE);
        }

        // GET: Admin/HANGXEs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HANGXE hANGXE = db.HANGXEs.Find(id);
            if (hANGXE == null)
            {
                return HttpNotFound();
            }
            return View(hANGXE);
        }

        // POST: Admin/HANGXEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HANGXE hANGXE = db.HANGXEs.Find(id);
            db.HANGXEs.Remove(hANGXE);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
