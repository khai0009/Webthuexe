﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MyworldEntities : DbContext
    {
        public MyworldEntities()
            : base("name=MyworldEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BAOHIEM> BAOHIEMs { get; set; }
        public virtual DbSet<BIENXE> BIENXEs { get; set; }
        public virtual DbSet<CHITIETBAOTRI> CHITIETBAOTRIs { get; set; }
        public virtual DbSet<CHITIETLICHCHAY> CHITIETLICHCHAYs { get; set; }
        public virtual DbSet<CHUCVU> CHUCVUs { get; set; }
        public virtual DbSet<HANGXE> HANGXEs { get; set; }
        public virtual DbSet<HOADONTHUEXE> HOADONTHUEXEs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<NHANVIENQLBAIXE> NHANVIENQLBAIXEs { get; set; }
        public virtual DbSet<NHIENLIEU> NHIENLIEUx { get; set; }
        public virtual DbSet<PHIEUBAOTRI> PHIEUBAOTRIs { get; set; }
        public virtual DbSet<PHIEUDENBU> PHIEUDENBUs { get; set; }
        public virtual DbSet<PHIEUTHANHTOAN> PHIEUTHANHTOANs { get; set; }
        public virtual DbSet<PHUONG_XA> PHUONG_XA { get; set; }
        public virtual DbSet<QUAN_HUYEN> QUAN_HUYEN { get; set; }
        public virtual DbSet<SOGHE> SOGHEs { get; set; }
        public virtual DbSet<TAIXE> TAIXEs { get; set; }
        public virtual DbSet<THANHPHO_TINH> THANHPHO_TINH { get; set; }
        public virtual DbSet<TINHTRANG> TINHTRANGs { get; set; }
        public virtual DbSet<TKKHACHHANG> TKKHACHHANGs { get; set; }
        public virtual DbSet<TKNV> TKNVs { get; set; }
        public virtual DbSet<TKNVBAIXE> TKNVBAIXEs { get; set; }
        public virtual DbSet<TKTAIXE> TKTAIXEs { get; set; }
        public virtual DbSet<XE> XEs { get; set; }
    }
}