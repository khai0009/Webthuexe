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
    public class HOADONTHUEXEsController : Controller
    {   
        show show = new show();
        private MyworldEntities db = new MyworldEntities();

        // GET: Admin/HOADONTHUEXEs
        public ActionResult Index()
        {
            var hOADONTHUEXEs = db.HOADONTHUEXEs.Include(h => h.KHACHHANG);
            return View(hOADONTHUEXEs.ToList());
        }
        public ActionResult Indexbx()
        {
            var hOADONTHUEXEs = db.HOADONTHUEXEs.Include(h => h.KHACHHANG);
            return View(hOADONTHUEXEs.ToList());
        }
        // GET: Admin/HOADONTHUEXEs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADONTHUEXE hOADONTHUEXE = db.HOADONTHUEXEs.Find(id);
            if (hOADONTHUEXE == null)
            {
                return HttpNotFound();
            }
            return View(hOADONTHUEXE);
        }

        // GET: Admin/HOADONTHUEXEs/Create
        public ActionResult Create()
        {
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENDAYDU");
            return View();
        }

        // POST: Admin/HOADONTHUEXEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAHD,MAKH,NGAYLAP,TIENCOC,DADATCOC,NOIDON,GHICHU,NOIDI,NGAYDI_NHAN,NGAYVE_TRA,GIAOXE")] HOADONTHUEXE hOADONTHUEXE)
        {
            if (ModelState.IsValid)
            {
                db.HOADONTHUEXEs.Add(hOADONTHUEXE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENDAYDU", hOADONTHUEXE.MAKH);
            return View(hOADONTHUEXE);
        }

        // GET: Admin/HOADONTHUEXEs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADONTHUEXE hOADONTHUEXE = db.HOADONTHUEXEs.Find(id);
            if (hOADONTHUEXE == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENDAYDU", hOADONTHUEXE.MAKH);
            return View(hOADONTHUEXE);
        }

        // POST: Admin/HOADONTHUEXEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAHD,MAKH,NGAYLAP,TIENCOC,DADATCOC,NOIDON,GHICHU,NOIDI,NGAYDI_NHAN,NGAYVE_TRA,GIAOXE")] HOADONTHUEXE hOADONTHUEXE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOADONTHUEXE).State = EntityState.Modified;
                db.SaveChanges();
                if (hOADONTHUEXE.DADATCOC == true)
                {
                    CHITIETLICHCHAY hoadon = db.CHITIETLICHCHAYs.Where(n => n.MAHD == hOADONTHUEXE.MAHD).SingleOrDefault();
                    CHITIETTHUEXE cHITIETTHUEXE = db.CHITIETTHUEXEs.Where(n => n.MAHD == hOADONTHUEXE.MAHD).SingleOrDefault();
                    show.cHITIETLICHCHAYs = db.CHITIETLICHCHAYs.Where(n => n.DAHOANTHANH == false && n.MAHD != null).ToList();
                    var result = show.tAIXEs.Select(n => n.MATAIXE).Except(show.cHITIETLICHCHAYs.Select(n => n.MATAIXE)).ToList();
                    PHIEUTHANHTOAN pHIEUTHANHTOAN = db.PHIEUTHANHTOANs.Where(n => n.MAHD == hOADONTHUEXE.MAHD).SingleOrDefault();
                    XE xE = db.XEs.Where(n => n.BIENXE == hoadon.BIENXE).SingleOrDefault();
                    var taixeranh = result.FirstOrDefault();
                    if (hoadon != null)
                    {
                        hoadon.MAHD = hoadon.MAHD;
                        hoadon.MATAIXE = taixeranh.ToString();
                        hoadon.NOIDI = hOADONTHUEXE.NOIDI;
                        hoadon.NOIDON = hOADONTHUEXE.NOIDON;
                        pHIEUTHANHTOAN.MAHD = hoadon.MAHD;
                        pHIEUTHANHTOAN.TONGSOTIEN = cHITIETTHUEXE.CHIPHI.ToString();
                        xE.MATT = "C";
                        db.Entry(xE).State = EntityState.Modified;
                        db.SaveChanges();
                        db.Entry(hoadon).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                }
                return RedirectToAction("Index");
            }
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENDAYDU", hOADONTHUEXE.MAKH);
            return View(hOADONTHUEXE);
        }

        // GET: Admin/HOADONTHUEXEs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADONTHUEXE hOADONTHUEXE = db.HOADONTHUEXEs.Find(id);
            if (hOADONTHUEXE == null)
            {
                return HttpNotFound();
            }
            return View(hOADONTHUEXE);
        }

        // POST: Admin/HOADONTHUEXEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HOADONTHUEXE hOADONTHUEXE = db.HOADONTHUEXEs.Find(id);
            db.HOADONTHUEXEs.Remove(hOADONTHUEXE);
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
