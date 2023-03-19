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

namespace QLNhaThuoc
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void QLNhaThuoc_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(50, 0, 0, 0);
            btnĐN.BackColor = Color.FromArgb(200, 0, 0, 0);
        }

        private void txtMK_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var tagAction = txtMK.Tag.ToString();
            if (tagAction == "hide")
            {
                txtMK.Properties.Buttons[0].ImageOptions.Image = imageCollection1.Images[1]; // image hide
                txtMK.Tag = "show";
                txtMK.Properties.UseSystemPasswordChar = false;
            }
            else
            {
                txtMK.Properties.Buttons[0].ImageOptions.Image = imageCollection1.Images[0]; // image show
                txtMK.Tag = "hide";
                txtMK.Properties.UseSystemPasswordChar = true;
            }
        }

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-QQPQ8EC;Initial Catalog=QLNhaThuoc;Integrated Security=True");
        private void btnĐN_Click_1(object sender, EventArgs e)
        {
            String username, user_password;

            username = txtMa.Text;
            user_password = txtMK.Text;

            try
            {
                String querry = "SELECT * FROM Login WHERE username = '" + txtMa.Text + "' AND password = '" + txtMK.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = txtMa.Text;
                    user_password = txtMK.Text;

                    //chuyển sang page tiếp theo
                    MenuForm form2 = new MenuForm();
                    form2.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid login details!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMa.Clear();
                    txtMK.Text = string.Empty;
                    txtMa.Focus();
                }

            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();
                //MenuForm frm = new MenuForm();
                //frm.Show();
                //this.Close();
            }
        }

        //Exit button
        private void exit()
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }

        }

        private void dangnhap_Click()
        {
            //if (txtMa.Text.Length == 0 && txtMK.Text.Length == 0)
            //    MessageBox.Show("Bạn chưa điền tài khoản!!!");
            //else if (this.txtMa.Text.Length == 0)
            //    MessageBox.Show("Bạn chưa điền vào ô Mã NV!!!");
            //else if (this.txtMK.Text.Length == 0)
            //    MessageBox.Show("Bạn chưa điền vào ô Mật Khẩu!!!");
            //else if (this)
        }

    }
}
