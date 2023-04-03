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
    public class CustomerAccess : DatabaseAccess
    {

        SqlConnection conn = SqlConnectionData.Connect();

        public DataTable getKH()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM KhachHang", conn);
            DataTable dtKH = new DataTable();
            da.Fill(dtKH);
            return dtKH;
        }

        public bool themKH(Customer_DTO KH)
        {
            try
            {
                // Ket noi
                conn.Open();

                // Query string - vì mình để TV_ID là identity (giá trị tự tăng dần) nên ko cần fải insert ID
                string SQL = string.Format("INSERT INTO KhachHang(TenKH, SĐT, DiemTichLuy) VALUES ('{0}', '{1}', '{2}')", KH.TenKH, KH.SĐT, KH.DiemTichLuy);

                // Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                SqlCommand cmd = new SqlCommand(SQL, conn);

                // Query và kiểm tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch (Exception e)
            {

            }
            finally
            {
                // Dong ket noi
                conn.Close();
            }

            return false;
        }

        public bool suaKH(Customer_DTO KH)
        {

            try
            {
                // Ket noi
                conn.Open();

                // Query string
                string SQL = string.Format("UPDATE KhachHang SET TenKH = '{0}', SĐT = '{1}', DiemTichLuy = '{2}' WHERE MaKH = {3}", KH.TenKH, KH.SĐT, KH.DiemTichLuy, KH.MaKH);

                // Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                SqlCommand cmd = new SqlCommand(SQL, conn);

                // Query và kiểm tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch (Exception e)
            {

            }
            finally
            {
                // Dong ket noi
                conn.Close();
            }
            return false;
        }

        public bool xoaKH(int MaKH)
        {
            try
            {
                // Ket noi
                conn.Open();

                // Query string - vì xóa chỉ cần ID nên chúng ta ko cần 1 DTO, ID là đủ
                string SQL = string.Format("DELETE FROM KhachHang WHERE MaKH = {0})", MaKH);

                // Command (mặc định command type = text nên chúng ta khỏi fải làm gì nhiều).
                SqlCommand cmd = new SqlCommand(SQL, conn);

                // Query và kiểm tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch (Exception e)
            {

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
