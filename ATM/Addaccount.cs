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
    public partial class Addaccount : Form
    {
        Account a = new Account();
        public Addaccount(string name)
        {
            a.Username = name;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            a.Accid = int.Parse(textBox1.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            a.Accbank = comboBox1.Text.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            a.Acctype = comboBox2.Text.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (a.Accid.ToString() is null || a.Accbank is null || a.Acctype is null)
                MessageBox.Show("信息不完整，无法实现新增操作");
            else
            {
                if (!DAO.Addaccount(a))
                {
                    MessageBox.Show("新账户添加失败,账号已在🐻bank中存在了");
                }
                else
                {
                    MessageBox.Show("新账户添加成功");
                    MainFrame1 m1 = new MainFrame1(a.Username);
                    m1.Show();
                    this.Visible = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainFrame2 m1 = new MainFrame2(a);
            m1.Show();
            this.Visible = false;
        }

        private void Addaccount_Load(object sender, EventArgs e)
        {
            this.Text = "欢迎用户" + a.Username + "  🐻";
        }


        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MainFrame1 m1 = new MainFrame1(a.Username);
            m1.Show();
            this.Visible = false;
        }


    }
}
