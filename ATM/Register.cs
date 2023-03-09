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
    public partial class Register : Form
    {
        private string thisname, thispassword, thispw;
        public Register()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (thisname is null || thispassword is null)
                MessageBox.Show("🐻提醒：用户名/密码为空，请重新输入");
            else if (thispassword != thispw)
                MessageBox.Show("🐻提醒：密码不一致，请重新输入");
            else
            {
                if (!DAO.Register(thisname, thispw))
                {
                    MessageBox.Show("🐻提醒：注册失败，请更换用户名再试");
                }
                else
                {
                    MessageBox.Show("注册成功,欢迎加入Bear Bank🐻");
                    Login l1 = new Login();
                    l1.Show();
                    this.Visible = false;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            thisname = textBox1.Text.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            thispassword = textBox2.Text.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            thispw = textBox3.Text.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login l1 = new Login();
            l1.Show();
            this.Visible = false;
        }
    }
}
