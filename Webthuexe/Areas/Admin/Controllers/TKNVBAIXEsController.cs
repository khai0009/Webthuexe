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
    public class TKNVBAIXEsController : Controller
    {
        private MyworldEntities db = new MyworldEntities();

        // GET: Admin/TKNVBAIXEs
        public ActionResult Index()
        {
            var tKNVBAIXEs = db.TKNVBAIXEs.Include(t => t.NHANVIENQLBAIXE);
            return View(tKNVBAIXEs.ToList());
        }

        // GET: Admin/TKNVBAIXEs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TKNVBAIXE tKNVBAIXE = db.TKNVBAIXEs.Find(id);
            if (tKNVBAIXE == null)
            {
                return HttpNotFound();
            }
            return View(tKNVBAIXE);
        }

        // GET: Admin/TKNVBAIXEs/Create
        public ActionResult Create()
        {
            ViewBag.MANVBAIXE = new SelectList(db.NHANVIENQLBAIXEs, "MANVBAIXE", "TENDAYDU");
            return View();
        }

        // POST: Admin/TKNVBAIXEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SDT,MATKHAU,MANVBAIXE,TRANGTHAI,TGDANGNHAP,NGAYTAO")] TKNVBAIXE tKNVBAIXE)
        {
            if (ModelState.IsValid)
            {
                db.TKNVBAIXEs.Add(tKNVBAIXE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MANVBAIXE = new SelectList(db.NHANVIENQLBAIXEs, "MANVBAIXE", "TENDAYDU", tKNVBAIXE.MANVBAIXE);
            return View(tKNVBAIXE);
        }

        // GET: Admin/TKNVBAIXEs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TKNVBAIXE tKNVBAIXE = db.TKNVBAIXEs.Find(id);
            if (tKNVBAIXE == null)
            {
                return HttpNotFound();
            }
            ViewBag.MANVBAIXE = new SelectList(db.NHANVIENQLBAIXEs, "MANVBAIXE", "TENDAYDU", tKNVBAIXE.MANVBAIXE);
            return View(tKNVBAIXE);
        }

        // POST: Admin/TKNVBAIXEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SDT,MATKHAU,MANVBAIXE,TRANGTHAI,TGDANGNHAP,NGAYTAO")] TKNVBAIXE tKNVBAIXE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tKNVBAIXE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MANVBAIXE = new SelectList(db.NHANVIENQLBAIXEs, "MANVBAIXE", "TENDAYDU", tKNVBAIXE.MANVBAIXE);
            return View(tKNVBAIXE);
        }

        // GET: Admin/TKNVBAIXEs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TKNVBAIXE tKNVBAIXE = db.TKNVBAIXEs.Find(id);
            if (tKNVBAIXE == null)
            {
                return HttpNotFound();
            }
            return View(tKNVBAIXE);
        }

        // POST: Admin/TKNVBAIXEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TKNVBAIXE tKNVBAIXE = db.TKNVBAIXEs.Find(id);
            db.TKNVBAIXEs.Remove(tKNVBAIXE);
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
