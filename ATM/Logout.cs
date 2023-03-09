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
    public partial class Logout : Form
    {
        Account a = new Account();
        public Logout(Account a1)
        {
            a = a1;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (a.Balance != 0)
                MessageBox.Show("此账户中尚存有余额，无法注销！");
            else if (!DAO.Logout(a))
            {
                MessageBox.Show("账户注销失败！");
            }
            else
            {
                MessageBox.Show("账户注销成功");
                MainFrame1 m1 = new MainFrame1(a.Username);
                m1.Show();
                this.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainFrame1 m1 = new MainFrame1(a.Username);
            m1.Show();
            this.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MainFrame1 m1 = new MainFrame1(a.Username);
            m1.Show();
            this.Visible = false;
        }

        private void Logout_Load(object sender, EventArgs e)
        {
            this.Text = "欢迎用户" + a.Username + "  🐻  账号" + a.Accid; ;
        }


    }
}
