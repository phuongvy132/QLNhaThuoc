using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNhaThuoc_DTO;
using QLNhaThuoc_DAL;
using System.Data.SqlClient;
using System.Data;

namespace QLNhaThuoc_BUS
{
    public class HoaDon_BUS
    {
        SqlConnection conn = SqlConnectionData.Connect();

        HoaDon_DAL dalHD = new HoaDon_DAL();

        public void getHD()
        {
            dalHD.getHD();
        }

    }
}
