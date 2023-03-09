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
    public partial class Transfer : Form
    {
        Account actransfer = new Account();
        private string account;
        public Transfer(Account a1)
        {
            actransfer = a1;
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
            textBox2.Text += ((Button)sender).Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            account = textBox1.Text.ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (account is null)
            {
                MessageBox.Show("不可向空账号转账！");
            }
            else if (account == actransfer.Accid.ToString())
            {
                MessageBox.Show("同一账户不支持转账！");
            }
            else if (float.Parse(textBox2.Text) < 0.01)
                MessageBox.Show("转账金额不可少于0.01￥，转账失败！");
            else
            {
                if (float.Parse(textBox2.Text) > actransfer.Balance)
                {
                    if (actransfer.Acctype.Contains("信用卡"))
                    {
                        if (MessageBox.Show("您的信用卡额度不支持此次转账，是否使用额度？", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (float.Parse(textBox2.Text) <= (actransfer.Balance + actransfer.Limit))
                            {
                                if (!DAO.Transfer(actransfer.Accid.ToString(), account, float.Parse(textBox2.Text)))
                                    MessageBox.Show("转账失败！");
                                else
                                {
                                    MessageBox.Show("转账成功！");
                                    actransfer.Balance -= float.Parse(textBox2.Text);
                                    MainFrame1 m1 = new MainFrame1(actransfer.Username);
                                    m1.Show();
                                    this.Visible = false;
                                }
                            }
                            else
                                MessageBox.Show("转账失败！本次转账金额超出了账户余额与最大超支金额的总和");
                        }
                    }
                    else
                    {
                        MessageBox.Show("您的储蓄卡额度不支持此次转账，若仍需转账，请更换账户。");
                    }
                }
                else
                {
                    if (!DAO.Transfer(actransfer.Accid.ToString(), account, float.Parse(textBox2.Text)))
                        MessageBox.Show("转账失败！");
                    else
                    {
                        MessageBox.Show("转账成功！");
                        actransfer.Balance -= float.Parse(textBox2.Text);
                        MainFrame1 m1 = new MainFrame1(actransfer.Username);
                        m1.Show();
                        this.Visible = false;
                    }
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MainFrame2 m1 = new MainFrame2(actransfer);
            m1.Show();
            this.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void Transfer_Load(object sender, EventArgs e)
        {
            this.Text = "欢迎用户" + actransfer.Username + " 🐻  账号" + actransfer.Accid;
        }

    

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainFrame1 m1 = new MainFrame1(actransfer.Username);
            m1.Show();
            this.Visible = false;
        }
    }
}
