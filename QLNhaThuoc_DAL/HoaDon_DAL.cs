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

        public DataTable GetData()
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
            foreach (DataRow dr in dtHD.Rows)
            {
                //hd.TenThuoc.Add(dr["TenThuoc"].ToString());
            }
            da.Fill(dtHD);
            return dtHD;
        }

        public bool AddData(HoaDon_DTO HD)
        {
            string SQL = string.Format("insert into HoaDon (MaHD, ThoiGian, TenThuoc, TongTienHD, ThanhTien) values ('" + HD.MaHD + "', CONVERT (datetime,'" + HD.ThoiGian + "',103),'" + HD.TenThuoc + "','" + HD.TongTienHD + "','" + HD.ThanhTien + "')");
            try
            {
                //if (txtSĐT.Text == "")
                //    throw new Exception("Cần điền số điện thoại!");
                conn.Open();

                // Query và kiểm tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                conn.Close();
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                conn.Close();
            }
            finally
            {
                conn.Close();
            }

            return false;
        }

        public bool DelData(string ma)
        {
            string SQL = string.Format( "Delete HoaDon Where MaHD = '" + ma + "'");
            try
            {
                conn.Open();

                // Query và kiểm tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                conn.Close();
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                conn.Close();
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

    }
}
