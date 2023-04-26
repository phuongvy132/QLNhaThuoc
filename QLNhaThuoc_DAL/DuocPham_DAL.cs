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
    public class DuocPham_DAL : DatabaseAccess
    {

        SqlConnection conn = SqlConnectionData.Connect();
        QLNTEntities db = new QLNTEntities();
        SqlCommand cmd = new SqlCommand();


        public DataTable getDP()
        {
            SqlDataAdapter da = new SqlDataAdapter(@"SELECT MaThuoc, TenThuoc, GiaBan, HSD, SoLuong, MaNhom = case(MaNhom) 
	                                                    when 'DD' then N'Dạ dày' 
	                                                    when 'HO' then N'Ho và Long đờm'
                                                        when 'KHGH2' then N'Kháng H2'
                                                        when 'KHGVI' then N'Kháng Virus'
                                                        when 'SOT' then N'Giảm đau hạ sốt'
	                                                    end
                                                     FROM Thuoc", conn);
            DataTable dtDP = new DataTable();
            da.Fill(dtDP);
            return dtDP;
        }
        public DataTable getDP(string dieukien)
        {

            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(@"select * from Thuoc " + dieukien, conn);

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

        public bool themDP(DuocPham_DTO DP)
        {
            string SQL = string.Format(@"Insert into Thuoc (MaThuoc, TenThuoc, GiaBan, SoLuong, HSD) 
                                                    values 
                                                   (N'" + DP.MaThuoc +
                                                   "',N'" + DP.TenThuoc +
                                                   "',N'" + DP.GiaBan +
                                                   "',N'" + DP.SoLuong +
                                                   "',CONVERT(DATE,'" + DP.HSD + "',103))");
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

        public bool suaDP(DuocPham_DTO DP)
        {

            try
            {
                // Ket noi
                conn.Open();

                // Query string
                string SQL = string.Format("UPDATE Thuoc SET TenThuoc = '{0}', MaNhom = '{2}', SoLuong = '{3}', HSD = '{4}', GiaBan = '{5}' WHERE MaThuoc = {1}", DP.TenThuoc, DP.MaThuoc, DP.MaNhom, DP.SoLuong, DP.HSD, DP.GiaBan);

                // Command (mặc định command type = text nên chúng ta DPỏi fải làm gì nhiều).
                SqlCommand cmd = new SqlCommand(SQL, conn);

                // Query và kiểm tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                conn.Close();

            }
            finally
            {
                // Dong ket noi
                conn.Close();
            }
            return false;
        }

        public bool xoaDP(int MaThuoc)
        {
            try
            {
                // Ket noi
                conn.Open();

                // Query string - vì xóa chỉ cần ID nên chúng ta ko cần 1 DTO, ID là đủ
                string SQL = string.Format("DELETE FROM Thuoc WHERE MaThuoc = {0})", MaThuoc);

                // Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                SqlCommand cmd = new SqlCommand(SQL, conn);

                // Query và kiểm tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                conn.Close();
            }
            finally
            {
                // Dong ket noi
                conn.Close();
            }

            return false;
        }

    }
}
