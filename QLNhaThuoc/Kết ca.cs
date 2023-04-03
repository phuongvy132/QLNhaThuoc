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
    public partial class Kết_ca : DevExpress.XtraEditors.XtraForm
    {
        public Kết_ca()
        {
            InitializeComponent();
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {
            DateTime aDateTime = DateTime.Now;
            Console.WriteLine("Now is " + aDateTime);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            DateTime dt = DateTime.Now;
            //Console.WriteLine(aDateTime);
            textBox1.Text = String.Format("{0:MM/dd/yyyy}", dt);

        }
    }
}