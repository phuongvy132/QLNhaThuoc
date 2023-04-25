using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaThuoc_DTO
{

    public class DuocPham_DTO
    {
        string mathuoc, tenthuoc, manhom, soluong, giaban, hsd;

        public string MaThuoc { get => mathuoc; set => mathuoc = value; }
        public string TenThuoc { get => tenthuoc; set => tenthuoc = value; }
        public string SoLuong { get => soluong; set => soluong = value; }
        public string GiaBan { get => giaban; set => giaban = value; }
        public string HSD { get => hsd; set => hsd = value; }
        public string MaNhom { get => manhom; set => manhom = value; }

        public DuocPham_DTO() { }

        public DuocPham_DTO(string mathuoc, string tenthuoc, string manhom, string soluong, string giaban, string hsd)
        {
            this.mathuoc = mathuoc;
            this.tenthuoc = tenthuoc;
            this.soluong = soluong;
            this.manhom = manhom;
            this.giaban = giaban;
            this.hsd = hsd; 
        }
    }
}
