using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Webthuexe.Models;

namespace Webthuexe.Controllers
{
    public class RentController : Controller
    {
        // GET: Rent
        MyworldEntities db = new MyworldEntities();
        show show = new show();
        DateTime dt = new DateTime().ToLocalTime();
        public ActionResult Rent_car(string maxe, bool? tulai, string maxeoa, bool? cotaixe, string maxesua, bool? xoa)
        {   
            var chiphi = db.XEs.Where(n => n.TENXE == maxe).FirstOrDefault();
            string IDuser = Session["IDuser"].ToString();
            var hoadon = db.HOADONTHUEXEs.Where(n => n.MAKH == IDuser && n.DADATCOC == null).FirstOrDefault();
            HOADONTHUEXE hOADONTHUEXE = new HOADONTHUEXE();
            CHITIETTHUEXE cHITIETTHUEXE = new CHITIETTHUEXE();
            XE xE = new XE();
            if (maxe == null && hoadon==null)
            {
                Session["MAHD"] = null;
                return View();
            }
            if (maxe != null && hoadon == null)
            {
                
                hOADONTHUEXE.MAHD = dt.Day + dt.Month + dt.Year + dt.Hour + dt.Minute + Session["IDuser"].ToString();
                hOADONTHUEXE.MAKH = Session["IDuser"].ToString();
                hOADONTHUEXE.NGAYLAP = DateTime.Now;
                hOADONTHUEXE.TIENCOC = 15000000;
                if (ModelState.IsValid)
                {
                    db.HOADONTHUEXEs.Add(hOADONTHUEXE);
                    db.SaveChanges();
                }
            }
            hoadon = db.HOADONTHUEXEs.Where(n => n.MAKH == IDuser && n.DADATCOC == null).FirstOrDefault();
            if (hoadon != null)
            {
                Session["MAHD"] = hoadon.MAHD;

            }
            /*DateTime ngayChuyenDoi = DateTime.ParseExact(ns, "M/d/yyyy", CultureInfo.InvariantCulture);*/
            /*string ngayChuyenDoiSangDinhDangMoi = ngayChuyenDoi.ToString("yyyy/MM/dd");*/
            
            if (maxe != null)
            {   
                if(db.CHITIETTHUEXEs.Where(n => n.MAHD == hoadon.MAHD).Count() == 1)
                {
                    cHITIETTHUEXE = db.CHITIETTHUEXEs.Where(n => n.MAHD == hoadon.MAHD).SingleOrDefault();   
                    db.CHITIETTHUEXEs.Remove(cHITIETTHUEXE);
                    db.SaveChanges();
                }
                show.xes = db.XEs.Where(n => n.TENXE == maxe).ToList();
                var thuexe = show.xes.Where(n => n.MATT == "A").FirstOrDefault();
                cHITIETTHUEXE.MAHD = hoadon.MAHD;
                cHITIETTHUEXE.BIENXE = thuexe.BIENXE;
                cHITIETTHUEXE.CHIPHI = chiphi.GIATAIXE;
                cHITIETTHUEXE.COTAIXE = true;
                if (tulai == true)
                {   
                    cHITIETTHUEXE.COTAIXE = false;
                    cHITIETTHUEXE.CHIPHI = chiphi.GIATHUE;
                }
                if (ModelState.IsValid)
                {   
                    db.CHITIETTHUEXEs.Add(cHITIETTHUEXE);
                    db.SaveChanges();
                }

                else RedirectToAction("index", "Home");
            }
            

            
            if (xoa == true)
            {

                cHITIETTHUEXE = db.CHITIETTHUEXEs.Where(n => n.MAHD == hoadon.MAHD && n.BIENXE == maxeoa).SingleOrDefault();
                if (cHITIETTHUEXE != null)
                {
                    hOADONTHUEXE = db.HOADONTHUEXEs.Where(n => n.MAHD == hoadon.MAHD).SingleOrDefault();
                    db.HOADONTHUEXEs.Remove(hOADONTHUEXE);
                    db.SaveChanges();
                    db.CHITIETTHUEXEs.Remove(cHITIETTHUEXE);
                    db.SaveChanges();
                }
                Session["MAHD"] = null;
                return RedirectToAction("index", "Home");
            }
            show.hOADONTHUEXEs = db.HOADONTHUEXEs.Where(n => n.MAHD == hoadon.MAHD).ToList();
            show.cHITIETTHUEXEs = db.CHITIETTHUEXEs.Where(n => n.MAHD == hoadon.MAHD).ToList();
            show.xes = db.XEs.ToList();
            maxe = null;
            return View(show);
        }
        public ActionResult Bill(string noidon, string noidi, string ghichu, string ngaydi, string ngaytra, bool? datxe, string gio)
        {
            string makh = Session["IDuser"].ToString();
            string mahd = Session["MAHD"].ToString();
            if (datxe == true)
            {
                
                HOADONTHUEXE hOADONTHUEXE = db.HOADONTHUEXEs.Find(mahd); ;
                CHITIETTHUEXE cHITIETTHUEXE = db.CHITIETTHUEXEs.Find(mahd);
                if(cHITIETTHUEXE.COTAIXE == false)
                {
                    if(noidon == null && ngaydi == null && ngaytra == null) return RedirectToAction("Rent_car","Rent");
   
                } 
                else if (noidon == null && noidi == null && ngaydi == null && ngaytra == null) return RedirectToAction("Rent_car", "Rent");
                show.cHITIETTHUEXEs = db.CHITIETTHUEXEs.Where(n => n.MAHD == mahd).ToList();
                hOADONTHUEXE.GHICHU = ghichu;
                hOADONTHUEXE.NOIDI = noidi;
                hOADONTHUEXE.NOIDON = noidon;
                string thoigiandi = ngaydi +" "+ gio;
                DateTime ngayChuyenDoid1 = DateTime.ParseExact(thoigiandi, "M/d/yyyy h:mmtt", CultureInfo.InvariantCulture);
                string ngayChuyenDoiSangDinhDangMoi1 = ngayChuyenDoid1.ToString("yyyy/MM/dd HH:mm:ss");
                string thoigianve = ngaytra + " " + gio;
                DateTime ngayChuyenDoi = DateTime.ParseExact(thoigianve, "M/d/yyyy h:mmtt", CultureInfo.InvariantCulture);
                string ngayChuyenDoiSangDinhDangMoi = ngayChuyenDoi.ToString("yyyy/MM/dd HH:mm:ss");
                hOADONTHUEXE.NGAYDI_NHAN = ngayChuyenDoiSangDinhDangMoi1.AsDateTime();
                hOADONTHUEXE.NGAYVE_TRA = ngayChuyenDoiSangDinhDangMoi.AsDateTime();
                if (ModelState.IsValid)
                {
                    db.Entry(hOADONTHUEXE).State = EntityState.Modified;
                    db.SaveChanges();
                }
                int songaythue = (ngayChuyenDoi.Date - ngayChuyenDoid1.Date).Days;
                cHITIETTHUEXE = db.CHITIETTHUEXEs.Where(n => n.MAHD == mahd).SingleOrDefault();
                cHITIETTHUEXE.SONGAYTHUE = songaythue;
                if (ModelState.IsValid)
                {
                    db.Entry(cHITIETTHUEXE).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
           
            if(mahd != null)
            {   
                CHITIETTHUEXE cHITIETTHUEXE = new CHITIETTHUEXE();
                
                show.hOADONTHUEXEs = db.HOADONTHUEXEs.Where(n=>n.MAHD == mahd).ToList();
                show.cHITIETTHUEXEs = db.CHITIETTHUEXEs.Where(n=>n.MAHD.Equals(mahd)).ToList();
                cHITIETTHUEXE = show.cHITIETTHUEXEs.SingleOrDefault();
                KHACHHANG kHACHHANG = new KHACHHANG();
                show.kHACHHANGs = db.KHACHHANGs.Where(n=>n.MAKH == makh).ToList();
                kHACHHANG = show.kHACHHANGs.Where((n) => n.MAKH.Equals(makh)).SingleOrDefault();
                show.tTHANHPHO_TINHs = db.THANHPHO_TINH.Where(n=>n.MATP == kHACHHANG.MATP).ToList();
                show.qUAN_HUYENs = db.QUAN_HUYEN.Where(n => n.MAQ == kHACHHANG.MAQ).ToList();
                show.pHUONG_XAs = db.PHUONG_XA.Where(n => n.MAXP == kHACHHANG.MAXP).ToList();
                show.xes =  db.XEs.Where(n=>n.BIENXE == cHITIETTHUEXE.BIENXE).ToList();
                return View(show);
            }

            return View();
        }
    }

}