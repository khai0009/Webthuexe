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
    public class BIENXEsBX : Controller
    {
        private MyworldEntities db = new MyworldEntities();

        // GET: Admin/BIENXEs
        public ActionResult Index()
        {
            var bIENXEs = db.BIENXEs.Include(b => b.TINHTRANG).Include(b => b.XE);
            return View(bIENXEs.ToList());
        }

        // GET: Admin/BIENXEs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BIENXE bIENXE = db.BIENXEs.Find(id);
            if (bIENXE == null)
            {
                return HttpNotFound();
            }
            return View(bIENXE);
        }

        // GET: Admin/BIENXEs/Create
        public ActionResult Create()
        {
            ViewBag.MATT = new SelectList(db.TINHTRANGs, "MATT", "TENTT");
            ViewBag.MAXE = new SelectList(db.XEs, "MAXE", "TENXE");
            return View();
        }

        // POST: Admin/BIENXEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BIENXE1,MATT,SOKM,MAXE,MAUSAC,NGAYNHAP")] BIENXE bIENXE)
        {
            if (ModelState.IsValid)
            {   
                db.BIENXEs.Add(bIENXE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MATT = new SelectList(db.TINHTRANGs, "MATT", "TENTT", bIENXE.MATT);
            ViewBag.MAXE = new SelectList(db.XEs, "MAXE", "TENXE", bIENXE.MAXE);
            return View(bIENXE);
        }

        // GET: Admin/BIENXEs/Edit/5
        public ActionResult Edit(string id)
        {   
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BIENXE bIENXE = db.BIENXEs.Find(id);
            if (bIENXE == null)
            {
                return HttpNotFound();
            }
            ViewBag.MATT = new SelectList(db.TINHTRANGs, "MATT", "TENTT", bIENXE.MATT);
            ViewBag.MAXE = new SelectList(db.XEs, "MAXE", "TENXE", bIENXE.MAXE);
            return View(bIENXE);
        }

        // POST: Admin/BIENXEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BIENXE1,MATT,SOKM,MAXE,MAUSAC,NGAYNHAP")] BIENXE bIENXE)
        {   
            BIENXE bIENXE1 = bIENXE;
            bIENXE1.MATT = bIENXE.MATT;
            if (ModelState.IsValid)
            {
                db.Entry(bIENXE1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MATT = new SelectList(db.TINHTRANGs, "MATT", "TENTT", bIENXE.MATT);
            ViewBag.MAXE = new SelectList(db.XEs, "MAXE", "TENXE", bIENXE.MAXE);
            return View(bIENXE);
        }

        // GET: Admin/BIENXEs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BIENXE bIENXE = db.BIENXEs.Find(id);
            if (bIENXE == null)
            {
                return HttpNotFound();
            }
            return View(bIENXE);
        }

        // POST: Admin/BIENXEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BIENXE bIENXE = db.BIENXEs.Find(id);
            db.BIENXEs.Remove(bIENXE);
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
