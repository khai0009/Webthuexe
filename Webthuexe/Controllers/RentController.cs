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
        
        public ActionResult Rent_car(string maxe, bool? tulai, string maxexoa,bool? khuhoi,string maxesua, bool? xoa)
        {
            DateTime dt = DateTime.Now;
            string IDuser = Session["IDuser"].ToString();
            var hoadon = db.HOADONTHUEXEs.Where(n => n.MAKH == IDuser && n.DADATCOC == null).FirstOrDefault();
            HOADONTHUEXE hOADONTHUEXE = new HOADONTHUEXE();
            if (xoa == true)
            {

                hOADONTHUEXE = db.HOADONTHUEXEs.Where(n => n.MAHD == hoadon.MAHD && n.BIENXE == maxexoa && n.DADATCOC == null).SingleOrDefault();
                db.HOADONTHUEXEs.Remove(hOADONTHUEXE);
                db.SaveChanges();
                Session["MAHD"] = null;
                return RedirectToAction("index", "Home");
            }
            if (maxe != null)
            {
                var chiphi = db.XEs.Where(n => n.MAXE == maxe).FirstOrDefault();
                
                XE xE = new XE();
                if (hoadon != null)
                {
                    hOADONTHUEXE = db.HOADONTHUEXEs.Find(hoadon.MAHD);
                    if (tulai == true)
                    {
                        hOADONTHUEXE.BIENXE = db.BIENXEs.Where(n => n.MATT == "A" && n.MAXE == maxe).SingleOrDefault().BIENXE1;
                        hOADONTHUEXE.CHIPHITHUE = chiphi.GIATHUE;
                        hOADONTHUEXE.COTAIXE = false;
                        hOADONTHUEXE.KHUHOI = false;
                    }
                    if (tulai == false)
                    {
                        hOADONTHUEXE.COTAIXE = true;
                        if (khuhoi == true)
                        {
                            hOADONTHUEXE.KHUHOI = true;
                            hOADONTHUEXE.CHIPHITHUE = chiphi.GIATAIXEKH;
                        }
                        else
                        {
                            hOADONTHUEXE.KHUHOI = false;
                            hOADONTHUEXE.CHIPHITHUE = chiphi.GIATAIXE;
                        }


                    }
                    if (ModelState.IsValid)
                    {
                        db.Entry(hOADONTHUEXE).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                    else RedirectToAction("Rent_car", "Rent");
                }

                if (hoadon == null)
                {
                    var bienxe = db.BIENXEs.Where(n => n.MAXE == maxe && n.MATT == "A").FirstOrDefault();
                    var gia = db.XEs.Where(n => n.MAXE == bienxe.MAXE).FirstOrDefault();
                    hOADONTHUEXE.MAHD = dt.Day + dt.Month + dt.Year + dt.Hour + dt.Minute + IDuser;
                    hOADONTHUEXE.MAKH = IDuser;
                    hOADONTHUEXE.BIENXE = bienxe.BIENXE1;
                    hOADONTHUEXE.NGAYLAP = DateTime.Now;
                    hOADONTHUEXE.TIENCOC = 15000000;
               
                    if (tulai == true)
                    {
                        
                        hOADONTHUEXE.COTAIXE = false;
                        hOADONTHUEXE.KHUHOI = false;
                        hOADONTHUEXE.CHIPHITHUE = chiphi.GIATHUE;
                    }
                    if (tulai == false)
                    {
                        hOADONTHUEXE.COTAIXE = true;
                        if (khuhoi == true)
                        {
                            hOADONTHUEXE.KHUHOI = true;
                            hOADONTHUEXE.CHIPHITHUE = chiphi.GIATAIXEKH;
                        }
                        else
                        {
                            hOADONTHUEXE.KHUHOI = false;
                            hOADONTHUEXE.CHIPHITHUE = chiphi.GIATAIXE;
                        }
                        if (ModelState.IsValid)
                        {
                            db.HOADONTHUEXEs.Add(hOADONTHUEXE);
                            db.SaveChanges();
                        }

                    }
                   
                }
                hoadon = db.HOADONTHUEXEs.Where(n => n.MAKH == IDuser && n.DADATCOC == null).FirstOrDefault();
                if (hoadon != null)
                {
                    Session["MAHD"] = hoadon.MAHD;

                }
                /*DateTime ngayChuyenDoi = DateTime.ParseExact(ns, "M/d/yyyy", CultureInfo.InvariantCulture);*/
                /*string ngayChuyenDoiSangDinhDangMoi = ngayChuyenDoi.ToString("yyyy/MM/dd");*/
                show.hOADONTHUEXEs = db.HOADONTHUEXEs.Where(n => n.MAHD == hoadon.MAHD).ToList();
                show.bien = db.BIENXEs.ToList();
                show.xes = db.XEs.ToList();
                return View(show);






            }
            else
            {

                if (hoadon == null)
                {
                    Session["MAHD"] = null;
                }
                else
                {
                    Session["MAHD"] = hoadon.MAHD;
                    show.hOADONTHUEXEs = db.HOADONTHUEXEs.Where(n => n.MAHD == hoadon.MAHD).ToList();
                    show.bien = db.BIENXEs.ToList();
                    show.xes = db.XEs.ToList();
                    return View(show);
                }
            }
            
            return View();
        }
        public ActionResult Bill(string noidon, string noidi, string ghichu, string ngaydi, string ngaytra, bool? datxe, string gio,string radiogroup)
        {
            string makh = Session["IDuser"].ToString();
            string mahd = Session["MAHD"].ToString();
            HOADONTHUEXE hOADONTHUEXE = db.HOADONTHUEXEs.Where(n => n.MAHD == mahd && n.DADATCOC == null).SingleOrDefault();
            show.hOADONTHUEXEs = db.HOADONTHUEXEs.Where(n => n.MAHD == mahd).ToList();
            if (datxe == true)
            {
                
                hOADONTHUEXE = db.HOADONTHUEXEs.Find(mahd); ;

                if(hOADONTHUEXE.COTAIXE == false)
                {
                    if(noidon == null && ngaydi == null && ngaytra == null) return RedirectToAction("Rent_car","Rent");
   
                } 
                else 
                if (noidon == null && noidi == null && ngaydi == null && ngaytra == null) return RedirectToAction("Rent_car", "Rent");
                
                hOADONTHUEXE.GHICHU = ghichu;
                hOADONTHUEXE.NOIDI = noidi;
                hOADONTHUEXE.NOIDON = noidon;
                string thoigiandi = ngaydi +" "+ gio;
                DateTime ngayChuyenDoid1 = DateTime.ParseExact(thoigiandi, "M/d/yyyy h:mmtt", CultureInfo.InvariantCulture);
                string ngayChuyenDoiSangDinhDangMoi1 = ngayChuyenDoid1.ToString("yyyy/MM/dd HH:mm:ss");
                if (ngaytra != null)
                {
                    string thoigianve = ngaytra + " " + gio;
                    DateTime ngayChuyenDoi = DateTime.ParseExact(thoigianve, "M/d/yyyy h:mmtt", CultureInfo.InvariantCulture);
                    string ngayChuyenDoiSangDinhDangMoi = ngayChuyenDoi.ToString("yyyy/MM/dd HH:mm:ss");
                    hOADONTHUEXE.NGAYDI_NHAN = ngayChuyenDoiSangDinhDangMoi1.AsDateTime();
                    hOADONTHUEXE.NGAYVE_TRA = ngayChuyenDoiSangDinhDangMoi.AsDateTime();
                    int songaythue = (ngayChuyenDoi.Date - ngayChuyenDoid1.Date).Days;
                    int chiphi = (int)hOADONTHUEXE.CHIPHITHUE;
                    hOADONTHUEXE = db.HOADONTHUEXEs.Where(n => n.MAHD == mahd).SingleOrDefault();
                    hOADONTHUEXE.SONGAYTHUE = songaythue;
                    hOADONTHUEXE.CHIPHITHUE = songaythue * chiphi;
                }
                else
                {
                    DateTime ngayChuyenDoid = ngaydi.AsDateTime();
                    hOADONTHUEXE.NGAYDI_NHAN = ngayChuyenDoiSangDinhDangMoi1.AsDateTime();
                    hOADONTHUEXE.NGAYVE_TRA = ngayChuyenDoid.AddDays(1);
                    hOADONTHUEXE.SONGAYTHUE = 1;

                }
                
                if (ModelState.IsValid)
                {
                    db.Entry(hOADONTHUEXE).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            
            if (mahd != null)
            {   
                
                
                hOADONTHUEXE = db.HOADONTHUEXEs.Where(n => n.MAHD == mahd).SingleOrDefault();
                show.kHACHHANGs = db.KHACHHANGs.Where(n=>n.MAKH == makh).ToList();
                KHACHHANG kHACHHANG = show.kHACHHANGs.Where((n) => n.MAKH.Equals(makh)).SingleOrDefault();
                show.tTHANHPHO_TINHs = db.THANHPHO_TINH.Where(n=>n.MATP == kHACHHANG.MATP).ToList();
                show.qUAN_HUYENs = db.QUAN_HUYEN.Where(n => n.MAQ == kHACHHANG.MAQ).ToList();
                show.pHUONG_XAs = db.PHUONG_XA.Where(n => n.MAXP == kHACHHANG.MAXP).ToList();
                show.bien =  db.BIENXEs.Where(n=>n.BIENXE1 == hOADONTHUEXE.BIENXE).ToList();
                var maxe = db.BIENXEs.Where(n => n.BIENXE1 == hOADONTHUEXE.BIENXE).SingleOrDefault();
                show.xes = db.XEs.Where(n => n.MAXE == maxe.MAXE).ToList();
                if (radiogroup != null)
                {
                    if (radiogroup == "true")
                    {
                        hOADONTHUEXE.THUCTHUCTHANHTOAN = true;
                        db.Entry(hOADONTHUEXE).State = EntityState.Modified;
                        db.SaveChanges();
                        return View(show);
                    }
                    else
                    {
                        hOADONTHUEXE.THUCTHUCTHANHTOAN = false;
                        db.Entry(hOADONTHUEXE).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("index", "Home");
                    }

                }
                return View(show);
            }
            
            return View(show);
        }
    }

}