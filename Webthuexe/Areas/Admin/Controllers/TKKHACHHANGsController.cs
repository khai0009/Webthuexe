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
    public class TKKHACHHANGsController : Controller
    {
        private MyworldEntities db = new MyworldEntities();

        // GET: Admin/TKKHACHHANGs
        public ActionResult Index()
        {
            var tKKHACHHANGs = db.TKKHACHHANGs.Include(t => t.KHACHHANG);
            return View(tKKHACHHANGs.ToList());
        }

        // GET: Admin/TKKHACHHANGs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TKKHACHHANG tKKHACHHANG = db.TKKHACHHANGs.Find(id);
            if (tKKHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(tKKHACHHANG);
        }

        // GET: Admin/TKKHACHHANGs/Create
        public ActionResult Create()
        {
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENDAYDU");
            return View();
        }

        // POST: Admin/TKKHACHHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SDT,MAKH,MATKHAU,TGDANGNHAP,TRANGTHAI,NGAYTAO")] TKKHACHHANG tKKHACHHANG)
        {
            if (ModelState.IsValid)
            {
                db.TKKHACHHANGs.Add(tKKHACHHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENDAYDU", tKKHACHHANG.MAKH);
            return View(tKKHACHHANG);
        }

        // GET: Admin/TKKHACHHANGs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TKKHACHHANG tKKHACHHANG = db.TKKHACHHANGs.Find(id);
            if (tKKHACHHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENDAYDU", tKKHACHHANG.MAKH);
            return View(tKKHACHHANG);
        }

        // POST: Admin/TKKHACHHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SDT,MAKH,MATKHAU,TGDANGNHAP,TRANGTHAI,NGAYTAO")] TKKHACHHANG tKKHACHHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tKKHACHHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAKH = new SelectList(db.KHACHHANGs, "MAKH", "TENDAYDU", tKKHACHHANG.MAKH);
            return View(tKKHACHHANG);
        }

        // GET: Admin/TKKHACHHANGs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TKKHACHHANG tKKHACHHANG = db.TKKHACHHANGs.Find(id);
            if (tKKHACHHANG == null)
            {
                return HttpNotFound();
            }
            return View(tKKHACHHANG);
        }

        // POST: Admin/TKKHACHHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TKKHACHHANG tKKHACHHANG = db.TKKHACHHANGs.Find(id);
            db.TKKHACHHANGs.Remove(tKKHACHHANG);
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
