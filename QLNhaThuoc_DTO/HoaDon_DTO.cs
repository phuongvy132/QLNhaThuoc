using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaThuoc_DTO
{
    public class HoaDon_DTO
    {
        string mathuoc, mahd, thoigian, gia, tongtienhd, tenthuoc, thanhtien;

        public string TenThuoc { get => tenthuoc; set => tenthuoc = value; }
        public string MaThuoc { get => mathuoc; set => mathuoc = value; }
        public string ThoiGian { get => thoigian; set => thoigian = value; }
        public string Gia { get => gia; set => gia = value; }
        public string TongTienHD { get => tongtienhd; set => tongtienhd = value; }
        public string MaHD { get => mahd; set => mahd = value; }
        public string ThanhTien { get => thanhtien; set => thanhtien = value; }

        public HoaDon_DTO() { }

        public HoaDon_DTO(string mathuoc, string tenthuoc, string manhom, string thoigian, string gia, string tongtienhd, string thanhtien)
        {
            this.mathuoc = mathuoc;
            this.thoigian = thoigian;
            this.mahd = manhom;
            this.gia = gia;
            this.tongtienhd = tongtienhd;
            this.tenthuoc = tenthuoc;
            this.thanhtien = thanhtien;
        }

    }
}
