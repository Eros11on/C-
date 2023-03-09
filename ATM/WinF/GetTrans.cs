using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinF
{
    public partial class GetTrans : Form
    {
        public string CardID;
        public GetTrans()
        {
            InitializeComponent();
        }

        private void GetTrans_Load(object sender, EventArgs e)
        {
            BLL.transInfo bll = new BLL.transInfo();
            DataSet ds = bll.GetList(" cardID='" + CardID + "'");

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}