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
        private void btnDuocPham_Click(object sender, EventArgs e)
        {
            DuocPham DP = new DuocPham();
            DP.TopLevel = false;
            pnlFormLoader.Controls.Add(DP);
            DP.BringToFront();
            DP.Show();

            pnlNav.Height = btnDuocPham.Height;
            pnlNav.Top = btnDuocPham.Top;
            pnlNav.Left = btnDuocPham.Left;
            btnDuocPham.BackColor = Color.FromArgb(46, 77, 167);
        }
        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            HoaDon HD = new HoaDon();
            HD.TopLevel = false;
            pnlFormLoader.Controls.Add(HD);
            HD.BringToFront();
            HD.Show();

            pnlNav.Height = btnHoaDon.Height;
            pnlNav.Top = btnHoaDon.Top;
            pnlNav.Left = btnHoaDon.Left;
            btnHoaDon.BackColor = Color.FromArgb(46, 77, 167);
        }
        private void btnTChu_Leave(object sender, EventArgs e)
        {
            btnTChu.BackColor = Color.FromArgb(3, 37, 126);
        }
        private void btnDuocPham_Leave(object sender, EventArgs e)
        {
            btnDuocPham.BackColor = Color.FromArgb(3, 37, 126);
        }
        private void btnHoaDon_Leave(object sender, EventArgs e)
        {
            btnHoaDon.BackColor = Color.FromArgb(3, 37, 126);
        }
        #endregion

    }
}