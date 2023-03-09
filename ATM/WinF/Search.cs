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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";//清空文本框
            groupBox1.Text = "查询结果";
            string pid = textBox1.Text;
            BLL.cardinfo bll = new BLL.cardinfo();
            DataSet ds = bll.search(pid);//调用查询方法
            string s = "";
            if (ds.Tables[0].Rows.Count == 0)
            {
                richTextBox1.AppendText("不是本行客户！");
                return;
            }

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                string cardID = ds.Tables[0].Rows[i][0].ToString();//数字顺序，要参照dal里的sql语句字段顺序写
                string curType = ds.Tables[0].Rows[i][1].ToString();
                string savingType = ds.Tables[0].Rows[i][2].ToString();
                string openDate = ds.Tables[0].Rows[i][3].ToString();
                string balance = ds.Tables[0].Rows[i][4].ToString();
                string IsReportLoss = ds.Tables[0].Rows[i][5].ToString();
                IsReportLoss = ((IsReportLoss == "True") ? "已挂失" : "正常");
                string customerName = ds.Tables[0].Rows[i][6].ToString();//客户名

                groupBox1.Text = customerName + "的银行卡查询结果";

                s = "----------银行卡" + (i + 1) + "---------\r\n卡号:" + cardID + "\r\n货币种类：" + curType + "\r\n账户类型：" + savingType;
                s += "\r\n开户日期:" + openDate + "\r\n余额：" + balance + "\r\n账户状态：" + IsReportLoss + "\r\n";

                richTextBox1.AppendText(s);//文本框追加内容
            }
        }
    }
}