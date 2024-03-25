using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webthuexe.Models
{
    public class show
    {
        MyworldEntities db = new MyworldEntities();
        public List<XE> xes { get; set; }
        public List<BIENXE> bien { get; set; }
        public List<HANGXE> hangxes { get; set; }
        public List<SOGHE> sOGHEs { get; set; }
        public List<TINHTRANG> tINHTRANGs { get; set; }
        public List<NHIENLIEU> nHIENLIEUs { get; set; }
        public List<KHACHHANG> kHACHHANGs { get; set; }
        public List<TKKHACHHANG> tKKHACHHANGs { get; set; }
        public List<TKTAIXE> TKTAIXEs { get; set; }
        public List<THANHPHO_TINH> tTHANHPHO_TINHs { get;set; }
        public List<QUAN_HUYEN> qUAN_HUYENs { get; set; }
        public List<PHUONG_XA> pHUONG_XAs { get; set; }
        public List<NHANVIEN> nHANVIENs { get; set; }
        public List<TKNV> tKNVs { get; set; }
        public List<TAIXE> tAIXEs { get; set; }
        public List<NHANVIENQLBAIXE> nHANVIENQLBAIXEs { get; set; }
        public List<TKNVBAIXE> tKNVBAIXEs { get; set; }
        public List<HOADONTHUEXE> hOADONTHUEXEs { get; set; }
        public List<BAOHIEM> bAOHIEMs { get; set; }
        public List<CHITIETLICHCHAY> cHITIETLICHCHAYs { get; set; }
    }
}