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
    public partial class MainFrame1 : Form
    {
        User u1 = new User();
        int selectedaccount;
        float Balance,Limit;
        string Acctype;
        public MainFrame1(string usernameValue)
        {
            InitializeComponent();
            u1.Username = usernameValue;
        }


        private void MainFrame1_Load(object sender, EventArgs e)
        {
            this.Text = "欢迎您：" + u1.Username.ToString();
            this.dataGridView1.RowHeadersVisible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Account accountfromf1 = new Account();
            accountfromf1.Accid = selectedaccount;
            Change c1 = new Change(u1.Username);
            c1.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = DAO.viewAccount(u1.Username.ToString()).Tables["Account"];
            this.dataGridView1.ReadOnly = false;
            DataGridViewCheckBoxColumn checkColumns = new DataGridViewCheckBoxColumn();
            checkColumns.Name = "选择";
            checkColumns.Width = 50;

            this.dataGridView1.Columns.Insert(0, checkColumns);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                dataGridView1.Rows[i].Cells[0].Value = false;
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;

            dataGridView1.Columns[1].HeaderText = "账号";
            dataGridView1.Columns[2].HeaderText = "银行";
            dataGridView1.Columns[3].HeaderText = "卡类型"; 
            dataGridView1.Columns[4].HeaderText = "余额";
            dataGridView1.Columns[5].HeaderText = "用户";
            dataGridView1.Columns[6].HeaderText = "额度";

            this.button2.Enabled = false;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dataGridView1.Rows[e.RowIndex].Cells[0].Selected == true)
                {
                    selectedaccount = (int)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                    Balance = float.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                    Limit = float.Parse(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                    Acctype = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                }
                else
                    selectedaccount = 8888;
            }
            catch
            {
                Console.WriteLine("异常{0}", e.ToString());
            }

        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedaccount == 0) MessageBox.Show("未选择待操作的账户!");
            else if (MessageBox.Show("是否选择账号" + selectedaccount + "进行操作？", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Account accountfromf1 = new Account();
                accountfromf1.Accid = selectedaccount;
                accountfromf1.Username = this.u1.Username;
                accountfromf1.Balance = Balance;
                accountfromf1.Limit = Limit;
                accountfromf1.Acctype = Acctype;
                MainFrame2 m2 = new MainFrame2(accountfromf1);
                m2.Show();
                this.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Account accountfromf1 = new Account();
            accountfromf1.Accid = selectedaccount;
            accountfromf1.Username = this.u1.Username;
            Addaccount n1 = new Addaccount(u1.Username);
            n1.Show();
            this.Visible = false;
        }



        private void button5_Click(object sender, EventArgs e)
        {
            if (selectedaccount == 0) MessageBox.Show("未选择待操作的账户!");
            else if (MessageBox.Show("是否选择账号" + selectedaccount + "进行操作？", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Account accountfromf1 = new Account();
                accountfromf1.Accid = selectedaccount;
                accountfromf1.Username = this.u1.Username;
                accountfromf1.Balance = Balance;
                accountfromf1.Limit = Limit;
                accountfromf1.Acctype = Acctype;
                Logout l1 = new Logout(accountfromf1);
                l1.Show();
                this.Visible = false;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Login l1 = new Login();
            l1.Show();
            this.Visible = false;
        }

    }
}