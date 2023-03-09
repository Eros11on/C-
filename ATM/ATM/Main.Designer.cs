namespace WinF
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.登录toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.账户管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查余额ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.改密码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.挂失ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.现金操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取款ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.存款ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.转账ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查交易明细ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出账户toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新开户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.退出系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.资产查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.登录toolStripMenuItem,
            this.账户管理ToolStripMenuItem,
            this.现金操作ToolStripMenuItem,
            this.查交易明细ToolStripMenuItem,
            this.退出账户toolStripMenuItem,
            this.新开户ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.退出系统ToolStripMenuItem,
            this.资产查询ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(805, 26);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 登录toolStripMenuItem
            // 
            this.登录toolStripMenuItem.Name = "登录toolStripMenuItem";
            this.登录toolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.登录toolStripMenuItem.Text = "登录";
            this.登录toolStripMenuItem.Click += new System.EventHandler(this.登录toolStripMenuItem_Click);
            // 
            // 账户管理ToolStripMenuItem
            // 
            this.账户管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查余额ToolStripMenuItem,
            this.改密码ToolStripMenuItem,
            this.挂失ToolStripMenuItem});
            this.账户管理ToolStripMenuItem.Enabled = false;
            this.账户管理ToolStripMenuItem.Name = "账户管理ToolStripMenuItem";
            this.账户管理ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.账户管理ToolStripMenuItem.Text = "账户管理";
            // 
            // 查余额ToolStripMenuItem
            // 
            this.查余额ToolStripMenuItem.DoubleClickEnabled = true;
            this.查余额ToolStripMenuItem.Name = "查余额ToolStripMenuItem";
            this.查余额ToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.查余额ToolStripMenuItem.Text = "查余额";
            this.查余额ToolStripMenuItem.Click += new System.EventHandler(this.查余额ToolStripMenuItem_Click);
            // 
            // 改密码ToolStripMenuItem
            // 
            this.改密码ToolStripMenuItem.Name = "改密码ToolStripMenuItem";
            this.改密码ToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.改密码ToolStripMenuItem.Text = "改密码";
            this.改密码ToolStripMenuItem.Click += new System.EventHandler(this.改密码ToolStripMenuItem_Click);
            // 
            // 挂失ToolStripMenuItem
            // 
            this.挂失ToolStripMenuItem.Name = "挂失ToolStripMenuItem";
            this.挂失ToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.挂失ToolStripMenuItem.Text = "挂失/取挂";
            this.挂失ToolStripMenuItem.Click += new System.EventHandler(this.挂失ToolStripMenuItem_Click);
            // 
            // 现金操作ToolStripMenuItem
            // 
            this.现金操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.取款ToolStripMenuItem,
            this.存款ToolStripMenuItem,
            this.转账ToolStripMenuItem});
            this.现金操作ToolStripMenuItem.Enabled = false;
            this.现金操作ToolStripMenuItem.Name = "现金操作ToolStripMenuItem";
            this.现金操作ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.现金操作ToolStripMenuItem.Text = "现金操作";
            // 
            // 取款ToolStripMenuItem
            // 
            this.取款ToolStripMenuItem.Name = "取款ToolStripMenuItem";
            this.取款ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.取款ToolStripMenuItem.Text = "取款";
            this.取款ToolStripMenuItem.Click += new System.EventHandler(this.取款ToolStripMenuItem_Click);
            // 
            // 存款ToolStripMenuItem
            // 
            this.存款ToolStripMenuItem.Name = "存款ToolStripMenuItem";
            this.存款ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.存款ToolStripMenuItem.Text = "存款";
            this.存款ToolStripMenuItem.Click += new System.EventHandler(this.存款ToolStripMenuItem_Click);
            // 
            // 转账ToolStripMenuItem
            // 
            this.转账ToolStripMenuItem.Name = "转账ToolStripMenuItem";
            this.转账ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.转账ToolStripMenuItem.Text = "转账";
            this.转账ToolStripMenuItem.Click += new System.EventHandler(this.转账ToolStripMenuItem_Click);
            // 
            // 查交易明细ToolStripMenuItem
            // 
            this.查交易明细ToolStripMenuItem.Enabled = false;
            this.查交易明细ToolStripMenuItem.Name = "查交易明细ToolStripMenuItem";
            this.查交易明细ToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.查交易明细ToolStripMenuItem.Text = "查交易明细";
            this.查交易明细ToolStripMenuItem.Click += new System.EventHandler(this.查交易明细ToolStripMenuItem_Click);
            // 
            // 退出账户toolStripMenuItem
            // 
            this.退出账户toolStripMenuItem.Enabled = false;
            this.退出账户toolStripMenuItem.Name = "退出账户toolStripMenuItem";
            this.退出账户toolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.退出账户toolStripMenuItem.Text = "退出账户";
            this.退出账户toolStripMenuItem.Click += new System.EventHandler(this.退出账户toolStripMenuItem_Click);
            // 
            // 新开户ToolStripMenuItem
            // 
            this.新开户ToolStripMenuItem.Name = "新开户ToolStripMenuItem";
            this.新开户ToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.新开户ToolStripMenuItem.Text = "新开户";
            this.新开户ToolStripMenuItem.Click += new System.EventHandler(this.新开户ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(53, 24);
            this.toolStripMenuItem2.Text = "帮助";
            // 
            // 退出系统ToolStripMenuItem
            // 
            this.退出系统ToolStripMenuItem.Name = "退出系统ToolStripMenuItem";
            this.退出系统ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.退出系统ToolStripMenuItem.Text = "退出系统";
            this.退出系统ToolStripMenuItem.Click += new System.EventHandler(this.退出系统ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(173, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(422, 70);
            this.label1.TabIndex = 1;
            this.label1.Text = "欢迎使用ATM";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ATM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 账户管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查余额ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 改密码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 挂失ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 现金操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取款ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 存款ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 转账ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查交易明细ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新开户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 登录toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出账户toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 资产查询ToolStripMenuItem;
    }
}