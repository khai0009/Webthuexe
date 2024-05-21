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
    public class XEsController : Controller
    {
        private MyworldEntities db = new MyworldEntities();

        // GET: Admin/XEs
        public ActionResult Index()
        {
            var xEs = db.XEs.Include(x => x.HANGXE).Include(x => x.NHIENLIEU).Include(x => x.SOGHE).Include(x => x.TINHTRANG);
            return View(xEs.ToList());
        }

        // GET: Admin/XEs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XE xE = db.XEs.Find(id);
            if (xE == null)
            {
                return HttpNotFound();
            }
            return View(xE);
        }

        // GET: Admin/XEs/Create
        public ActionResult Create()
        {
            ViewBag.MAHANG = new SelectList(db.HANGXEs, "MAHANG", "TENHANG");
            ViewBag.MANL = new SelectList(db.NHIENLIEUx, "MANL", "TENNL");
            ViewBag.MASG = new SelectList(db.SOGHEs, "MASG", "SOGHE1");
            ViewBag.MATT = new SelectList(db.TINHTRANGs, "MATT", "TENTT");
            return View();
        }

        // POST: Admin/XEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BIENXE,MAHANG,MANL,MASG,TENXE,NXS,LUOTTHUE,GIATHUE,DONVITINH,MATT,SOKM,NGAYNHAP,MAUSAC,ANH,MIEUTA")] XE xE)
        {
            if (ModelState.IsValid)
            {
                db.XEs.Add(xE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAHANG = new SelectList(db.HANGXEs, "MAHANG", "TENHANG", xE.MAHANG);
            ViewBag.MANL = new SelectList(db.NHIENLIEUx, "MANL", "TENNL", xE.MANL);
            ViewBag.MASG = new SelectList(db.SOGHEs, "MASG", "SOGHE1", xE.MASG);
            ViewBag.MATT = new SelectList(db.TINHTRANGs, "MATT", "TENTT", xE.MATT);
            return View(xE);
        }

        // GET: Admin/XEs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XE xE = db.XEs.Find(id);
            if (xE == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAHANG = new SelectList(db.HANGXEs, "MAHANG", "TENHANG", xE.MAHANG);
            ViewBag.MANL = new SelectList(db.NHIENLIEUx, "MANL", "TENNL", xE.MANL);
            ViewBag.MASG = new SelectList(db.SOGHEs, "MASG", "SOGHE1", xE.MASG);
            ViewBag.MATT = new SelectList(db.TINHTRANGs, "MATT", "TENTT", xE.MATT);
            return View(xE);
        }

        // POST: Admin/XEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BIENXE,MAHANG,MANL,MASG,TENXE,NXS,LUOTTHUE,GIATHUE,DONVITINH,MATT,SOKM,NGAYNHAP,MAUSAC,ANH,MIEUTA")] XE xE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(xE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAHANG = new SelectList(db.HANGXEs, "MAHANG", "TENHANG", xE.MAHANG);
            ViewBag.MANL = new SelectList(db.NHIENLIEUx, "MANL", "TENNL", xE.MANL);
            ViewBag.MASG = new SelectList(db.SOGHEs, "MASG", "SOGHE1", xE.MASG);
            ViewBag.MATT = new SelectList(db.TINHTRANGs, "MATT", "TENTT", xE.MATT);
            return View(xE);
        }

        // GET: Admin/XEs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XE xE = db.XEs.Find(id);
            if (xE == null)
            {
                return HttpNotFound();
            }
            return View(xE);
        }

        // POST: Admin/XEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            XE xE = db.XEs.Find(id);
            db.XEs.Remove(xE);
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
        public ActionResult Indexnvbx()
        {
            var xEs = db.XEs.Include(x => x.HANGXE).Include(x => x.NHIENLIEU).Include(x => x.SOGHE).Include(x => x.TINHTRANG);
            return View(xEs.ToList());
        }
        public ActionResult Editnvbx(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XE xE = db.XEs.Find(id);
            if (xE == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAHANG = new SelectList(db.HANGXEs, "MAHANG", "TENHANG", xE.MAHANG);
            ViewBag.MANL = new SelectList(db.NHIENLIEUx, "MANL", "TENNL", xE.MANL);
            ViewBag.MASG = new SelectList(db.SOGHEs, "MASG", "SOGHE1", xE.MASG);
            ViewBag.MATT = new SelectList(db.TINHTRANGs, "MATT", "TENTT", xE.MATT);
            return View(xE);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editnvbx([Bind(Include = "BIENXE,MATT,SOKM")] XE xE)
        {
            XE xEs = db.XEs.Where(n => n.BIENXE.Equals(xE.BIENXE)).SingleOrDefault();
            xEs.MATT = xE.MATT;
            xEs.SOKM = xE.SOKM;
            if (ModelState.IsValid)
            {
                db.Entry(xEs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Indexnvbx");
            }
            ViewBag.MAHANG = new SelectList(db.HANGXEs, "MAHANG", "TENHANG", xE.MAHANG);
            ViewBag.MANL = new SelectList(db.NHIENLIEUx, "MANL", "TENNL", xE.MANL);
            ViewBag.MASG = new SelectList(db.SOGHEs, "MASG", "SOGHE1", xE.MASG);
            ViewBag.MATT = new SelectList(db.TINHTRANGs, "MATT", "TENTT", xE.MATT);
            return View(xE);
        }

    }

}
