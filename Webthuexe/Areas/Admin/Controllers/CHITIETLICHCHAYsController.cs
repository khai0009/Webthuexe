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
    public class CHITIETLICHCHAYsController : Controller
    {
        private MyworldEntities db = new MyworldEntities();
        show show   = new show();

        // GET: Admin/CHITIETLICHCHAYs
        public ActionResult Index()
        {
            DateTime time = DateTime.Now.ToLocalTime();
            DateTime ngaydau = time.AddDays(-(int)time.DayOfWeek);
            ViewBag.ngaydau = ngaydau;
            show.hOADONTHUEXEs = db.HOADONTHUEXEs.Include(n=>n.KHACHHANG).ToList();
            show.cHITIETLICHCHAYs = db.CHITIETLICHCHAYs.Include(c => c.TKTAIXE).Include(c => c.TKTAIXE).Include(c => c.HOADONTHUEXE).ToList();
            return View(show);
        }

        // GET: Admin/CHITIETLICHCHAYs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETLICHCHAY cHITIETLICHCHAY = db.CHITIETLICHCHAYs.Find(id);
            if (cHITIETLICHCHAY == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETLICHCHAY);
        }

        // GET: Admin/CHITIETLICHCHAYs/Create
        public ActionResult Create()
        {
            ViewBag.MATAIXE = new SelectList(db.TKTAIXEs, "MATAIXE", "SDT");
            ViewBag.MATAIXE = new SelectList(db.TKTAIXEs, "MATAIXE", "SDT");
            ViewBag.MATAIXE = new SelectList(db.TKTAIXEs, "MATAIXE", "SDT");
            ViewBag.MATAIXE = new SelectList(db.TKTAIXEs, "MATAIXE", "SDT");
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE");
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE");
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE");
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE");
            return View();
        }

        // POST: Admin/CHITIETLICHCHAYs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BIENXE,MAHD,MATAIXE,DAHOANTHANH,NOIDON,NOIDI")] CHITIETLICHCHAY cHITIETLICHCHAY)
        {
            if (ModelState.IsValid)
            {
                db.CHITIETLICHCHAYs.Add(cHITIETLICHCHAY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MATAIXE = new SelectList(db.TKTAIXEs, "MATAIXE", "SDT", cHITIETLICHCHAY.MATAIXE);
            ViewBag.MATAIXE = new SelectList(db.TKTAIXEs, "MATAIXE", "SDT", cHITIETLICHCHAY.MATAIXE);
            ViewBag.MATAIXE = new SelectList(db.TKTAIXEs, "MATAIXE", "SDT", cHITIETLICHCHAY.MATAIXE);
            ViewBag.MATAIXE = new SelectList(db.TKTAIXEs, "MATAIXE", "SDT", cHITIETLICHCHAY.MATAIXE);
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE", cHITIETLICHCHAY.MAHD);
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE", cHITIETLICHCHAY.MAHD);
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE", cHITIETLICHCHAY.MAHD);
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE", cHITIETLICHCHAY.MAHD);
            return View(cHITIETLICHCHAY);
        }

        // GET: Admin/CHITIETLICHCHAYs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETLICHCHAY cHITIETLICHCHAY = db.CHITIETLICHCHAYs.Find(id);
            if (cHITIETLICHCHAY == null)
            {
                return HttpNotFound();
            }
            ViewBag.MATAIXE = new SelectList(db.TKTAIXEs, "MATAIXE", "SDT", cHITIETLICHCHAY.MATAIXE);
            ViewBag.MATAIXE = new SelectList(db.TKTAIXEs, "MATAIXE", "SDT", cHITIETLICHCHAY.MATAIXE);
            ViewBag.MATAIXE = new SelectList(db.TKTAIXEs, "MATAIXE", "SDT", cHITIETLICHCHAY.MATAIXE);
            ViewBag.MATAIXE = new SelectList(db.TKTAIXEs, "MATAIXE", "SDT", cHITIETLICHCHAY.MATAIXE);
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE", cHITIETLICHCHAY.MAHD);
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE", cHITIETLICHCHAY.MAHD);
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE", cHITIETLICHCHAY.MAHD);
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE", cHITIETLICHCHAY.MAHD);
            return View(cHITIETLICHCHAY);
        }

        // POST: Admin/CHITIETLICHCHAYs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BIENXE,MAHD,MATAIXE,DAHOANTHANH,NOIDON,NOIDI")] CHITIETLICHCHAY cHITIETLICHCHAY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHITIETLICHCHAY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MATAIXE = new SelectList(db.TKTAIXEs, "MATAIXE", "SDT", cHITIETLICHCHAY.MATAIXE);
            ViewBag.MATAIXE = new SelectList(db.TKTAIXEs, "MATAIXE", "SDT", cHITIETLICHCHAY.MATAIXE);
            ViewBag.MATAIXE = new SelectList(db.TKTAIXEs, "MATAIXE", "SDT", cHITIETLICHCHAY.MATAIXE);
            ViewBag.MATAIXE = new SelectList(db.TKTAIXEs, "MATAIXE", "SDT", cHITIETLICHCHAY.MATAIXE);
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE", cHITIETLICHCHAY.MAHD);
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE", cHITIETLICHCHAY.MAHD);
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE", cHITIETLICHCHAY.MAHD);
            ViewBag.MAHD = new SelectList(db.HOADONTHUEXEs, "MAHD", "BIENXE", cHITIETLICHCHAY.MAHD);
            return View(cHITIETLICHCHAY);
        }

        // GET: Admin/CHITIETLICHCHAYs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETLICHCHAY cHITIETLICHCHAY = db.CHITIETLICHCHAYs.Find(id);
            if (cHITIETLICHCHAY == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETLICHCHAY);
        }

        // POST: Admin/CHITIETLICHCHAYs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CHITIETLICHCHAY cHITIETLICHCHAY = db.CHITIETLICHCHAYs.Find(id);
            db.CHITIETLICHCHAYs.Remove(cHITIETLICHCHAY);
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
