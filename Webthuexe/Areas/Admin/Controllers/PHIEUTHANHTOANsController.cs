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
    public class PHIEUTHANHTOANsController : Controller
    {
        private MyworldEntities db = new MyworldEntities();

        // GET: Admin/PHIEUTHANHTOANs
        public ActionResult Index()
        {
            var pHIEUTHANHTOANs = db.PHIEUTHANHTOANs.Include(p => p.HOADONTHUEXE).Include(p => p.NHANVIEN);
            return View(pHIEUTHANHTOANs.ToList());
        }

        // GET: Admin/PHIEUTHANHTOANs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUTHANHTOAN pHIEUTHANHTOAN = db.PHIEUTHANHTOANs.Find(id);
            if (pHIEUTHANHTOAN == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUTHANHTOAN);
        }

        // GET: Admin/PHIEUTHANHTOANs/Create
        public ActionResult Create()
        {
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE");
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE");
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE");
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE");
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENDAYDU");
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENDAYDU");
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENDAYDU");
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENDAYDU");
            return View();
        }

        // POST: Admin/PHIEUTHANHTOANs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAPTT,MANV,TONGSOTIEN,GHICHU,MAHD,DATHANHTOAN,NGAYTHANHTOAN")] PHIEUTHANHTOAN pHIEUTHANHTOAN)
        {
            if (ModelState.IsValid)
            {
                db.PHIEUTHANHTOANs.Add(pHIEUTHANHTOAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE", pHIEUTHANHTOAN.MAHD);
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE", pHIEUTHANHTOAN.MAHD);
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE", pHIEUTHANHTOAN.MAHD);
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE", pHIEUTHANHTOAN.MAHD);
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENDAYDU", pHIEUTHANHTOAN.MANV);
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENDAYDU", pHIEUTHANHTOAN.MANV);
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENDAYDU", pHIEUTHANHTOAN.MANV);
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENDAYDU", pHIEUTHANHTOAN.MANV);
            return View(pHIEUTHANHTOAN);
        }

        // GET: Admin/PHIEUTHANHTOANs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUTHANHTOAN pHIEUTHANHTOAN = db.PHIEUTHANHTOANs.Find(id);
            if (pHIEUTHANHTOAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE", pHIEUTHANHTOAN.MAHD);
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE", pHIEUTHANHTOAN.MAHD);
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE", pHIEUTHANHTOAN.MAHD);
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE", pHIEUTHANHTOAN.MAHD);
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENDAYDU", pHIEUTHANHTOAN.MANV);
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENDAYDU", pHIEUTHANHTOAN.MANV);
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENDAYDU", pHIEUTHANHTOAN.MANV);
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENDAYDU", pHIEUTHANHTOAN.MANV);
            return View(pHIEUTHANHTOAN);
        }

        // POST: Admin/PHIEUTHANHTOANs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAPTT,MANV,TONGSOTIEN,GHICHU,MAHD,DATHANHTOAN,NGAYTHANHTOAN")] PHIEUTHANHTOAN pHIEUTHANHTOAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHIEUTHANHTOAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE", pHIEUTHANHTOAN.MAHD);
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE", pHIEUTHANHTOAN.MAHD);
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE", pHIEUTHANHTOAN.MAHD);
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE", pHIEUTHANHTOAN.MAHD);
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENDAYDU", pHIEUTHANHTOAN.MANV);
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENDAYDU", pHIEUTHANHTOAN.MANV);
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENDAYDU", pHIEUTHANHTOAN.MANV);
            ViewBag.MANV = new SelectList(db.NHANVIENs, "MANV", "TENDAYDU", pHIEUTHANHTOAN.MANV);
            return View(pHIEUTHANHTOAN);
        }

        // GET: Admin/PHIEUTHANHTOANs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEUTHANHTOAN pHIEUTHANHTOAN = db.PHIEUTHANHTOANs.Find(id);
            if (pHIEUTHANHTOAN == null)
            {
                return HttpNotFound();
            }
            return View(pHIEUTHANHTOAN);
        }

        // POST: Admin/PHIEUTHANHTOANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHIEUTHANHTOAN pHIEUTHANHTOAN = db.PHIEUTHANHTOANs.Find(id);
            db.PHIEUTHANHTOANs.Remove(pHIEUTHANHTOAN);
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
