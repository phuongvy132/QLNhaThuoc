//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLNhaThuoc_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            this.CTHDNhap = new HashSet<CTHDNhap>();
            this.CTHDXuat = new HashSet<CTHDXuat>();
        }
    
        public int MaHD { get; set; }
        public long MaThuoc { get; set; }
        public int MaNV { get; set; }
        public System.DateTime ThoiGian { get; set; }
        public decimal TongTienHD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHDNhap> CTHDNhap { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHDXuat> CTHDXuat { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
