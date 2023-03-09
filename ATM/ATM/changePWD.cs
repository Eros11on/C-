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
    public partial class ChangePWD : Form
    {
        public string CardID;
        public ChangePWD()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            if (textBox2.Text != textBox3.Text)
            { label4.Text = "两次新密码不一致，请重输！"; }
            else
            {
                BLL.cardinfo bll = new BLL.cardinfo();
                bool isOK = bll.changePwd(CardID, textBox1.Text, textBox3.Text);
                if (isOK)
                {
                    MessageBox.Show("密码修改成功，请重新登录！", "成功");
                    this.DialogResult = DialogResult.OK;
                }
                else { label4.Text = "密码修改失败，请重试！"; }
            }
        }
    }
}
