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
    
    public partial class TAIXE
    {
        public string MATAIXE { get; set; }
        public string TENDAYDU { get; set; }
        public string HO { get; set; }
        public string LOT { get; set; }
        public string TEN { get; set; }
        public Nullable<bool> GIOTINH { get; set; }
        public Nullable<int> TUOI { get; set; }
        public Nullable<System.DateTime> NGAYSINH { get; set; }
        public string SONHA { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string BANGLAI { get; set; }
        public string CCCD { get; set; }
        public string ANHDAIDIEN { get; set; }
        public Nullable<bool> XACTHUCCC { get; set; }
        public Nullable<bool> XACTHUCBL { get; set; }
        public string DUONG { get; set; }
        public string MATP { get; set; }
        public string MAXP { get; set; }
        public string MAQ { get; set; }
    
        public virtual PHUONG_XA PHUONG_XA { get; set; }
        public virtual QUAN_HUYEN QUAN_HUYEN { get; set; }
        public virtual THANHPHO_TINH THANHPHO_TINH { get; set; }
        public virtual TKTAIXE TKTAIXE { get; set; }
    }
}