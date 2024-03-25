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
    public class NHANVIENsController : Controller
    {
        private MyworldEntities db = new MyworldEntities();

        // GET: Admin/NHANVIENs
        public ActionResult Index()
        {
            var nHANVIENs = db.NHANVIENs.Include(n => n.CHUCVU).Include(n => n.QUAN_HUYEN).Include(n => n.THANHPHO_TINH).Include(n => n.PHUONG_XA).Include(n => n.TKNV);
            return View(nHANVIENs.ToList());
        }

        // GET: Admin/NHANVIENs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // GET: Admin/NHANVIENs/Create
        public ActionResult Create()
        {
            ViewBag.MACV = new SelectList(db.CHUCVUs, "MACV", "TENCV");
            ViewBag.MAQ = new SelectList(db.QUAN_HUYEN, "MAQ", "TENQH");
            ViewBag.MATP = new SelectList(db.THANHPHO_TINH, "MATP", "TENTP_TINH");
            ViewBag.MAXP = new SelectList(db.PHUONG_XA, "MAXP", "TENXP");
            ViewBag.MANV = new SelectList(db.TKNVs, "MANV", "SDT");
            return View();
        }

        // POST: Admin/NHANVIENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MANV,TENDAYDU,HO,LOT,TEN,GIOITINH,SDT,Email,TUOI,NGAYSINH,CCCD,ANHDAIDIEN,DAXACTHUC,SONHA,MATP,MAXP,MAQ,MACV")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                db.NHANVIENs.Add(nHANVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MACV = new SelectList(db.CHUCVUs, "MACV", "TENCV", nHANVIEN.MACV);
            ViewBag.MAQ = new SelectList(db.QUAN_HUYEN, "MAQ", "TENQH", nHANVIEN.MAQ);
            ViewBag.MATP = new SelectList(db.THANHPHO_TINH, "MATP", "TENTP_TINH", nHANVIEN.MATP);
            ViewBag.MAXP = new SelectList(db.PHUONG_XA, "MAXP", "TENXP", nHANVIEN.MAXP);
            ViewBag.MANV = new SelectList(db.TKNVs, "MANV", "SDT", nHANVIEN.MANV);
            return View(nHANVIEN);
        }

        // GET: Admin/NHANVIENs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MACV = new SelectList(db.CHUCVUs, "MACV", "TENCV", nHANVIEN.MACV);
            ViewBag.MAQ = new SelectList(db.QUAN_HUYEN, "MAQ", "TENQH", nHANVIEN.MAQ);
            ViewBag.MATP = new SelectList(db.THANHPHO_TINH, "MATP", "TENTP_TINH", nHANVIEN.MATP);
            ViewBag.MAXP = new SelectList(db.PHUONG_XA, "MAXP", "TENXP", nHANVIEN.MAXP);
            ViewBag.MANV = new SelectList(db.TKNVs, "MANV", "SDT", nHANVIEN.MANV);
            return View(nHANVIEN);
        }

        // POST: Admin/NHANVIENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MANV,TENDAYDU,HO,LOT,TEN,GIOITINH,SDT,Email,TUOI,NGAYSINH,CCCD,ANHDAIDIEN,DAXACTHUC,SONHA,MATP,MAXP,MAQ,MACV")] NHANVIEN nHANVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nHANVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MACV = new SelectList(db.CHUCVUs, "MACV", "TENCV", nHANVIEN.MACV);
            ViewBag.MAQ = new SelectList(db.QUAN_HUYEN, "MAQ", "TENQH", nHANVIEN.MAQ);
            ViewBag.MATP = new SelectList(db.THANHPHO_TINH, "MATP", "TENTP_TINH", nHANVIEN.MATP);
            ViewBag.MAXP = new SelectList(db.PHUONG_XA, "MAXP", "TENXP", nHANVIEN.MAXP);
            ViewBag.MANV = new SelectList(db.TKNVs, "MANV", "SDT", nHANVIEN.MANV);
            return View(nHANVIEN);
        }

        // GET: Admin/NHANVIENs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            if (nHANVIEN == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIEN);
        }

        // POST: Admin/NHANVIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NHANVIEN nHANVIEN = db.NHANVIENs.Find(id);
            db.NHANVIENs.Remove(nHANVIEN);
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
