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
    public class Customer_BUS
    {            
        SqlConnection conn = SqlConnectionData.Connect();

        CustomerAccess dalKH = new CustomerAccess();

        public DataTable getKH()
        {
            return dalKH.getKH();
        }

        public bool themThanhVien(Customer_DTO KH)
        {
            return dalKH.themKH(KH);
        }

        public bool suaKH(Customer_DTO KH)
        {
            return dalKH.suaKH(KH);
        }

        public bool xoaKH(int KH_ID)
        {
            return dalKH.xoaKH(KH_ID);
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

        public class BUS_ThanhVien
        {
        }

    }

}

