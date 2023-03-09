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
    public partial class NewCard : Form
    {
        private int CustomerID = 0;//用户ID
        public string CardID;//卡号
        public NewCard()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label9.Text = "";

            string acctype = comboBox1.Text;
            decimal opennnum = numericUpDown1.Value;
            string pwd = textBox5.Text;
            Model.cardinfo model = new Model.cardinfo();
            model.cardID = "";
            model.curType = "RMB";
            model.customerID = CustomerID;
            model.IsReportLoss = false;
            model.savingType = acctype;
            model.openDate = DateTime.Now;
            model.openMoney = opennnum;
            model.balance = opennnum;
            model.pass = pwd;
            bool openOK;
            if (CustomerID != 0)//身份证已注册
            {
                BLL.cardinfo bll = new BLL.cardinfo();
                openOK = bll.Add(model, out CardID);
            }
            else
            {
                string name = textBox2.Text;
                string pid = textBox1.Text;
                string tel = textBox3.Text;
                string add = textBox4.Text;
                Model.userInfo modelU = new Model.userInfo();
                modelU.customerID = 0;
                modelU.customerName = name;
                modelU.pID = pid;
                modelU.telephone = tel;
                modelU.address = add;
                BLL.userInfo bllU = new BLL.userInfo();
                CustomerID = bllU.Add(modelU);

                model.customerID = CustomerID;
                BLL.cardinfo bll = new BLL.cardinfo();
                openOK = bll.Add(model, out CardID);
            }
            if (openOK)
            {
                label9.Text = "注册成功，卡号是：" + CardID + "，请前去登录!";
                Clipboard.SetText(CardID);//剪贴板
            }
            else { label9.Text = "注册失败，下次再来！"; }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label8.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            string pid = textBox1.Text;
            BLL.userInfo bll = new BLL.userInfo();
            Model.userInfo model = bll.GetModel(pid);
            if (model != null)
            {
                textBox2.Text = model.customerName;
                textBox3.Text = model.telephone;
                textBox4.Text = model.address;
                CustomerID = model.customerID;
                label8.Text = "老客户，基本信息不用重填";
            }
            else
            { label8.Text = "新客户，请填基本信息"; }
        }
    }
}