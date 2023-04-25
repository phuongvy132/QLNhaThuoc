using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaThuoc_DTO
{
    public class Login_DTO
    {
        public string username { get; set; }
        public string password { get; set; }

        public Login_DTO() { }

        public Login_DTO(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

    }

}
