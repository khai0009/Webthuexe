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
    public class PHIEUDENBUsController : Controller
    {
        private MyworldEntities db = new MyworldEntities();

        // GET: Admin/PHIEUDENBUs
        public ActionResult Index()
        {
            var pHIEUDENBUs = db.PHIEUDENBUs.Include(p => p.HOADONTHUEXE);
            return View(pHIEUDENBUs.ToList());
        }

        // GET: Admin/PHIEUDENBUs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUDENBU pHIEUDENBU = db.PHIEUDENBUs.Find(id);
            if (pHIEUDENBU == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUDENBU);
        }

        // GET: Admin/PHIEUDENBUs/Create
        public ActionResult Create()
        {
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "MAKH");
            return View();
        }

        // POST: Admin/PHIEUDENBUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAPDB,NGAYDENBU,TONGGIATIEN,NOIDUNG,MANV,MAHD")] PHIEUDENBU pHIEUDENBU)
        {
            if (ModelState.IsValid)
            {
                db.PHIEUDENBUs.Add(pHIEUDENBU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "MAKH", pHIEUDENBU.MAHD);
            return View(pHIEUDENBU);
        }

        // GET: Admin/PHIEUDENBUs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUDENBU pHIEUDENBU = db.PHIEUDENBUs.Find(id);
            if (pHIEUDENBU == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "MAKH", pHIEUDENBU.MAHD);
            return View(pHIEUDENBU);
        }

        // POST: Admin/PHIEUDENBUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAPDB,NGAYDENBU,TONGGIATIEN,NOIDUNG,MANV,MAHD")] PHIEUDENBU pHIEUDENBU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHIEUDENBU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "MAKH", pHIEUDENBU.MAHD);
            return View(pHIEUDENBU);
        }

        // GET: Admin/PHIEUDENBUs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUDENBU pHIEUDENBU = db.PHIEUDENBUs.Find(id);
            if (pHIEUDENBU == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUDENBU);
        }

        // POST: Admin/PHIEUDENBUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHIEUDENBU pHIEUDENBU = db.PHIEUDENBUs.Find(id);
            db.PHIEUDENBUs.Remove(pHIEUDENBU);
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
