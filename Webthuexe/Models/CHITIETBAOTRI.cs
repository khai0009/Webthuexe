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
    
    public partial class CHITIETBAOTRI
    {
        public string BIENXE { get; set; }
        public string MAPBT { get; set; }
        public Nullable<int> CHIPHI { get; set; }
        public Nullable<System.DateTime> NGAYTHANHTOAN { get; set; }
        public string NOIDUNGBAOTRI { get; set; }
    
        public virtual BIENXE BIENXE1 { get; set; }
        public virtual PHIEUBAOTRI PHIEUBAOTRI { get; set; }
    }
}
