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
    
    public partial class HOADONTHUEXE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADONTHUEXE()
        {
            this.CHITIETLICHCHAYs = new HashSet<CHITIETLICHCHAY>();
            this.PHIEUDENBUs = new HashSet<PHIEUDENBU>();
            this.PHIEUTHANHTOANs = new HashSet<PHIEUTHANHTOAN>();
        }
    
        public string BIENXE { get; set; }
        public Nullable<bool> THUCTHUCTHANHTOAN { get; set; }
        public Nullable<bool> COTAIXE { get; set; }
        public Nullable<int> CHIPHITHUE { get; set; }
        public Nullable<int> SONGAYTHUE { get; set; }
        public string MAHD { get; set; }
        public string MAKH { get; set; }
        public Nullable<System.DateTime> NGAYLAP { get; set; }
        public Nullable<int> TIENCOC { get; set; }
        public Nullable<bool> DADATCOC { get; set; }
        public string NOIDON { get; set; }
        public string GHICHU { get; set; }
        public string NOIDI { get; set; }
        public Nullable<System.DateTime> NGAYDI_NHAN { get; set; }
        public Nullable<System.DateTime> NGAYVE_TRA { get; set; }
        public Nullable<bool> GIAOXE { get; set; }
        public Nullable<bool> KHUHOI { get; set; }
    
        public virtual BIENXE BIENXE1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETLICHCHAY> CHITIETLICHCHAYs { get; set; }
        public virtual KHACHHANG KHACHHANG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUDENBU> PHIEUDENBUs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTHANHTOAN> PHIEUTHANHTOANs { get; set; }
    }
}