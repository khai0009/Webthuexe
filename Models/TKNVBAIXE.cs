//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Webthuexe.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TKNVBAIXE
    {
        public string SDT { get; set; }
        public string MATKHAU { get; set; }
        public string MANVBAIXE { get; set; }
        public Nullable<bool> TRANGTHAI { get; set; }
        public Nullable<System.DateTime> TGDANGNHAP { get; set; }
        public Nullable<System.DateTime> NGAYTAO { get; set; }
    
        public virtual NHANVIENQLBAIXE NHANVIENQLBAIXE { get; set; }
    }
}
