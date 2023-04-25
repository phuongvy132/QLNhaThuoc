using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;


namespace QLNhaThuoc
{
    public partial class MenuForm : KryptonForm
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
     (
          int nLeftRect,
          int nTopRect,
          int nRightRect,
          int nBottomRect,
          int nWidthEllipse,
         int nHeightEllipse

      );

        public MenuForm()
        {
            InitializeComponent();
            pnlNav.Height = btnTChu.Height;
            pnlNav.Top = btnTChu.Top;
            pnlNav.Left = btnTChu.Left;
            btnTChu.BackColor = Color.FromArgb(46, 77, 167);
        }


        private void btnKH_Click(object sender, EventArgs e)
        {
            //chuyển sang page tiếp theo
            DuocPham form = new DuocPham();
            form.ShowDialog();
            this.Hide();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region pnlNav
        public void btnTChu_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;   
            pnlNav.Height = btnTChu.Height;
            pnlNav.Top = btnTChu.Top;
            pnlNav.Left = btnTChu.Left;
            btnTChu.BackColor = Color.FromArgb(46, 77, 167);
        }
        private void btnKH_Click_1(object sender, EventArgs e)
        {
            DuocPham customer = new DuocPham();
            customer.TopLevel = false;
            pnlFormLoader.Controls.Add(customer);
            customer.BringToFront();
            customer.Show();

            pnlNav.Height = btnKH.Height;
            pnlNav.Top = btnKH.Top;
            pnlNav.Left = btnKH.Left;
            btnKH.BackColor = Color.FromArgb(46, 77, 167);
        }
        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnNhapHang.Height;
            pnlNav.Top = btnNhapHang.Top;
            pnlNav.Left = btnNhapHang.Left;
            btnNhapHang.BackColor = Color.FromArgb(46, 77, 167);
        }
        private void btnDuocPham_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDuocPham.Height;
            pnlNav.Top = btnDuocPham.Top;
            pnlNav.Left = btnDuocPham.Left;
            btnDuocPham.BackColor = Color.FromArgb(46, 77, 167);
        }
        private void btnKetCa_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnKetCa.Height;
            pnlNav.Top = btnKetCa.Top;
            pnlNav.Left = btnKetCa.Left;
            btnKetCa.BackColor = Color.FromArgb(46, 77, 167);
        }
        private void btnTChu_Leave(object sender, EventArgs e)
        {
            btnTChu.BackColor = Color.FromArgb(3, 37, 126);
        }
        private void btnKH_Leave(object sender, EventArgs e)
        {
            btnKH.BackColor = Color.FromArgb(3, 37, 126);
        }
        private void btnDuocPham_Leave(object sender, EventArgs e)
        {
            btnDuocPham.BackColor = Color.FromArgb(3, 37, 126);
        }
        private void btnNhapHang_Leave(object sender, EventArgs e)
        {
            btnNhapHang.BackColor = Color.FromArgb(3, 37, 126);
        }
        private void btnKetCa_Leave(object sender, EventArgs e)
        {
            btnKetCa.BackColor = Color.FromArgb(3, 37, 126);
        }
        #endregion

    }
}