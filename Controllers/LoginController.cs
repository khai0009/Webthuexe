using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Webthuexe.Models;
using System.IO;
using static System.Collections.Specialized.BitVector32;

namespace Webthuexe.Controllers
{   
    
    public class LoginController : Controller
    {
        MyworldEntities db = new MyworldEntities();
        show databs = new show();
        // GET: Login
        public ActionResult login(string sdt,string password)
        {
            Session["checklogin"] = "true";
            if (sdt != null && password != null)
            {
                var tentk = db.TKKHACHHANGs.Where(n => n.SDT == sdt && n.MATKHAU == password).FirstOrDefault();
                var tenkh = db.KHACHHANGs.Where(n => n.SDT == sdt).FirstOrDefault();
                if (tentk == null && tentk == null) { Session["checklogin"] = "false"; return View(); }
                else
                {
                    TKKHACHHANG tKKHACHHANG = new TKKHACHHANG();
                    tKKHACHHANG = db.TKKHACHHANGs.Find(tenkh.MAKH);
                    tKKHACHHANG.TRANGTHAI = true;
                    tKKHACHHANG.TGDANGNHAP = DateTime.Now.ToLocalTime();
                    if (ModelState.IsValid)
                    {
                        db.Entry(tKKHACHHANG).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    Session["Username"] = tenkh.TEN;
                    Session["IDuser"] = tenkh.MAKH;
                    Session.Remove("checklogin");
                    return RedirectToAction("index", "Home");
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult Register(string lastname,string middlename, string firstname,string gt, string email,string password,string repassword,string sdt,string q,string tp,string px,string sn)
        {
            databs.tTHANHPHO_TINHs = db.THANHPHO_TINH.ToList();
            databs.qUAN_HUYENs = db.QUAN_HUYEN.ToList();
            databs.pHUONG_XAs = db.PHUONG_XA.ToList();
            DateTime dt = new DateTime().ToLocalTime();
            Session["checkregister"] = "true";
            if (lastname != null && firstname != null && gt != null && email != null && password != null && repassword != null && sdt != null)
            {
                if (password != repassword && password.Length < 8)
                {
                    Session["checkregister"] = "false";
                    return View(databs);
                }
                else
                {
                    
                    var checkdadangky = db.TKKHACHHANGs.Where(n => n.SDT == sdt).FirstOrDefault();
                    if (checkdadangky == null)
                    {
                        KHACHHANG kh = new KHACHHANG();
                        kh.SDT = sdt;
                        kh.HO = lastname;
                        kh.LOT = middlename;
                        kh.TEN = firstname;
                        kh.TENDAYDU = lastname + " " + middlename + " " + firstname;
                        kh.SONHA = sn;
                        kh.Email = email;
                        var t_p = databs.tTHANHPHO_TINHs.Where(n => n.TENTP_TINH == tp).FirstOrDefault();
                        if (t_p == null)  {
                            Session["checkregister"] = "false";
                            return View(databs);
                        }
                        else kh.MATP = t_p.MATP.ToString();
                        var quan = databs.qUAN_HUYENs.Where(n => n.TENQH == q).FirstOrDefault();
                        if (quan == null)
                        {
                            Session["checkregister"] = "false";
                            return View(databs);
                        }
                        else
                            kh.MAQ = quan.MAQ.ToString();
                        var phuong = databs.pHUONG_XAs.Where(n => n.TENXP == px).FirstOrDefault();
                        if (phuong == null)
                        {
                            Session["checkregister"] = "false";
                            return View(databs);
                        }
                        else
                            kh.MAXP = phuong.MAXP.ToString();
                        if (gt == "nam")
                            kh.GIOITINH = true;
                        else
                            kh.GIOITINH = false;
                        kh.MAKH = sdt.Substring(7, 3) + dt.Minute + dt.Hour + dt.Second + dt.Year + dt.Day + dt.Month;
                        if (ModelState.IsValid)
                        {
                            db.KHACHHANGs.Add(kh);
                            db.SaveChanges();
                        }
                        TKKHACHHANG tKKHACHHANG = new TKKHACHHANG();
                        tKKHACHHANG.SDT = sdt;
                        tKKHACHHANG.MATKHAU = password;
                        tKKHACHHANG.NGAYTAO = DateTime.Now;
                        tKKHACHHANG.MAKH = kh.MAKH.ToString();
                        if (ModelState.IsValid)
                        {
                            db.TKKHACHHANGs.Add(tKKHACHHANG);
                            db.SaveChanges();
                            Session.Remove("Check");
                        }
                        BAOHIEM bAOHIEM = new BAOHIEM();
                        bAOHIEM.MABH = "Bh" + kh.MAKH;
                        bAOHIEM.NGAYCAP = DateTime.Now;
                        bAOHIEM.MAKH = kh.MAKH;
                        if (ModelState.IsValid)
                        {
                            db.BAOHIEMs.Add(bAOHIEM);
                            db.SaveChanges();
                            

                        }
                        
                        Session.Remove("checkregister");
                        return RedirectToAction("login", "Login");
                        
                    }
                    else return View(databs);
                }
            }
            else return View(databs);
        }
        public ActionResult fotpass(string newpass,string renewpass,string xacnhan)
        {
            Session["checkfotpass"] = "true";
            if(xacnhan != null)
            { 
                if(newpass.Length >= 8 && newpass == renewpass)
                {
                    
                    string makh = Session["IDusertemp"].ToString();
                    Session.Remove("IDusertemp");
                    TKKHACHHANG kHACHHANG = db.TKKHACHHANGs.Where(n => n.MAKH == makh).FirstOrDefault();
                    kHACHHANG.MATKHAU = newpass;
                    db.Entry(kHACHHANG).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("login", "Login");
                }
                else
                {
                    Session["checkfotpass"] = "false";
                    return View();
                }
            }
            return View();
        }
        public ActionResult email(string email, string xacnhan)
        {
            Session["checkemail"] = "true";
            if (xacnhan != null)
            {
                if (email != null)
                {   
                    KHACHHANG kHACHHANG = new KHACHHANG();
                    kHACHHANG = db.KHACHHANGs.Where(n=>n.Email == email).FirstOrDefault();
                    if (kHACHHANG != null)
                    {
                        Session.Remove("checkemail");
                        Session["IDusertemp"] = kHACHHANG.MAKH;
                        return RedirectToAction("fotpass", "Account");
                    }
                    else
                    {
                        Session["checkemail"] = "false";
                        return View();
                    }
                }
                else
                {
                    Session["checkemail"] = "false";
                    return View();
                }
            }
            return View();
        }
    }
}