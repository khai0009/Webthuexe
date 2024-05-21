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
    public class SOGHEsController : Controller
    {
        private MyworldEntities db = new MyworldEntities();

        // GET: Admin/SOGHEs
        public ActionResult Index()
        {
            return View(db.SOGHEs.ToList());
        }

        // GET: Admin/SOGHEs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOGHE sOGHE = db.SOGHEs.Find(id);
            if (sOGHE == null)
            {
                return HttpNotFound();
            }
            return View(sOGHE);
        }

        // GET: Admin/SOGHEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SOGHEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MASG,SOGHE1")] SOGHE sOGHE)
        {
            if (ModelState.IsValid)
            {
                db.SOGHEs.Add(sOGHE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sOGHE);
        }

        // GET: Admin/SOGHEs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOGHE sOGHE = db.SOGHEs.Find(id);
            if (sOGHE == null)
            {
                return HttpNotFound();
            }
            return View(sOGHE);
        }

        // POST: Admin/SOGHEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MASG,SOGHE1")] SOGHE sOGHE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sOGHE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sOGHE);
        }

        // GET: Admin/SOGHEs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOGHE sOGHE = db.SOGHEs.Find(id);
            if (sOGHE == null)
            {
                return HttpNotFound();
            }
            return View(sOGHE);
        }

        // POST: Admin/SOGHEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SOGHE sOGHE = db.SOGHEs.Find(id);
            db.SOGHEs.Remove(sOGHE);
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
