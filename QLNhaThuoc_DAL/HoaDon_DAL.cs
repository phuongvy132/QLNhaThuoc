using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNhaThuoc_DTO;
using System.Runtime.Remoting.Channels;
using System.Runtime;
using System.Net.Http.Headers;
using System.Diagnostics.Eventing.Reader;

namespace QLNhaThuoc_DAL
{
    public class HoaDon_DAL
    {
        SqlConnection conn = SqlConnectionData.Connect();
        SqlCommand cmd = new SqlCommand();

        public void getHD()
        {
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"SELECT TenThuoc 
	                            FROM Thuoc
                                ORDER BY TenThuoc ASC";
            cmd.ExecuteNonQuery();
            DataTable dtHD = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dtHD);
        }

        public bool themHD(HoaDon_DTO hd)
        {
            return false;
        }
    }
}
