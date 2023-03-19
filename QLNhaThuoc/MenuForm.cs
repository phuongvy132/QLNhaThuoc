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
    public partial class MenuForm : DevExpress.XtraEditors.XtraForm
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void btnKH_Click(object sender, EventArgs e)
        {
            //chuyển sang page tiếp theo
            CustomersForm form = new CustomersForm();
            form.ShowDialog();
            this.Hide();

        }
    }
}