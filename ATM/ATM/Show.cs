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
    public partial class Show : Form
    {
        public string CardID;
        public Show()
        {
            InitializeComponent();
        }

        private void Show_Load(object sender, EventArgs e)
        {
            BLL.cardinfo bll = new BLL.cardinfo();
            Model.cardinfo model = bll.GetModel(CardID);
            label1.Text = "账号：" + model.cardID + "\r\n货币类型：" + model.curType + "\r\n存款类型：" + model.savingType;
            label2.Text = "开户日期：" + model.openDate + "\r\n账户状态：" + (model.IsReportLoss ? "已挂失" : "正常") + "\r\n账户余额：" + model.balance;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}