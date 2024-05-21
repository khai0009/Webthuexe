using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Webthuexe.Models;
namespace Webthuexe.Controllers
{
    
    public class HomeController : Controller
    {   show database = new show();
        MyworldEntities db = new MyworldEntities();
        public ActionResult index(int? c_trang,bool? dx,int? makh,string timkiem)
        {   
            database.hangxes = db.HANGXEs.ToList();
            database.sOGHEs = db.SOGHEs.ToList();
            database.nHIENLIEUs = db.NHIENLIEUx.ToList();
            int so_luong_hien_thi = 8;
            database.xes = db.XEs.ToList();
            int tongxe = database.xes.Count();
            int ctrang = tongxe / so_luong_hien_thi;
            Session["sotrang"] = ctrang;
            if (c_trang == null || c_trang == 1)
                database.xes = db.XEs.ToList().GetRange(0, so_luong_hien_thi-1);
            else
            {
                int c_trang_1 = int.Parse(c_trang.ToString());
                database.xes = db.XEs.ToList().GetRange(so_luong_hien_thi * (c_trang_1 - 1), so_luong_hien_thi);
            }
            database.tINHTRANGs = db.TINHTRANGs.ToList();
            if(dx == false)
            {   
                string kh = Session["IDuser"].ToString();
                var hoadon = db.HOADONTHUEXEs.Where(n => n.MAKH == kh && n.DADATCOC == null).FirstOrDefault();
                if (hoadon != null) 
                {
                    CHITIETTHUEXE cHITIETTHUEXE = new CHITIETTHUEXE();
                    HOADONTHUEXE hOADONTHUEXE = new HOADONTHUEXE();
                    TKKHACHHANG tKKHACHHANG = new TKKHACHHANG();
                    XE xE = new XE();
                    database.cHITIETTHUEXEs = db.CHITIETTHUEXEs.Where(n => n.MAHD == hoadon.MAHD).ToList();
                    for (int i = 0; i < database.cHITIETTHUEXEs.Count; i++)
                    {
                        CHITIETTHUEXE obj = database.cHITIETTHUEXEs[i];
                        xE = db.XEs.Find(obj.BIENXE);
                        xE.MATT = "A";
                        db.Entry(xE).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                    cHITIETTHUEXE = db.CHITIETTHUEXEs.Where(n=>n.MAHD == hoadon.MAHD).SingleOrDefault();
             
                    hOADONTHUEXE = db.HOADONTHUEXEs.Where(n => n.MAHD == hoadon.MAHD).SingleOrDefault();
                    tKKHACHHANG = db.TKKHACHHANGs.Where(n => n.MAKH == kh).SingleOrDefault();
                    tKKHACHHANG.TRANGTHAI = false;
                    db.Entry(tKKHACHHANG).State = EntityState.Modified;
                    db.SaveChanges();
                    db.CHITIETTHUEXEs.Remove(cHITIETTHUEXE);
                    db.SaveChanges();
                    db.HOADONTHUEXEs.Remove(hOADONTHUEXE);
                    db.SaveChanges();
                    Session.Remove("MAHD");

                    
                }                Session.Remove("IDuser");
                Session.Remove("Username");
                
            }
            if (!string.IsNullOrEmpty(timkiem))
            {
                database.xes = db.XEs.Where(n => n.TENXE.Contains(timkiem)).ToList();
                tongxe = database.xes.Count();
                ctrang = tongxe / so_luong_hien_thi;
                Session["sotrang"] = ctrang;
                if (so_luong_hien_thi > tongxe)
                {
                    database.xes = db.XEs.Where(n => n.TENXE.Contains(timkiem)).ToList();
                }
                else if (c_trang == null || c_trang == 1)
                    database.xes = db.XEs.Where(n => n.TENXE.Contains(timkiem)).ToList().GetRange(0, so_luong_hien_thi - 1);
                else
                {
                    int c_trang_1 = int.Parse(c_trang.ToString());
                    database.xes = db.XEs.Where(n => n.TENXE.Contains(timkiem)).ToList().GetRange(so_luong_hien_thi * (c_trang_1 - 1), so_luong_hien_thi);
                }
                
            }
            return View(database);
        }
        public ActionResult Detail(string Maxe)
        {
            if (Maxe != null)
                database.xes = db.XEs.Where(n=>n.BIENXE == Maxe).ToList();
                database.sOGHEs = db.SOGHEs.ToList();
                database.nHIENLIEUs = db.NHIENLIEUx.ToList();
                database.tINHTRANGs = db.TINHTRANGs.ToList();
            return View(database);
        }
        public ActionResult about()
        {
            

            return View();
        }

    }
}