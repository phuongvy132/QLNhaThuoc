using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaThuoc_DTO
{
    public class CTHD_DTO
    {
        string maxuat, mathuoc, mahd, soluong, thanhtien, thoigian;

        public string MaXuat { get => maxuat; set => maxuat = value; }
        public string MaThuoc { get => mathuoc; set => mathuoc = value; }
        public string MaHD { get => mahd; set => mahd = value; }
        public string SoLuong { get => soluong; set => soluong = value; }
        public string ThanhTien { get => thanhtien; set => thanhtien = value; }
        public string ThoiGian { get => thoigian; set => thoigian = value; }

        public CTHD_DTO() { }

        public CTHD_DTO(string mathuoc, string maxuat, string mahd, string soluong, string thanhtien, string thoigian)
        {
            this.mathuoc = mathuoc;
            this.mahd = mahd;
            this.soluong = soluong;
            this.maxuat = maxuat;
            this.thanhtien = thanhtien;
            this.thoigian = thoigian;
        }

    }
}
