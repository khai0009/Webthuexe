using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using System.Xml.Linq;
using Webthuexe.Models;

namespace Webthuexe.Areas.Admin.Controllers
{   
    
    public class LoginadminController : Controller
    {
        MyworldEntities db = new MyworldEntities();
        show databs = new show();
        // GET: Login

        
        public ActionResult login(string sdt,string pas,string cv)
        {
            Session["checkloginadmin"] = "true";
            if(cv != null && cv != "Nhân viên bãi xe")
            {
                var tentk = db.TKNVs.Where(n => n.SDT == sdt && n.MATKHAU == pas).FirstOrDefault();
                
                if (tentk != null) { 
                    var hoten = db.NHANVIENs.Where(n => n.MANV == tentk.MANV).SingleOrDefault();
                    Session.Remove("checkloginadmin");
                    Session["IDadmin"] = tentk.MANV;
                    Session["Nameadmin"] = hoten.TENDAYDU;
                    Session["CV"] = cv;
                    Session.Remove("checkloginadmin");
                    switch (cv)
                        {
                            case "Tiếp tân": return RedirectToAction("Index", "XEs",new { area = "Admin" }); 
                            case "Thu ngân": return RedirectToAction("Index", "PHIEUTHANHTOANs",new { area = "Admin" });
                            case "Quản lí": return RedirectToAction("Index", "XEs", new { area = "Admin" });
                            default: return RedirectToAction("Index", "XEs", new { area = "Admin" });
                        }

                    
                    
                }
                else
                {
                    Session["checkloginadmin"] = "false";
                    return View();
                }

            }
            if(cv != null && cv == "Tài xế")
            {
                var tentk = db.TKTAIXEs.Where(n => n.SDT == sdt && n.MATKHAU == pas).FirstOrDefault();
                if (tentk != null)
                {
                    var hoten = db.TAIXEs.Where(n => n.MATAIXE == tentk.MATAIXE).FirstOrDefault();

                    if (tentk != null)
                    {
                        Session.Remove("checkloginadmin");
                        Session["IDadmin"] = tentk.MATAIXE;
                        Session["Nameadmin"] = hoten.TENDAYDU;
                        Session["CV"] = cv;
                        return RedirectToAction("Indexnvbx", "XEs", new { area = "Admin" });

                    }
                    else
                    {
                        Session["checkloginadmin"] = "false";
                        return View();
                    }

                }
                else
                {
                    Session["checkloginadmin"] = "false";
                    return View();
                }

            }
            if (cv != null && cv == "Nhân viên bãi xe")
            {
                var tentk = db.TKNVBAIXEs.Where(n => n.SDT == sdt && n.MATKHAU == pas).FirstOrDefault();
                if (tentk != null)
                {
                    var hoten = db.NHANVIENQLBAIXEs.Where(n => n.MANVBAIXE == tentk.MANVBAIXE).FirstOrDefault();

                    if (tentk != null)
                    {
                        Session.Remove("checkloginadmin");
                        Session["IDadmin"] = tentk.MANVBAIXE;
                        Session["Nameadmin"] = hoten.TENDAYDU;
                        Session["CV"] = cv;
                        return RedirectToAction("Indexnvbx", "XEs", new { area = "Admin" });

                    }
                    else
                    {
                        Session["checkloginadmin"] = "false";
                        return View();
                    }

                }
                else
                {
                    Session["checkloginadmin"] = "false";
                    return View();
                }

            }
            
            return View();
        }
        public ActionResult fotpass(string xacnhan,string  newpass,string renewpass)
        {
            
            Session["checkfotpassadmin"] = "true";
            if (xacnhan != null)
            {
                if (newpass.Length >= 8 && newpass == renewpass)
                {

                    string makh = Session["IDadmintemp"].ToString();
                    Session.Remove("IDadmintemp");
                    if (Session["table"].ToString() == "nv")
                    {
                        TKNV nHANVIEN = db.TKNVs.Where(n=>n.MANV == makh).FirstOrDefault();
                        nHANVIEN.MANV = newpass;
                        db.Entry(nHANVIEN).State = EntityState.Modified;
                        db.SaveChanges();
                        Session.Remove("table");
                        return RedirectToAction("login", "Login");


                    }
                    if (Session["table"].ToString() == "bx")
                    {
                        TKNVBAIXE nHANVIEN = db.TKNVBAIXEs.Where(n => n.MANVBAIXE == makh).FirstOrDefault();
                        nHANVIEN.MANVBAIXE = newpass;
                        db.Entry(nHANVIEN).State = EntityState.Modified;
                        db.SaveChanges();
                        Session.Remove("table");
                        return RedirectToAction("login", "Login");
                    }
                    if (Session["table"].ToString() == "tx")
                    {
                        TKTAIXE nHANVIEN = db.TKTAIXEs.Where(n => n.MATAIXE == makh).FirstOrDefault();
                        nHANVIEN.MATAIXE = newpass;
                        db.Entry(nHANVIEN).State = EntityState.Modified;
                        db.SaveChanges();
                        Session.Remove("table");
                        return RedirectToAction("login", "Login");
                    }
                    
                }
                else
                {
                    Session["checkfotpass"] = "false";
                    return View();
                }
            }
            return View();
        }
        public ActionResult update()
        {
            return View();
        }
        public ActionResult Account_Information(string makh)
        {
            makh = Session["IDadmin"].ToString();
            databs.nHANVIENQLBAIXEs = db.NHANVIENQLBAIXEs.Where(n => n.MANVBAIXE == makh).ToList();
            databs.nHANVIENs = db.NHANVIENs.Where(n => n.MANV == makh).ToList();
            databs.tAIXEs = db.TAIXEs.Where(n => n.MATAIXE == makh).ToList();
            databs.tTHANHPHO_TINHs = db.THANHPHO_TINH.ToList();
            databs.qUAN_HUYENs = db.QUAN_HUYEN.ToList();
            databs.pHUONG_XAs = db.PHUONG_XA.ToList();
            return View(databs);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Account_Information(string makh, HttpPostedFileBase ImageUpload)
        {
            makh = Session["IDadmin"].ToString();
            string cv = Session["CV"].ToString();
            if (ImageUpload != null)
            {
                if (cv != "Nhân viên bãi xe")
                {  
                    var cHUCVU = db.CHUCVUs.Where(n => n.TENCV == cv).SingleOrDefault();
                    NHANVIEN nHANVIEN = db.NHANVIENs.Where(n => n.MANV == makh && n.MACV == cHUCVU.MACV).SingleOrDefault();
                    string fileName = Path.GetFileName(ImageUpload.FileName);
                    ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/imgadmin/"), fileName));
                    string sourceFile = Path.Combine(Server.MapPath("~/Content/imgadmin/"), fileName);
                    string destinationFile = Path.Combine(Server.MapPath("~/Content/imgadmin/"), makh + ".jpg");                // Di chuyển và đổi tên file
                    System.IO.File.Copy(sourceFile, destinationFile, true);
                    System.IO.File.Delete(sourceFile);
                    nHANVIEN.ANHDAIDIEN = makh + ".jpg";
                    if (ModelState.IsValid)
                    {
                        db.Entry(nHANVIEN).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                else
                {
                    
                    NHANVIENQLBAIXE nHANVIEN = db.NHANVIENQLBAIXEs.Where(n => n.MANVBAIXE == makh).SingleOrDefault();
                    string fileName = Path.GetFileName(ImageUpload.FileName);
                    ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/imgbx/"), fileName));
                    string sourceFile = Path.Combine(Server.MapPath("~/Content/imgbx/"), fileName);
                    string destinationFile = Path.Combine(Server.MapPath("~/Content/imgbx/"), makh + ".jpg");                // Di chuyển và đổi tên file
                    System.IO.File.Copy(sourceFile, destinationFile, true);
                    System.IO.File.Delete(sourceFile);
                    nHANVIEN.ANHDAIDIEN = makh + ".jpg";
                    if (ModelState.IsValid)
                    {
                        db.Entry(nHANVIEN).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                
                



            }
            databs.tKKHACHHANGs = db.TKKHACHHANGs.Where(n => n.MAKH == makh).ToList();
            databs.kHACHHANGs = db.KHACHHANGs.Where(n => n.MAKH == makh).ToList();
            databs.tTHANHPHO_TINHs = db.THANHPHO_TINH.ToList();
            databs.qUAN_HUYENs = db.QUAN_HUYEN.ToList();
            databs.pHUONG_XAs = db.PHUONG_XA.ToList();
            return View(databs);

        }
        public ActionResult Account_update(string xacnhan, string email, string sdt, string q, string tp, string px, string bl, string sn)
        {
            string makh = Session["IDadmin"].ToString();
            string cv = Session["CV"].ToString();
            Session["checkupdateadmin"] = "true";
            if (xacnhan != null)
            {   
                if(email == null || q==null || tp == null || px==null || sdt == null || sn == null)
                {
                    Session["checkupdateadmin"] = "false";
                    return View();
                }
                Session.Remove("checkupdateadmin");
                if (cv != "Nhân viên bãi xe" && cv != "Tài xế")
                {
                    NHANVIEN nHANVIEN = db.NHANVIENs.Where(n=>n.MANV == makh).SingleOrDefault();
                    nHANVIEN.SDT = sdt;
                    nHANVIEN.SONHA = sn;
                    nHANVIEN.Email = email;
                    var t_p = db.THANHPHO_TINH.Where(n => n.TENTP_TINH == tp).SingleOrDefault();
                    if (t_p == null) return View();
                    else nHANVIEN.MATP = t_p.MATP.ToString();
                    var quan = db.QUAN_HUYEN.Where(n => n.TENQH == q).SingleOrDefault();
                    if (quan == null) return View();
                    else
                        nHANVIEN.MAQ = quan.MAQ.ToString();
                    var phuong = db.PHUONG_XA.Where(n => n.TENXP == px).SingleOrDefault();
                    if (t_p == null) return View();
                    else
                        nHANVIEN.MAXP = phuong.MAXP.ToString();
                    if (ModelState.IsValid)
                    {
                        db.Entry(nHANVIEN).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                
                }
                if (cv == "Tài xế")
                {
                    TAIXE nHANVIEN = db.TAIXEs.Where(n => n.MATAIXE == makh).SingleOrDefault();
                    nHANVIEN.SDT = sdt;
                    nHANVIEN.SONHA = sn;
                    nHANVIEN.Email = email;
                    var t_p = db.THANHPHO_TINH.Where(n => n.TENTP_TINH == tp).SingleOrDefault();
                    if (t_p == null) return View();
                    else nHANVIEN.MATP = t_p.MATP.ToString();
                    var quan = db.QUAN_HUYEN.Where(n => n.TENQH == q).SingleOrDefault();
                    if (quan == null) return View();
                    else
                        nHANVIEN.MAQ = quan.MAQ.ToString();
                    var phuong = db.PHUONG_XA.Where(n => n.TENXP == px).SingleOrDefault();
                    if (t_p == null) return View();
                    else
                        nHANVIEN.MAXP = phuong.MAXP.ToString();
                    if (ModelState.IsValid)
                    {
                        db.Entry(nHANVIEN).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                else
                {
                    NHANVIENQLBAIXE nHANVIEN = db.NHANVIENQLBAIXEs.Where(n => n.MANVBAIXE == makh).SingleOrDefault();
                    nHANVIEN.SDT = sdt;
                    nHANVIEN.SONHA = sn;
                    nHANVIEN.Email = email;
                    var t_p = db.THANHPHO_TINH.Where(n => n.TENTP_TINH == tp).SingleOrDefault();
                    if (t_p == null) return View();
                    else nHANVIEN.MATP = t_p.MATP.ToString();
                    var quan = db.QUAN_HUYEN.Where(n => n.TENQH == q).SingleOrDefault();
                    if (quan == null) return View();
                    else
                        nHANVIEN.MAQ = quan.MAQ.ToString();
                    var phuong = db.PHUONG_XA.Where(n => n.TENXP == px).SingleOrDefault();
                    if (t_p == null) return View();
                    else
                        nHANVIEN.MAXP = phuong.MAXP.ToString();
                    if (ModelState.IsValid)
                    {
                        db.Entry(nHANVIEN).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Account_information", "Account");
            }
            databs.tKKHACHHANGs = db.TKKHACHHANGs.Where(n => n.MAKH == makh).ToList();
            databs.kHACHHANGs = db.KHACHHANGs.Where(n => n.MAKH == makh).ToList();
            databs.tTHANHPHO_TINHs = db.THANHPHO_TINH.ToList();
            databs.qUAN_HUYENs = db.QUAN_HUYEN.ToList();
            databs.pHUONG_XAs = db.PHUONG_XA.ToList();
            return View(databs);
        }
        public ActionResult register(string email, string password, string repassword, string sdt,string cv,string manv)
        {
            
            DateTime dt = new DateTime().ToLocalTime();
            Session["checkregisteradmin"] = "true";
            if (email != null && password != null && repassword != null && sdt != null)
            {
                if (password != repassword && password.Length < 8)
                {
                    Session["checkregisteradmin"] = "false";
                    return View();
                }
                else
                {
                    if (cv != "Nhân viên bãi xe" && cv != "Tài xế")
                    {
                        NHANVIEN nHANVIEN = db.NHANVIENs.Where(n => n.SDT == sdt && n.MANV == manv).SingleOrDefault();
                        if (nHANVIEN != null)
                        {
                            TKNV tKNV = db.TKNVs.Where(n=>n.MANV == nHANVIEN.MANV).SingleOrDefault();
                            tKNV.MANV = manv;
                            tKNV.SDT = sdt;
                            tKNV.MATKHAU = password;
                            tKNV.NGAYTAO = DateTime.Now.ToLocalTime();
                            if (ModelState.IsValid)
                            {
                                db.TKNVs.Add(tKNV);
                                db.SaveChanges();
                            }

                            Session.Remove("checkregisteradmin");
                            return RedirectToAction("login", "Loginadmin");

                        }
                        else
                        {
                            Session.Remove("checkregisteradmin");
                            return View();

                        }
                        

                    }
                    else
                    {
                        if(cv == "Nhân viên bãi xe")
                        {
                            NHANVIENQLBAIXE nHANVIEN = db.NHANVIENQLBAIXEs.Where(n => n.SDT == sdt && n.MANVBAIXE == manv).SingleOrDefault();
                            if (nHANVIEN != null)
                            {
                                TKNVBAIXE tKNVBAIXE = db.TKNVBAIXEs.Where(n => n.MANVBAIXE == nHANVIEN.MANVBAIXE).SingleOrDefault();
                                tKNVBAIXE.MATKHAU = password;
                                tKNVBAIXE.MANVBAIXE = manv;
                                tKNVBAIXE.SDT = sdt;
                                tKNVBAIXE.NGAYTAO = DateTime.Now.ToLocalTime();
                                if (ModelState.IsValid)
                                {
                                    db.TKNVBAIXEs.Add(tKNVBAIXE);
                                    db.SaveChanges();
                                }

                                Session.Remove("checkregisteradmin");
                                return RedirectToAction("login", "Loginadmin");

                            }
                            else
                            {
                                Session["checkregisteradmin"] = "false";
                                return View();

                            }
                        }
                        else
                        {
                            TAIXE nHANVIEN = db.TAIXEs.Where(n => n.SDT == sdt && n.MATAIXE == manv).SingleOrDefault();
                            if (nHANVIEN != null)
                            {
                                TKTAIXE tKNVBAIXE = db.TKTAIXEs.Where(n => n.MATAIXE == nHANVIEN.MATAIXE).SingleOrDefault();
                                tKNVBAIXE.MATKHAU = password;
                                tKNVBAIXE.MATAIXE = manv;
                                tKNVBAIXE.SDT = sdt;
                                tKNVBAIXE.NGAYTAO = DateTime.Now.ToLocalTime();
                                if (ModelState.IsValid)
                                {
                                    db.TKTAIXEs.Add(tKNVBAIXE);
                                    db.SaveChanges();
                                }

                                Session.Remove("checkregisteradmin");
                                return RedirectToAction("login", "Loginadmin");

                            }
                            else
                            {
                                Session["checkregisteradmin"] = "false";
                                return View();

                            }
                        }
                    }
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult email(string email)
        {
            Session["checkemailadmin"] = "true";
            NHANVIEN nHANVIEN = db.NHANVIENs.Where(n=>n.Email.Equals(email)).FirstOrDefault();
            NHANVIENQLBAIXE nHANVIENQLBAIXE = db.NHANVIENQLBAIXEs.Where(n => n.Email.Equals(email)).FirstOrDefault();
            TAIXE tAIXE = db.TAIXEs.Where(n => n.Email.Equals(email)).FirstOrDefault();
            if(nHANVIEN != null || nHANVIENQLBAIXE != null || tAIXE != null)
            {   
                Session.Remove("checkemailadmin");
                if (nHANVIEN != null)
                {
                    Session["table"] = "nv";
                    Session["IDdamintemp"] = nHANVIEN.MANV; return RedirectToAction("fotpass", "Loginadmin");
                }
                if(nHANVIENQLBAIXE != null)
                {
                    Session["table"] = "bx";
                    Session["IDdamintemp"] = nHANVIENQLBAIXE.MANVBAIXE; return RedirectToAction("fotpass", "Loginadmin");
                }
                if(tAIXE != null)
                {
                    Session["table"] = "tx";
                    Session["IDadmintemp"] = tAIXE.MATAIXE; return RedirectToAction("fotpass", "Loginadmin");
                }
            }
            else
            {
                Session["checkemailadmin"] = "false";
                return View();
            }
            return View();
        }
    }
}