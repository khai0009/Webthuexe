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
    public class KHACHHANGsController : Controller
    {
        private MyworldEntities db = new MyworldEntities();

        // GET: Admin/KHACHHANGs
        public ActionResult Index()
        {
            var kHACHHANGs = db.KHACHHANGs.Include(k => k.QUAN_HUYEN).Include(k => k.THANHPHO_TINH).Include(k => k.PHUONG_XA).Include(k => k.TKKHACHHANG);
            return View(kHACHHANGs.ToList());
        }

        // GET: Admin/KHACHHANGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG kHACHHANG = db.KHACHHANGs.Find(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACHHANG);
        }

        // GET: Admin/KHACHHANGs/Create
        public ActionResult Create()
        {
            ViewBag.MAQ = new SelectList(db.QUAN_HUYEN, "MAQ", "TENQH");
            ViewBag.MATP = new SelectList(db.THANHPHO_TINH, "MATP", "TENTP_TINH");
            ViewBag.MAXP = new SelectList(db.PHUONG_XA, "MAXP", "TENXP");
            ViewBag.MAKH = new SelectList(db.TKKHACHHANGs, "MAKH", "SDT");
            return View();
        }

        // POST: Admin/KHACHHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAKH,TENDAYDU,HO,LOT,TEN,GIOITINH,TUOI,SDT,Email,NGAYSINH,SONHA,CCCD,ANHDAIDIEN,XACNHANCC,BANGLAI,XACNHANBL,DUONG,ANHBL,ANHCCCDTRUOC,ANHCCCDSAU,MATP,MAXP,MAQ")] KHACHHANG kHACHHANG)
        {
            if (ModelState.IsValid)
            {
                db.KHACHHANGs.Add(kHACHHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAQ = new SelectList(db.QUAN_HUYEN, "MAQ", "TENQH", kHACHHANG.MAQ);
            ViewBag.MATP = new SelectList(db.THANHPHO_TINH, "MATP", "TENTP_TINH", kHACHHANG.MATP);
            ViewBag.MAXP = new SelectList(db.PHUONG_XA, "MAXP", "TENXP", kHACHHANG.MAXP);
            ViewBag.MAKH = new SelectList(db.TKKHACHHANGs, "MAKH", "SDT", kHACHHANG.MAKH);
            return View(kHACHHANG);
        }

        // GET: Admin/KHACHHANGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG kHACHHANG = db.KHACHHANGs.Find(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAQ = new SelectList(db.QUAN_HUYEN, "MAQ", "TENQH", kHACHHANG.MAQ);
            ViewBag.MATP = new SelectList(db.THANHPHO_TINH, "MATP", "TENTP_TINH", kHACHHANG.MATP);
            ViewBag.MAXP = new SelectList(db.PHUONG_XA, "MAXP", "TENXP", kHACHHANG.MAXP);
            ViewBag.MAKH = new SelectList(db.TKKHACHHANGs, "MAKH", "SDT", kHACHHANG.MAKH);
            return View(kHACHHANG);
        }

        // POST: Admin/KHACHHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAKH,TENDAYDU,HO,LOT,TEN,GIOITINH,TUOI,SDT,Email,NGAYSINH,SONHA,CCCD,ANHDAIDIEN,XACNHANCC,BANGLAI,XACNHANBL,DUONG,ANHBL,ANHCCCDTRUOC,ANHCCCDSAU,MATP,MAXP,MAQ")] KHACHHANG kHACHHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHACHHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAQ = new SelectList(db.QUAN_HUYEN, "MAQ", "TENQH", kHACHHANG.MAQ);
            ViewBag.MATP = new SelectList(db.THANHPHO_TINH, "MATP", "TENTP_TINH", kHACHHANG.MATP);
            ViewBag.MAXP = new SelectList(db.PHUONG_XA, "MAXP", "TENXP", kHACHHANG.MAXP);
            ViewBag.MAKH = new SelectList(db.TKKHACHHANGs, "MAKH", "SDT", kHACHHANG.MAKH);
            return View(kHACHHANG);
        }

        // GET: Admin/KHACHHANGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACHHANG kHACHHANG = db.KHACHHANGs.Find(id);
            if (kHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACHHANG);
        }

        // POST: Admin/KHACHHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KHACHHANG kHACHHANG = db.KHACHHANGs.Find(id);
            db.KHACHHANGs.Remove(kHACHHANG);
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
