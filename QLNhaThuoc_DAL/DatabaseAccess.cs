using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNhaThuoc_DTO;
using System.Data;

namespace QLNhaThuoc_DAL
{
    public class SqlConnectionData
    {
        public static SqlConnection Connect()
        {
            string strconn = @"Data Source=DESKTOP-QQPQ8EC;Initial Catalog=QLNhaThuoc;Integrated Security=True";
            SqlConnection conn = new SqlConnection(strconn);
            return conn;
        }
    }
    public class DatabaseAccess
    {
        public static string CheckLogin_DTO(Login_DTO login)
        {
            string username = null;
            SqlConnection conn = SqlConnectionData.Connect();
            conn.Open();
            SqlCommand cmd = new SqlCommand("proc_login", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", login.username);
            cmd.Parameters.AddWithValue("@password", login.password);

            //Kiểm tra quyền thêm 1 para...
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader(); 
            if (reader.HasRows) 
            { 
                while(reader.Read())
                {
                    username = reader.GetString(0);
                    return username;
                }
                reader.Close();
                conn.Close();
            }
            else
            {
                return "Tài khoản hoặc mật khẩu không chính xác!";
            }    

            return username;
        }
    }
}
