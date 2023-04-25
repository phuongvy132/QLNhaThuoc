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

namespace QLNhaThuoc
{
    public partial class ThanhToan : DevExpress.XtraEditors.XtraForm
    {
        public ThanhToan()
        {
            InitializeComponent();
        }

        private void bt6_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            txtTraTien.Text += bt.Text;
            txtTraTien.Focus();
            txtTraTien.SelectionStart = txtTraTien.Text.Length - 1;
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            txtTraTien.Text = " ";
        }

        private void txtTraTien_KeyDown(object sender, KeyEventArgs e)
        {
            //if(e.KeyCode == Keys.Enter)
            
        }
    }
}