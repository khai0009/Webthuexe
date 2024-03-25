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
        private MyworldEntities db = new MyworldEntities();
        private show show = new show();
        // GET: Admin/HOADONTHUEXEs
        public ActionResult Index()
        {
            var hOADONTHUEXEs = db.HOADONTHUEXEs.Include(h => h.BIENXE1).Include(h => h.KHACHHANG);
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
            ViewBag.BIENXE = new SelectList(db.BIENXEs, "BIENXE1", "MATT");
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENDAYDU");
            return View();
        }

        // POST: Admin/HOADONTHUEXEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BIENXE,THUCTHUCTHANHTOAN,COTAIXE,CHIPHITHUE,SONGAYTHUE,MAHD,MAKH,NGAYLAP,TIENCOC,DADATCOC,NOIDON,GHICHU,NOIDI,NGAYDI_NHAN,NGAYVE_TRA,GIAOXE,KHUHOI")] HOADONTHUEXE hOADONTHUEXE)
        {
            if (ModelState.IsValid)
            {
                db.HOADONTHUEXEs.Add(hOADONTHUEXE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BIENXE = new SelectList(db.BIENXEs, "BIENXE1", "MATT", hOADONTHUEXE.BIENXE);
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
            ViewBag.BIENXE = new SelectList(db.BIENXEs, "BIENXE1", "MATT", hOADONTHUEXE.BIENXE);
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENDAYDU", hOADONTHUEXE.MAKH);
            return View(hOADONTHUEXE);
        }

        // POST: Admin/HOADONTHUEXEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BIENXE,THUCTHUCTHANHTOAN,COTAIXE,CHIPHITHUE,SONGAYTHUE,MAHD,MAKH,NGAYLAP,TIENCOC,DADATCOC,NOIDON,GHICHU,NOIDI,NGAYDI_NHAN,NGAYVE_TRA,GIAOXE,KHUHOI")] HOADONTHUEXE hOADONTHUEXE)
        {
            BIENXE xe = db.BIENXEs.Find(hOADONTHUEXE.BIENXE);
            xe.MATT = "C";
            db.Entry(xe).State = EntityState.Modified;
            db.SaveChanges();
            CHITIETLICHCHAY cHITIETLICHCHAY = new CHITIETLICHCHAY();
            cHITIETLICHCHAY.MAHD = hOADONTHUEXE.MAHD;
            cHITIETLICHCHAY.NOIDI = hOADONTHUEXE.NOIDI;
            cHITIETLICHCHAY.NOIDON = hOADONTHUEXE.NOIDON;
            cHITIETLICHCHAY.BIENXE = hOADONTHUEXE.BIENXE;
            show.TKTAIXEs = db.TKTAIXEs.Where(n => n.TRANGTHAI == true).ToList();
            show.cHITIETLICHCHAYs = db.CHITIETLICHCHAYs.Where(n=>n.DAHOANTHANH == false).ToList();
            var taixehoatdong = show.TKTAIXEs.Select(n => n.MATAIXE).Except(show.cHITIETLICHCHAYs.Select(n => n.MATAIXE)).ToList();
            cHITIETLICHCHAY.MATAIXE = taixehoatdong[0];
            db.CHITIETLICHCHAYs.Add(cHITIETLICHCHAY);
            db.SaveChanges();
            if (ModelState.IsValid)
            {
                db.Entry(hOADONTHUEXE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BIENXE = new SelectList(db.BIENXEs, "BIENXE1", "MATT", hOADONTHUEXE.BIENXE);
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
