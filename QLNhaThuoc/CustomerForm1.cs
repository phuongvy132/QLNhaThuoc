using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLNhaThuoc_BUS;

namespace QLNhaThuoc
{
    public partial class CustomerForm1 : Form
    {
        public CustomerForm1()
        {
            InitializeComponent();
        }
        class SurroundingClass
        {
        }

        private void dgvKH_Load(object sender, EventArgs e)
        {

            //DataSet ds = new DataSet();
            //ds = _load_data("select * from KhachHang");
            //dgvKH.DataSource = ds.Tables(0);

            //// đưa giá trị cho label
            //lbMaKH.DataBindings.Clear();
            //lbMaKH.DataBindings.Add("Text", ds.Tables(0), "MaKH");
        }
    }
}
