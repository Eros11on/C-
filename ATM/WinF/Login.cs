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
    public partial class Login : Form
    {
        public string CardID;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            string name = textBox1.Text;
            string pwd = textBox2.Text;
            BLL.cardinfo bll = new BLL.cardinfo();//创建bll层对象
            if (bll.Exists(name, pwd))  //调用方法
            {
                CardID = textBox1.Text;//保存卡号到字段
                this.DialogResult = DialogResult.OK;//表示登陆成功
            }
            else
            { label1.Text = "用户名密码错误！请重试"; }//显示错误信息
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;//表示登录不成功
        }
    }
}
