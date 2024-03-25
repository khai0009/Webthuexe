using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Webthuexe.Areas.Admin.Controllers;
using Webthuexe.Models;

namespace Webthuexe.Controllers
{
    public class AccountController : Controller
    {   
        MyworldEntities db = new MyworldEntities();
        show show = new show();
        string makh;
        DateTime dt = new DateTime().ToLocalTime();
        // GET: Account
        public ActionResult Account_Information()
        {
            this.makh = Session["IDuser"].ToString();
            show.tKKHACHHANGs = db.TKKHACHHANGs.Where(n=>n.MAKH == makh).ToList();
            show.kHACHHANGs = db.KHACHHANGs.Where(n => n.MAKH == makh).Include(n=>n.QUAN_HUYEN).Include(n => n.THANHPHO_TINH).Include(n => n.PHUONG_XA).ToList();
            show.tTHANHPHO_TINHs = db.THANHPHO_TINH.ToList();
            show.qUAN_HUYENs = db.QUAN_HUYEN.ToList();
            show.pHUONG_XAs = db.PHUONG_XA.ToList();
            return View(show);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Account_Information(HttpPostedFileBase ImageUpload)
        {
            this.makh = Session["IDuser"].ToString();
            if (ImageUpload != null)
            {

                KHACHHANG kHACHHANG = new KHACHHANG();
                kHACHHANG = db.KHACHHANGs.Where(n=>n.MAKH == makh).SingleOrDefault();
                string fileName = Path.GetFileName(ImageUpload.FileName);
                ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/imguser/") , fileName));
                string sourceFile = Path.Combine(Server.MapPath("~/Content/imguser/"), fileName);
                string destinationFile = Path.Combine(Server.MapPath("~/Content/imguser/"), makh+".jpg");                // Di chuyển và đổi tên file
                System.IO.File.Copy(sourceFile, destinationFile, true);
                System.IO.File.Delete(sourceFile);

                kHACHHANG.ANHDAIDIEN = makh + ".jpg";
                if (ModelState.IsValid)
                {
                    db.Entry(kHACHHANG).State = EntityState.Modified;
                    db.SaveChanges();
                }



            }
            show.tKKHACHHANGs = db.TKKHACHHANGs.Where(n => n.MAKH == makh).ToList();
            show.kHACHHANGs = db.KHACHHANGs.Where(n => n.MAKH == makh).ToList();
            show.tTHANHPHO_TINHs = db.THANHPHO_TINH.ToList();
            show.qUAN_HUYENs = db.QUAN_HUYEN.ToList();
            show.pHUONG_XAs = db.PHUONG_XA.ToList();
            return View(show);
      
        }
        
            public ActionResult Account_update(string xacnhan,string makh,string lastname, string middlename, string firstname, string gt, string email, string cccd, string ns, string sdt, string q, string tp, string px, string bl,string sn)
            {
            makh = Session["IDuser"].ToString();
            if (xacnhan != null)
            {   
                KHACHHANG kHACHHANG = new KHACHHANG();
                kHACHHANG = db.KHACHHANGs.Where(n => n.MAKH == makh).SingleOrDefault();
                kHACHHANG.SDT = sdt;
                kHACHHANG.HO = lastname;
                kHACHHANG.LOT = middlename;
                kHACHHANG.TEN = firstname;
                kHACHHANG.TENDAYDU = lastname + " " + middlename + " " + firstname;
                kHACHHANG.SONHA = sn;
                kHACHHANG.Email = email;
                DateTime ngayChuyenDoi = DateTime.ParseExact(ns, "M/d/yyyy", CultureInfo.InvariantCulture);
                string ngayChuyenDoiSangDinhDangMoi = ngayChuyenDoi.ToString("yyyy/MM/dd");
                kHACHHANG.NGAYSINH = ngayChuyenDoiSangDinhDangMoi.AsDateTime().Date;
                var t_p = db.THANHPHO_TINH.Where(n => n.TENTP_TINH == tp).SingleOrDefault();
                if (t_p == null) return View(show);
                else kHACHHANG.MATP = t_p.MATP.ToString();
                var quan = db.QUAN_HUYEN.Where(n => n.TENQH == q).SingleOrDefault();
                if (quan == null) return View(show);
                else
                    kHACHHANG.MAQ = quan.MAQ.ToString();
                var phuong = db.PHUONG_XA.Where(n => n.TENXP == px).SingleOrDefault();
                if (t_p == null) return View(show);
                else
                    kHACHHANG.MAXP = phuong.MAXP.ToString();

                if (gt == "nam")
                    kHACHHANG.GIOITINH = true;
                else
                    kHACHHANG.GIOITINH = false;
                if (ModelState.IsValid)
                {
                    db.Entry(kHACHHANG).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Account_information", "Account");
            }
            show.tKKHACHHANGs = db.TKKHACHHANGs.Where(n => n.MAKH == makh).ToList();
            show.kHACHHANGs = db.KHACHHANGs.Where(n => n.MAKH == makh).ToList();
            show.tTHANHPHO_TINHs = db.THANHPHO_TINH.ToList();
            show.qUAN_HUYENs = db.QUAN_HUYEN.ToList();
            show.pHUONG_XAs = db.PHUONG_XA.ToList();
            return View(show);
        }
        public ActionResult password(string oldpassword,string newpassword,string renewpassword,string xacnhan)
        {
            this.makh = Session["IDuser"].ToString();
            Session["checkoldpass"] = "true";
            if (xacnhan != null)
            {   
                TKKHACHHANG tKKHACHHANG = new TKKHACHHANG();
                tKKHACHHANG = db.TKKHACHHANGs.Where(n => n.MAKH == makh).SingleOrDefault();
                if (tKKHACHHANG == null)
                {
                    Session["checkoldpass"] = "false";
                    return View(show);
                }
                Session.Remove("checkoldpass");
                if (oldpassword == null || oldpassword != tKKHACHHANG.MATKHAU)
                {
                    Session["checknewold"] = "false";
                    return View(show);
                }
                else
                {
                    Session.Remove("checknewold");
                    if (newpassword.Length < 8 || renewpassword != newpassword)
                    {
                        Session["checknewpass"] = "false";
                        return View(show);
                    }
                    else
                    {
                        Session.Remove("checknewpass");
                        tKKHACHHANG.MATKHAU = newpassword;
                        if (ModelState.IsValid)
                        {
                            db.Entry(tKKHACHHANG).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }
            }
            
            show.tKKHACHHANGs = db.TKKHACHHANGs.Where(n => n.MAKH == makh).ToList();
            return View(show);
        }
        public ActionResult email() 
        {
            Session["checkemail"] = "true";

            return View(); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult email(string email)
        {
            var check = db.KHACHHANGs.Where(n => n.Email == email).SingleOrDefault();
            if(check != null)
            {
                Session.Remove("checkmail");
                return RedirectToAction("fotpass", "Login");
            }
            else 
            Session["checkemail"] = "true";
            return View();
        }
        public ActionResult CCCDupdate()
        {
            Session["checkimage"] = "true";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CCCDupdate(HttpPostedFileBase ImageUpload1, HttpPostedFileBase ImageUpload2)
        {
            this.makh = Session["IDuser"].ToString();
            if (ImageUpload1 != null && ImageUpload2 != null)
            {

                KHACHHANG kHACHHANG = db.KHACHHANGs.Where(n => n.MAKH == makh).SingleOrDefault();
                string fileName = Path.GetFileName(ImageUpload1.FileName);
                ImageUpload1.SaveAs(Path.Combine(Server.MapPath("~/Content/imguser/"), fileName));
                string sourceFile = Path.Combine(Server.MapPath("~/Content/imguser/"), fileName);
                string tenanhcccd = "CCCDFront" + makh + ".jpg";
                string destinationFile = Path.Combine(Server.MapPath("~/Content/imguser/"), tenanhcccd);                // Di chuyển và đổi tên file
                System.IO.File.Copy(sourceFile, destinationFile, true);
                System.IO.File.Delete(sourceFile);
                kHACHHANG.ANHCCCDTRUOC = tenanhcccd;
                if (ModelState.IsValid)
                {
                    db.Entry(kHACHHANG).State = EntityState.Modified;
                    db.SaveChanges();
                }
                fileName = Path.GetFileName(ImageUpload1.FileName);
                ImageUpload1.SaveAs(Path.Combine(Server.MapPath("~/Content/imguser/"), fileName));
                sourceFile = Path.Combine(Server.MapPath("~/Content/imguser/"), fileName);
                tenanhcccd = "CCCDBehind" + makh + ".jpg";
                destinationFile = Path.Combine(Server.MapPath("~/Content/imguser/"), tenanhcccd);                // Di chuyển và đổi tên file
                System.IO.File.Copy(sourceFile, destinationFile, true);
                System.IO.File.Delete(sourceFile);
                kHACHHANG.ANHCCCDSAU = tenanhcccd;
                if (ModelState.IsValid)
                {
                    db.Entry(kHACHHANG).State = EntityState.Modified;
                    db.SaveChanges();
                }
                Session.Remove("checkimage");

            }
            else
            {
                Session["checkimage"] = "false";
                return View();
            }
            return View();
        }
        public ActionResult licencedrive()
        {
            Session["checkimage"] = "true";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult licencedrive(HttpPostedFileBase ImageUpload1, HttpPostedFileBase ImageUpload2)
        {
            this.makh = Session["IDuser"].ToString();
            if (ImageUpload1 != null && ImageUpload2 != null)
            {

                KHACHHANG kHACHHANG = db.KHACHHANGs.Where(n => n.MAKH == makh).SingleOrDefault();
                string fileName = Path.GetFileName(ImageUpload1.FileName);
                ImageUpload1.SaveAs(Path.Combine(Server.MapPath("~/Content/imguser/"), fileName));
                string sourceFile = Path.Combine(Server.MapPath("~/Content/imguser/"), fileName);
                string tenanhcccd = "LDfront" + makh + ".jpg";
                string destinationFile = Path.Combine(Server.MapPath("~/Content/imguser/"), tenanhcccd);                // Di chuyển và đổi tên file
                System.IO.File.Copy(sourceFile, destinationFile, true);
                System.IO.File.Delete(sourceFile);
                kHACHHANG.ANHBLTRUOC = tenanhcccd;
                if (ModelState.IsValid)
                {
                    db.Entry(kHACHHANG).State = EntityState.Modified;
                    db.SaveChanges();
                }
                fileName = Path.GetFileName(ImageUpload1.FileName);
                ImageUpload1.SaveAs(Path.Combine(Server.MapPath("~/Content/imguser/"), fileName));
                sourceFile = Path.Combine(Server.MapPath("~/Content/imguser/"), fileName);
                tenanhcccd = "LDBehind" + makh + ".jpg";
                destinationFile = Path.Combine(Server.MapPath("~/Content/imguser/"), tenanhcccd);                // Di chuyển và đổi tên file
                System.IO.File.Copy(sourceFile, destinationFile, true);
                System.IO.File.Delete(sourceFile);
                kHACHHANG.ANHBLSAU = tenanhcccd;
                if (ModelState.IsValid)
                {
                    db.Entry(kHACHHANG).State = EntityState.Modified;
                    db.SaveChanges();
                }
                Session.Remove("checkimage");

            }
            else
            {
                Session["checkimage"] = "false";
                return View();
            }
            return View();
        }


    }
}