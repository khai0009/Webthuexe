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
    public class PHIEUBAOTRIsController : Controller
    {
        private MyworldEntities db = new MyworldEntities();

        // GET: Admin/PHIEUBAOTRIs
        public ActionResult Index()
        {
            var pHIEUBAOTRIs = db.PHIEUBAOTRIs.Include(p => p.NHANVIEN).Include(p => p.NHANVIENQLBAIXE);
            return View(pHIEUBAOTRIs.ToList());
        }

        // GET: Admin/PHIEUBAOTRIs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUBAOTRI pHIEUBAOTRI = db.PHIEUBAOTRIs.Find(id);
            if (pHIEUBAOTRI == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUBAOTRI);
        }

        // GET: Admin/PHIEUBAOTRIs/Create
        public ActionResult Create()
        {
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENDAYDU");
            ViewBag.MANVBAIXE = new SelectList(db.NHANVIENQLBAIXEs, "MANVBAIXE", "TENDAYDU");
            return View();
        }

        // POST: Admin/PHIEUBAOTRIs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAPBT,MANVBAIXE,MANV,NGAYBA0TRI,TONGCHIPHI")] PHIEUBAOTRI pHIEUBAOTRI)
        {
            if (ModelState.IsValid)
            {
                db.PHIEUBAOTRIs.Add(pHIEUBAOTRI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENDAYDU", pHIEUBAOTRI.MANV);
            ViewBag.MANVBAIXE = new SelectList(db.NHANVIENQLBAIXEs, "MANVBAIXE", "TENDAYDU", pHIEUBAOTRI.MANVBAIXE);
            return View(pHIEUBAOTRI);
        }

        // GET: Admin/PHIEUBAOTRIs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUBAOTRI pHIEUBAOTRI = db.PHIEUBAOTRIs.Find(id);
            if (pHIEUBAOTRI == null)
            {
                return HttpNotFound();
            }
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENDAYDU", pHIEUBAOTRI.MANV);
            ViewBag.MANVBAIXE = new SelectList(db.NHANVIENQLBAIXEs, "MANVBAIXE", "TENDAYDU", pHIEUBAOTRI.MANVBAIXE);
            return View(pHIEUBAOTRI);
        }

        // POST: Admin/PHIEUBAOTRIs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAPBT,MANVBAIXE,MANV,NGAYBA0TRI,TONGCHIPHI")] PHIEUBAOTRI pHIEUBAOTRI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHIEUBAOTRI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENDAYDU", pHIEUBAOTRI.MANV);
            ViewBag.MANVBAIXE = new SelectList(db.NHANVIENQLBAIXEs, "MANVBAIXE", "TENDAYDU", pHIEUBAOTRI.MANVBAIXE);
            return View(pHIEUBAOTRI);
        }

        // GET: Admin/PHIEUBAOTRIs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUBAOTRI pHIEUBAOTRI = db.PHIEUBAOTRIs.Find(id);
            if (pHIEUBAOTRI == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUBAOTRI);
        }

        // POST: Admin/PHIEUBAOTRIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHIEUBAOTRI pHIEUBAOTRI = db.PHIEUBAOTRIs.Find(id);
            db.PHIEUBAOTRIs.Remove(pHIEUBAOTRI);
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
