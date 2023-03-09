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
    public partial class Withdraw : Form
    {
        Account acwithdraw = new Account();
        public Withdraw(Account a)
        {
            acwithdraw = a;
            InitializeComponent();
            this.button1.Click += new EventHandler(button_Click);
            this.button2.Click += new EventHandler(button_Click);
            this.button3.Click += new EventHandler(button_Click);
            this.button4.Click += new EventHandler(button_Click);
            this.button5.Click += new EventHandler(button_Click);
            this.button6.Click += new EventHandler(button_Click);
            this.button7.Click += new EventHandler(button_Click);
            this.button8.Click += new EventHandler(button_Click);
            this.button9.Click += new EventHandler(button_Click);
            this.button10.Click += new EventHandler(button_Click);
            this.button11.Click += new EventHandler(button_Click);
        }
        private void button_Click(object sender, EventArgs e)
        {
            textBox1.Text += ((Button)sender).Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (float.Parse(textBox1.Text) < 100)
                MessageBox.Show("取款金额不可少于100￥，取款失败！");
            else if (float.Parse(textBox1.Text) > acwithdraw.Balance)
            {
                if (acwithdraw.Acctype.Contains("信用卡"))
                {
                    if (MessageBox.Show("您的信用卡余额不支持此次取款，是否使用信用卡可预支额度？", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (float.Parse(textBox1.Text) <= (acwithdraw.Balance + acwithdraw.Limit))
                        {
                            if (!DAO.Withdraw(acwithdraw.Accid, float.Parse(textBox1.Text)))
                                MessageBox.Show("取款失败！");
                            else
                            {
                                MessageBox.Show("取款成功！");
                                acwithdraw.Balance -= float.Parse(textBox1.Text);
                                MainFrame2 m1 = new MainFrame2(acwithdraw);
                                m1.Show();
                                this.Visible = false;
                            }
                        }
                        else
                            MessageBox.Show("取款失败！您的取款金额超过了账户余额和最大超支金额的总和");
                    }
                }
                else
                {
                    MessageBox.Show("您的储蓄卡额度不支持此次取款，若仍需取款，请更换账户。");
                }
            }
            else
            {
                if (!DAO.Withdraw(acwithdraw.Accid, float.Parse(textBox1.Text)))
                    MessageBox.Show("取款失败！");
                else
                {
                    MessageBox.Show("取款成功！");
                    acwithdraw.Balance -= float.Parse(textBox1.Text);
                    MainFrame2 m1 = new MainFrame2(acwithdraw);
                    m1.Show();
                    this.Visible = false;
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MainFrame2 m1 = new MainFrame2(acwithdraw);
            m1.Show();
            this.Visible = false;
        }

        private void Withdraw_Load(object sender, EventArgs e)
        {
            this.Text = "欢迎用户" + acwithdraw.Username + "  🐻  账号" + acwithdraw.Accid;
        }
    }
}
