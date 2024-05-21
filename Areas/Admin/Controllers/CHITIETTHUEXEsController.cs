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
    
    public class CHITIETTHUEXEsController : Controller
    {
        private MyworldEntities db = new MyworldEntities();
        private show show = new show();
        // GET: Admin/CHITIETTHUEXEs
        public ActionResult Index()
        {
            var cHITIETTHUEXEs = db.CHITIETTHUEXEs.Include(c => c.XE);
            return View(cHITIETTHUEXEs.ToList());
        }

        // GET: Admin/CHITIETTHUEXEs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETTHUEXE cHITIETTHUEXE = db.CHITIETTHUEXEs.Find(id);
            if (cHITIETTHUEXE == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETTHUEXE);
        }

        // GET: Admin/CHITIETTHUEXEs/Create
        public ActionResult Create()
        {
            ViewBag.BIENXE = new SelectList(db.XEs, "BIENXE", "MAHANG");
            return View();
        }

        // POST: Admin/CHITIETTHUEXEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BIENXE,MAHD,COTAIXE,CHIPHI,SONGAYTHUE")] CHITIETTHUEXE cHITIETTHUEXE)
        {
            if (ModelState.IsValid)
            {
                db.CHITIETTHUEXEs.Add(cHITIETTHUEXE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BIENXE = new SelectList(db.XEs, "BIENXE", "MAHANG", cHITIETTHUEXE.BIENXE);
            return View(cHITIETTHUEXE);
        }

        // GET: Admin/CHITIETTHUEXEs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            show.CHITIETTHUEXE = db.CHITIETTHUEXEs.Where(n=>n.MAHD == id).FirstOrDefault();
            XE xes = db.XEs.Where(x => x.BIENXE == show.CHITIETTHUEXE.BIENXE).SingleOrDefault();
            show.xes = db.XEs.Where(n => n.TENXE == xes.TENXE).ToList();
            if (show.CHITIETTHUEXE == null)
            {
                return HttpNotFound();
            }
            ViewBag.BIENXE = new SelectList(db.XEs, "BIENXE", "MAHANG", show.CHITIETTHUEXE.BIENXE);
            return View(show);
        }

        // POST: Admin/CHITIETTHUEXEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BIENXE,MAHD,COTAIXE")] CHITIETTHUEXE cHITIETTHUEXE)
        {   
            CHITIETTHUEXE cHITIETTHUEXE1 = db.CHITIETTHUEXEs.Where(n=>n.MAHD == cHITIETTHUEXE.MAHD).FirstOrDefault();
            cHITIETTHUEXE1.COTAIXE = cHITIETTHUEXE1.COTAIXE;
            cHITIETTHUEXE1.BIENXE = cHITIETTHUEXE1.BIENXE;
            if (ModelState.IsValid)
            {
                db.Entry(cHITIETTHUEXE1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BIENXE = new SelectList(db.XEs, "BIENXE", "MAHANG", cHITIETTHUEXE.BIENXE);
            return View(cHITIETTHUEXE);
        }

        // GET: Admin/CHITIETTHUEXEs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETTHUEXE cHITIETTHUEXE = db.CHITIETTHUEXEs.Find(id);
            if (cHITIETTHUEXE == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETTHUEXE);
        }

        // POST: Admin/CHITIETTHUEXEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CHITIETTHUEXE cHITIETTHUEXE = db.CHITIETTHUEXEs.Find(id);
            db.CHITIETTHUEXEs.Remove(cHITIETTHUEXE);
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
