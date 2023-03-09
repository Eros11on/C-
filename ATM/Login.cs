using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM
{
    public partial class Login : Form
    {
        private string thisname, thispassword;
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            thisname = textBox1.Text.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DAO.Login(thisname, thispassword) == 2)
                MessageBox.Show("不存在该用户");
            else if (DAO.Login(thisname, thispassword) == 3)
            {
                MessageBox.Show("用户或密码有误，请点击清除后重新输入");
                thisname = null;
                thispassword = null;
            }
            else if (DAO.Login(thisname, thispassword) == 4)
                MessageBox.Show("出现异常");
            else
            {
                MessageBox.Show("成功登录！");
                MainFrame1 mainFrame1 = new MainFrame1(thisname);
                mainFrame1.Show();
                this.Visible = false;
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定退出Bear bank吗？");
            if(dr == DialogResult.OK)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            thispassword = textBox2.Text.ToString();
        }
    }
}
