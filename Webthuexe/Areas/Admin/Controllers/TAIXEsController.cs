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
    public class TAIXEsController : Controller
    {
        private MyworldEntities db = new MyworldEntities();

        // GET: Admin/TAIXEs
      
        public ActionResult Index(string timkiem)
        {
            var tAIXEs = db.TAIXEs.Include(t => t.PHUONG_XA).Include(t => t.QUAN_HUYEN).Include(t => t.THANHPHO_TINH).Include(t => t.TKTAIXE);
            if (!string.IsNullOrWhiteSpace(timkiem))
            {
                tAIXEs = db.TAIXEs.Include(t => t.PHUONG_XA).Include(t => t.QUAN_HUYEN).Include(t => t.THANHPHO_TINH).Include(t => t.TKTAIXE).Where(n=>n.SDT == timkiem || n.MATAIXE.Contains(timkiem));
            }
            
            return View(tAIXEs.ToList());
        }

        // GET: Admin/TAIXEs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAIXE tAIXE = db.TAIXEs.Find(id);
            if (tAIXE == null)
            {
                return HttpNotFound();
            }
            return View(tAIXE);
        }

        // GET: Admin/TAIXEs/Create
        public ActionResult Create()
        {
            ViewBag.MAXP = new SelectList(db.PHUONG_XA, "MAXP", "TENXP");
            ViewBag.MAQ = new SelectList(db.QUAN_HUYEN, "MAQ", "TENQH");
            ViewBag.MATP = new SelectList(db.THANHPHO_TINH, "MATP", "TENTP_TINH");
            ViewBag.MATAIXE = new SelectList(db.TKTAIXEs, "MATAIXE", "SDT");
            return View();
        }

        // POST: Admin/TAIXEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MATAIXE,TENDAYDU,HO,LOT,TEN,GIOTINH,TUOI,NGAYSINH,SONHA,SDT,Email,BANGLAI,CCCD,ANHDAIDIEN,XACTHUCCC,XACTHUCBL,DUONG,MATP,MAXP,MAQ")] TAIXE tAIXE)
        {
            if (ModelState.IsValid)
            {
                db.TAIXEs.Add(tAIXE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MAXP = new SelectList(db.PHUONG_XA, "MAXP", "TENXP", tAIXE.MAXP);
            ViewBag.MAQ = new SelectList(db.QUAN_HUYEN, "MAQ", "TENQH", tAIXE.MAQ);
            ViewBag.MATP = new SelectList(db.THANHPHO_TINH, "MATP", "TENTP_TINH", tAIXE.MATP);
            ViewBag.MATAIXE = new SelectList(db.TKTAIXEs, "MATAIXE", "SDT", tAIXE.MATAIXE);
            return View(tAIXE);
        }

        // GET: Admin/TAIXEs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAIXE tAIXE = db.TAIXEs.Find(id);
            if (tAIXE == null)
            {
                return HttpNotFound();
            }
            ViewBag.MAXP = new SelectList(db.PHUONG_XA, "MAXP", "TENXP", tAIXE.MAXP);
            ViewBag.MAQ = new SelectList(db.QUAN_HUYEN, "MAQ", "TENQH", tAIXE.MAQ);
            ViewBag.MATP = new SelectList(db.THANHPHO_TINH, "MATP", "TENTP_TINH", tAIXE.MATP);
            ViewBag.MATAIXE = new SelectList(db.TKTAIXEs, "MATAIXE", "SDT", tAIXE.MATAIXE);
            return View(tAIXE);
        }

        // POST: Admin/TAIXEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MATAIXE,TENDAYDU,HO,LOT,TEN,GIOTINH,TUOI,NGAYSINH,SONHA,SDT,Email,BANGLAI,CCCD,ANHDAIDIEN,XACTHUCCC,XACTHUCBL,DUONG,MATP,MAXP,MAQ")] TAIXE tAIXE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAIXE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MAXP = new SelectList(db.PHUONG_XA, "MAXP", "TENXP", tAIXE.MAXP);
            ViewBag.MAQ = new SelectList(db.QUAN_HUYEN, "MAQ", "TENQH", tAIXE.MAQ);
            ViewBag.MATP = new SelectList(db.THANHPHO_TINH, "MATP", "TENTP_TINH", tAIXE.MATP);
            ViewBag.MATAIXE = new SelectList(db.TKTAIXEs, "MATAIXE", "SDT", tAIXE.MATAIXE);
            return View(tAIXE);
        }

        // GET: Admin/TAIXEs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAIXE tAIXE = db.TAIXEs.Find(id);
            if (tAIXE == null)
            {
                return HttpNotFound();
            }
            return View(tAIXE);
        }

        // POST: Admin/TAIXEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TAIXE tAIXE = db.TAIXEs.Find(id);
            db.TAIXEs.Remove(tAIXE);
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
