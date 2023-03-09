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
    public partial class Deposit : Form
    {
        Account acdeposit = new Account();
        public Deposit()
        {
            InitializeComponent();
        }
        public Deposit(string usernamefrommf2, int accountfrommf2)
        {
            InitializeComponent();
            acdeposit.Username = usernamefrommf2;
            acdeposit.Accid = accountfrommf2;
            this.button1.Click += new EventHandler(button_Click);
            this.button2.Click += new EventHandler(button_Click);
            this.button3.Click += new EventHandler(button_Click);
            this.button4.Click += new EventHandler(button_Click);
            this.button5.Click += new EventHandler(button_Click);
            this.button6.Click += new EventHandler(button_Click);
            this.button7.Click += new EventHandler(button_Click);
            this.button8.Click += new EventHandler(button_Click);
            this.button9.Click += new EventHandler(button_Click);
            this.button9.Click += new EventHandler(button_Click);
            this.button10.Click += new EventHandler(button_Click);
            this.button11.Click += new EventHandler(button_Click);
        }
        private void button_Click(object sender, EventArgs e)
        {
            textBox1.Text += ((Button)sender).Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void Deposit_Load(object sender, EventArgs e)
        {
            this.Text = "欢迎用户" + acdeposit.Username + " 🐻 账号" + acdeposit.Accid;
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MainFrame2 m1 = new MainFrame2(acdeposit);
            m1.Show();
            this.Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (float.Parse(textBox1.Text) < 100)
                MessageBox.Show("存款金额不可少于100￥，存款失败！");
            else if (!DAO.Deposit(acdeposit.Accid, float.Parse(textBox1.Text)))
                MessageBox.Show("存款失败！");
            else
            {
                MessageBox.Show("存款成功！");
                MainFrame2 m1 = new MainFrame2(acdeposit);
                m1.Show();
                this.Visible = false;
        }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MainFrame2 m1 = new MainFrame2(acdeposit);
            m1.Show();
            this.Visible = false;
        }

    }
}
