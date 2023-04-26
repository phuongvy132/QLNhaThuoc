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

        public DataTable GetData()
        {
            return dalHD.GetData();
        }
        public bool AddData(HoaDon_DTO HD)
        {
            return dalHD.AddData(HD);
        }
        public bool DelData(string ma)
        {
            return dalHD.DelData(ma);
        }


    }
}
