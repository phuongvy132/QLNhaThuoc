using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNhaThuoc_DTO;
using QLNhaThuoc_DAL;


namespace QLNhaThuoc_BUS
{
    public class DuocPham_BUS
    {
        SqlConnection conn = SqlConnectionData.Connect();

        DuocPham_DAL dalDP = new DuocPham_DAL();

        public DataTable getDP()
        {
            return dalDP.getDP();
        }

        public bool themDP(DuocPham_DTO DP)
        {
            return dalDP.themDP(DP);
        }

        public bool suaDP(DuocPham_DTO DP)
        {
            return dalDP.suaDP(DP);
        }

        public bool xoaDP(int DP_ID)
        {
            return dalDP.xoaDP(DP_ID);
        }

        public DataSet _load_data(string strLenh)
        {

            DataSet ds = new DataSet();
            conn.Open();
            string d = "set dateformat dmy";
            SqlCommand cmd1 = new SqlCommand(d, conn);
            cmd1.ExecuteNonQuery();

            SqlDataAdapter cmd = new SqlDataAdapter(strLenh, conn);
            cmd.Fill(ds);
            conn.Close();
            return ds;
        }



        // Hàm thực thi các lệnh insert,delete,update trong SQL
        public void _Update(string strLenh)
        {
            conn.Open();
            string d = "set dateformat dmy";
            SqlCommand cmd1 = new SqlCommand(d, conn);
            cmd1.ExecuteNonQuery();

            SqlCommand cmd = new SqlCommand(strLenh, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }


    }

}

