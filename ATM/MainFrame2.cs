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
    public partial class MainFrame2 : Form
    {
        Account a1 = new Account();

        public MainFrame2()
        {
            InitializeComponent();
        }

        public MainFrame2(Account a2)
        {
            this.a1 = a2;
            InitializeComponent();
        }


        private void MainFrame2_Load(object sender, EventArgs e)
        {
            this.Text = "欢迎用户" + a1.Username + " 🐻  账号" + a1.Accid.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Withdraw wd = new Withdraw(a1);
            wd.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Deposit dp = new Deposit(a1.Username.ToString(), a1.Accid);
            dp.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Transfer tf = new Transfer(a1);
            tf.Show();
            this.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MainFrame1 m1 = new MainFrame1(a1.Username);
            m1.Show();
            this.Visible = false;
        }
    }
}
