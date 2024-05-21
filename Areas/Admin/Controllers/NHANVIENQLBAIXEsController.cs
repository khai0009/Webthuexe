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
    public class NHANVIENQLBAIXEsController : Controller
    {
        private MyworldEntities db = new MyworldEntities();

        // GET: Admin/NHANVIENQLBAIXEs
        public ActionResult Index()
        {
            var nHANVIENQLBAIXEs = db.NHANVIENQLBAIXEs.Include(n => n.THANHPHO_TINH).Include(n => n.PHUONG_XA).Include(n => n.QUAN_HUYEN).Include(n => n.TKNVBAIXE);
            return View(nHANVIENQLBAIXEs.ToList());
        }

        // GET: Admin/NHANVIENQLBAIXEs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIENQLBAIXE nHANVIENQLBAIXE = db.NHANVIENQLBAIXEs.Find(id);
            if (nHANVIENQLBAIXE == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIENQLBAIXE);
        }

        // GET: Admin/NHANVIENQLBAIXEs/Create
        public ActionResult Create()
        {
            ViewBag.MATP = new SelectList(db.THANHPHO_TINH, "MATP", "TENTP_TINH");
            ViewBag.MAXP = new SelectList(db.PHUONG_XA, "MAXP", "TENXP");
            ViewBag.MAQ = new SelectList(db.QUAN_HUYEN, "MAQ", "TENQH");
            ViewBag.MANVBAIXE = new SelectList(db.TKNVBAIXEs, "MANVBAIXE", "SDT");
            return View();
        }

        // POST: Admin/NHANVIENQLBAIXEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MANVBAIXE,TENDAYDU,HO,LOT,TEN,GIOITINH,TUOI,NGAYSINH,SDT,SONHA,CCCD,DAXACTHUC,ANHDAIDIEN,MATP,MAXP,MAQ,Email")] NHANVIENQLBAIXE nHANVIENQLBAIXE)
        {
            if (ModelState.IsValid)
            {
                db.NHANVIENQLBAIXEs.Add(nHANVIENQLBAIXE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MATP = new SelectList(db.THANHPHO_TINH, "MATP", "TENTP_TINH", nHANVIENQLBAIXE.MATP);
            ViewBag.MAXP = new SelectList(db.PHUONG_XA, "MAXP", "TENXP", nHANVIENQLBAIXE.MAXP);
            ViewBag.MAQ = new SelectList(db.QUAN_HUYEN, "MAQ", "TENQH", nHANVIENQLBAIXE.MAQ);
            ViewBag.MANVBAIXE = new SelectList(db.TKNVBAIXEs, "MANVBAIXE", "SDT", nHANVIENQLBAIXE.MANVBAIXE);
            return View(nHANVIENQLBAIXE);
        }

        // GET: Admin/NHANVIENQLBAIXEs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIENQLBAIXE nHANVIENQLBAIXE = db.NHANVIENQLBAIXEs.Find(id);
            if (nHANVIENQLBAIXE == null)
            {
                return HttpNotFound();
            }
            ViewBag.MATP = new SelectList(db.THANHPHO_TINH, "MATP", "TENTP_TINH", nHANVIENQLBAIXE.MATP);
            ViewBag.MAXP = new SelectList(db.PHUONG_XA, "MAXP", "TENXP", nHANVIENQLBAIXE.MAXP);
            ViewBag.MAQ = new SelectList(db.QUAN_HUYEN, "MAQ", "TENQH", nHANVIENQLBAIXE.MAQ);
            ViewBag.MANVBAIXE = new SelectList(db.TKNVBAIXEs, "MANVBAIXE", "SDT", nHANVIENQLBAIXE.MANVBAIXE);
            return View(nHANVIENQLBAIXE);
        }

        // POST: Admin/NHANVIENQLBAIXEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MANVBAIXE,TENDAYDU,HO,LOT,TEN,GIOITINH,TUOI,NGAYSINH,SDT,SONHA,CCCD,DAXACTHUC,ANHDAIDIEN,MATP,MAXP,MAQ,Email")] NHANVIENQLBAIXE nHANVIENQLBAIXE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nHANVIENQLBAIXE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MATP = new SelectList(db.THANHPHO_TINH, "MATP", "TENTP_TINH", nHANVIENQLBAIXE.MATP);
            ViewBag.MAXP = new SelectList(db.PHUONG_XA, "MAXP", "TENXP", nHANVIENQLBAIXE.MAXP);
            ViewBag.MAQ = new SelectList(db.QUAN_HUYEN, "MAQ", "TENQH", nHANVIENQLBAIXE.MAQ);
            ViewBag.MANVBAIXE = new SelectList(db.TKNVBAIXEs, "MANVBAIXE", "SDT", nHANVIENQLBAIXE.MANVBAIXE);
            return View(nHANVIENQLBAIXE);
        }

        // GET: Admin/NHANVIENQLBAIXEs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHANVIENQLBAIXE nHANVIENQLBAIXE = db.NHANVIENQLBAIXEs.Find(id);
            if (nHANVIENQLBAIXE == null)
            {
                return HttpNotFound();
            }
            return View(nHANVIENQLBAIXE);
        }

        // POST: Admin/NHANVIENQLBAIXEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NHANVIENQLBAIXE nHANVIENQLBAIXE = db.NHANVIENQLBAIXEs.Find(id);
            db.NHANVIENQLBAIXEs.Remove(nHANVIENQLBAIXE);
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
