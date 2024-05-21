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
  
        DateTime dt = new DateTime().ToLocalTime();
        // GET: Account
        public string makh;
        public ActionResult Account_Information(string makh)
        {
            makh = Session["IDuser"].ToString();
            this.makh = makh;
            show.tKKHACHHANGs = db.TKKHACHHANGs.Where(n=>n.MAKH == makh).ToList();
            show.kHACHHANGs = db.KHACHHANGs.Where(n => n.MAKH == makh).ToList();
            show.tTHANHPHO_TINHs = db.THANHPHO_TINH.ToList();
            show.qUAN_HUYENs = db.QUAN_HUYEN.ToList();
            show.pHUONG_XAs = db.PHUONG_XA.ToList();
            return View(show);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Account_Information(string makh,HttpPostedFileBase ImageUpload)
        {
            makh = Session["IDuser"].ToString();
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
                kHACHHANG.CCCD = cccd;
                kHACHHANG.BANGLAI = bl;
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
        public ActionResult password(string makh,string oldpassword,string newpassword,string renewpassword,string xacnhan)
        {
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
       
    }
}