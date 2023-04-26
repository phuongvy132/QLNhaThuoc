using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNhaThuoc_DTO;

namespace QLNhaThuoc_DAL
{
    public class CTHD_DAL
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = SqlConnectionData.Connect();

        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(@"select hd.MaHD, hd.TenThuoc, ThanhTien, ThoiGian from CTDHXuat cthd, HoaDonhd ", conn);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                conn.Close();
            }
            return dt;
        }

        //public bool AddData(HoaDon_DTO HD)
        //{
        //    cmd.CommandText = "insert into tb_HoaDon values ('" + hdObj.MaHoaDon + "', CONVERT (datetime,'" + hdObj.NgayLap + "',103),'" + hdObj.NguoiLap + "','" + hdObj.KhachHang + "')";
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = con.Connection;
        //    try
        //    {
        //        con.OpenConn();
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        string mex = ex.Message;
        //        cmd.Dispose();
        //        con.CloseConn();
        //    }
        //    return false;
        //}

        //public bool DelData(string ma)
        //{
        //    cmd.CommandText = "Delete tb_HoaDon Where MaHD = '" + ma + "'";
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = con.Connection;
        //    try
        //    {
        //        con.OpenConn();
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        string mex = ex.Message;
        //        cmd.Dispose();
        //        con.CloseConn();
        //    }
        //    return false;
        //}

    }
}
