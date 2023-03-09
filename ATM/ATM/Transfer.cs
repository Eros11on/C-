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
    public partial class Transfer : Form
    {
        public string CardID;
        public Transfer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal num = numericUpDown1.Value;
            string toCardID = textBox1.Text;
            BLL.cardinfo bll = new BLL.cardinfo();
            bool isOk = bll.ZhuanZhang(CardID, toCardID, num);
            if (isOk) { label2.Text = "转账成功！"; }
            else
            {
                label2.Text = "转账失败！";
            }
        }
    }
}