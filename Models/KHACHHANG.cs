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
    
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            this.BAOHIEMs = new HashSet<BAOHIEM>();
            this.HOADONTHUEXEs = new HashSet<HOADONTHUEXE>();
        }
    
        public string MAKH { get; set; }
        public string TENDAYDU { get; set; }
        public string HO { get; set; }
        public string LOT { get; set; }
        public string TEN { get; set; }
        public Nullable<bool> GIOITINH { get; set; }
        public Nullable<int> TUOI { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> NGAYSINH { get; set; }
        public string SONHA { get; set; }
        public string CCCD { get; set; }
        public string ANHDAIDIEN { get; set; }
        public Nullable<bool> XACNHANCC { get; set; }
        public string BANGLAI { get; set; }
        public Nullable<bool> XACNHANBL { get; set; }
        public string DUONG { get; set; }
        public string ANHBL { get; set; }
        public string ANHCCCDTRUOC { get; set; }
        public string ANHCCCDSAU { get; set; }
        public string MATP { get; set; }
        public string MAXP { get; set; }
        public string MAQ { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAOHIEM> BAOHIEMs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADONTHUEXE> HOADONTHUEXEs { get; set; }
        public virtual QUAN_HUYEN QUAN_HUYEN { get; set; }
        public virtual THANHPHO_TINH THANHPHO_TINH { get; set; }
        public virtual PHUONG_XA PHUONG_XA { get; set; }
        public virtual TKKHACHHANG TKKHACHHANG { get; set; }
    }
}