using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNhaThuoc_DTO;
using QLNhaThuoc_DAL;

namespace QLNhaThuoc_BUS
{
    public class Login_BUS
    {
        LoginAccess loginBLL = new LoginAccess();
        public string CheckLogin (Login_DTO login)
        {
            //Kiểm tra nghiệp vụ
            if (login.username == "")
                return "Required_username";

            if (login.password == "")
                return "Required_password";

            string info = loginBLL.CheckLogin(login);
            return info;
        }
    }
}
