using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QLNhaThuoc_DTO;
using QLNhaThuoc_BUS;
using ComponentFactory.Krypton.Toolkit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLNhaThuoc
{
    public partial class QLNhaThuoc : KryptonForm
    {
        Login_DTO login = new Login_DTO();
        Login_BUS loginBUS = new Login_BUS();

        public QLNhaThuoc()
        {
            InitializeComponent();
        }

        private void QLNhaThuoc_Load(object sender, EventArgs e)
        {
            CBShowHide.Checked = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login.username = txtUsername.Text;
            login.password = txtPass.Text;

            string getuser = loginBUS.CheckLogin(login);

            //Trả kết quả nếu nghiệp vụ không đúng
            switch (getuser)
            {
                case "Required_username":
                    MessageBox.Show("Cần điền username!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                case "Required_password":
                    MessageBox.Show("Cần điền password!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                case "Tài khoản hoặc mật khẩu không chính xác!":
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Text = "Username";
                    txtPass.Text = "Password";
                    txtUsername.Focus();
                    return;
            }
            MessageBox.Show("Đăng nhập thành công!", "Thành công!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MenuForm form2 = new MenuForm();
            form2.ShowDialog();
            this.Close();
        }

        #region PlaceHolder
        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Clear();
                txtUsername.ForeColor = Color.Black;
            }
        }
        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "") 
            txtUsername.Text = "Username";
        }
        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Password")
                txtPass.Clear();
        }
        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")  // here you can also use txtSearch.Text != "Poduct Name", but it could affect your search code possibly 
                txtPass.Text = "Password";
        }

        #endregion


        private void CBShowHide_CheckedChanged(object sender, EventArgs e)
        {
            if (CBShowHide.Checked)
            {
                txtPass.UseSystemPasswordChar = true;
                var checkBox = (CheckBox)sender;
                checkBox.Text = "Show Password";
            }
            else
            {
                txtPass.UseSystemPasswordChar = false;
                var checkBox = (CheckBox)sender;
                checkBox.Text = "Hide Password";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtPass.Text = "Password";
            txtUsername.Text = "Username";
        }

    }
}
