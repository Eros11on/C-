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
    public partial class Lost : Form
    {
        public string CardID;
        public Lost()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BLL.cardinfo bll = new BLL.cardinfo();
            bool isOK = bll.ChangeState(CardID);
            if (isOK)
            {
                if (button1.Text == "挂失")
                { label1.Text = "挂失操作成功"; button1.Text = "取消挂失"; }
                else
                { label1.Text = "取消挂失操作成功"; button1.Text = "挂失"; }

            }
            else
            {
                label1.Text = "操作失败";
            }
        }

        private void Lost_Load(object sender, EventArgs e)
        {
            BLL.cardinfo bll = new BLL.cardinfo();
            bool IsLost = bll.getState(CardID);
            if (IsLost) { button1.Text = "取消挂失"; }
            else { button1.Text = "挂失"; }
        }
    }
}