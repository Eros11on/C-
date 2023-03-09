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
    public partial class Change : Form
    {
        User u1 = new User();
        private string OriPassword, NewPassword, ConNewPassword;

        public Change(string name)
        {
            u1.Username = name;
            InitializeComponent();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OriPassword = textBox1.Text.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            NewPassword = textBox2.Text.ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            ConNewPassword = textBox3.Text.ToString();
        }

        private void Change_Load(object sender, EventArgs e)
        {
            this.Text = "欢迎用户" + u1.Username + "  🐻";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (DAO.Change(u1.Username, OriPassword) == 2)
                MessageBox.Show("原密码错误，请重新输入！");
            else if (NewPassword is null)
                MessageBox.Show("新密码不可为空，请重新输入！");
            else if (ConNewPassword != NewPassword || ConNewPassword is null)
                MessageBox.Show("新密码信息不一致，请重新输入");
            else if (DAO.Change(u1.Username, OriPassword) == 4)
                MessageBox.Show("异常！");
            else
            {
                if (DAO.Change2(u1.Username, NewPassword) == 2)
                    MessageBox.Show("修改失败，请重新输入！");
                else if (DAO.Change2(u1.Username, NewPassword) == 4)
                    MessageBox.Show("异常！");
                else
                {
                    MessageBox.Show("修改成功！");
                    MainFrame1 m1 = new MainFrame1(u1.Username);
                    m1.Show();
                    this.Visible = false;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MainFrame1 m1 = new MainFrame1(u1.Username);
            m1.Show();
            this.Visible = false;
        }
    }
}
