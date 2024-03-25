using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webthuexe.Models;

namespace Webthuexe.Areas.Admin.Controllers
{
    public class calendarController : Controller
    {      
        MyworldEntities myworldEntities = new MyworldEntities();
        show show  = new show();
        // GET: Admin/calendar
        public ActionResult calendar(string tang,string giam,string hientai,string dautien)
        {
            DateTime time = DateTime.Now.ToLocalTime();
            DateTime hour = new DateTime();
            var gio = hour;
            DateTime ngaydau = time.AddDays(-(int)time.DayOfWeek);
            if (hientai == null || hientai == "1")
            {   
                ngaydau = time.AddDays(-(int)time.DayOfWeek);
            }
            if(dautien != null)
            {
                string encodedString = dautien;

                // Giải mã chuỗi URL
                string decodedString = HttpUtility.UrlDecode(encodedString);
                if (tang == "1")
                {
                    DateTime dau = DateTime.ParseExact(decodedString, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    ngaydau = dau.AddDays(7);
                }
                if (giam == "1")
                {
                    DateTime dau = DateTime.ParseExact(decodedString, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    ngaydau = dau.AddDays(-7);
                }
            }
            show.hOADONTHUEXEs = myworldEntities.HOADONTHUEXEs.ToList();
            for(int i = 0; i < show.hOADONTHUEXEs.Count; i++)
            {

            }

            string[,] Kteam = new string[8, 25];
            ViewBag.ngaydau = ngaydau;
            return View(show);
        }
    }
}