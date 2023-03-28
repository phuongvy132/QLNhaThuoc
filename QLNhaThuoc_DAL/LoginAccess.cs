using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNhaThuoc_DTO;

namespace QLNhaThuoc_DAL
{
    public class LoginAccess : DatabaseAccess
    {
        public string CheckLogin(Login_DTO login)
        {
            string info = CheckLogin_DTO(login);
            return info;
        }
    }
}
