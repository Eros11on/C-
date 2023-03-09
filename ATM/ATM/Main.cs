using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinF
{
    public partial class Main : Form
    {
        public string CardID;
        public Main()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void 登录toolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login lo = new Login();//创建登陆窗口
            DialogResult dr = lo.ShowDialog();//以对话框窗口形式打开，得到返回值
            if (dr == DialogResult.OK)//登陆成功
            {
                this.CardID = lo.CardID;//记录卡号
                退出账户toolStripMenuItem.Text = "【" + this.CardID + "】退出账号";//修改退出菜单项文字
                账户管理ToolStripMenuItem.Enabled = true;//设置菜单的可用性
                现金操作ToolStripMenuItem.Enabled = true;
                查交易明细ToolStripMenuItem.Enabled = true;
                退出账户toolStripMenuItem.Enabled = true;
                登录toolStripMenuItem.Enabled = false;
            }
        }

        private void 退出账户toolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CardID = "";//清空卡号
            退出账户toolStripMenuItem.Text = "退出账号";
            账户管理ToolStripMenuItem.Enabled = false;//设置菜单可用性
            现金操作ToolStripMenuItem.Enabled = false;
            查交易明细ToolStripMenuItem.Enabled = false;
            退出账户toolStripMenuItem.Enabled = false;
            登录toolStripMenuItem.Enabled = true;
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 新开户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewCard nc = new NewCard();
            nc.ShowDialog();
        }

        private void 查余额ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show so = new WinF.Show();
            so.CardID = CardID;
            so.ShowDialog();
        }

        private void 取款ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetMoney gm = new GetMoney();
            gm.CardID = CardID;
            gm.ShowDialog();
        }

        private void 存款ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetMoney sm = new SetMoney();
            sm.CardID = CardID;
            sm.ShowDialog();
        }

        private void 转账ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transfer tr = new Transfer();
            tr.CardID = CardID;
            tr.ShowDialog();

        }

        private void 查交易明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetTrans gt = new GetTrans();
            gt.CardID = CardID;
            gt.ShowDialog();
        }

        private void 改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePWD cp = new ChangePWD();
            cp.CardID = CardID;
            DialogResult OK = cp.ShowDialog();
            if (OK == DialogResult.OK)
            {
                退出账户toolStripMenuItem_Click(null, null);
            }
        }

        private void 挂失ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lost lo = new Lost();
            lo.CardID = CardID;
            lo.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}