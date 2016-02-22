namespace PMA
{
    partial class FrmMain
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnProCheck = new DevExpress.XtraEditors.SimpleButton();
            this.btnSpecialMananger = new DevExpress.XtraEditors.SimpleButton();
            this.btnProManager = new DevExpress.XtraEditors.SimpleButton();
            this.btnPotPro = new DevExpress.XtraEditors.SimpleButton();
            this.panelMain = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(893, 52);
            this.panelControl1.TabIndex = 0;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 52);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.panelControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panelMain);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(893, 588);
            this.splitContainerControl1.SplitterPosition = 183;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnExit);
            this.panelControl2.Controls.Add(this.btnProCheck);
            this.panelControl2.Controls.Add(this.btnSpecialMananger);
            this.panelControl2.Controls.Add(this.btnProManager);
            this.panelControl2.Controls.Add(this.btnPotPro);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(183, 588);
            this.panelControl2.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(24, 317);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(133, 47);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "退出系统";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnProCheck
            // 
            this.btnProCheck.Location = new System.Drawing.Point(24, 254);
            this.btnProCheck.Name = "btnProCheck";
            this.btnProCheck.Size = new System.Drawing.Size(133, 47);
            this.btnProCheck.TabIndex = 0;
            this.btnProCheck.Text = "项目查看";
            this.btnProCheck.Click += new System.EventHandler(this.btnProCheck_Click);
            // 
            // btnSpecialMananger
            // 
            this.btnSpecialMananger.Location = new System.Drawing.Point(24, 187);
            this.btnSpecialMananger.Name = "btnSpecialMananger";
            this.btnSpecialMananger.Size = new System.Drawing.Size(133, 47);
            this.btnSpecialMananger.TabIndex = 0;
            this.btnSpecialMananger.Text = "项目专责数据维护";
            this.btnSpecialMananger.Click += new System.EventHandler(this.btnSpecialMananger_Click);
            // 
            // btnProManager
            // 
            this.btnProManager.Location = new System.Drawing.Point(24, 118);
            this.btnProManager.Name = "btnProManager";
            this.btnProManager.Size = new System.Drawing.Size(133, 47);
            this.btnProManager.TabIndex = 0;
            this.btnProManager.Text = "上台账项目管理维护";
            this.btnProManager.Click += new System.EventHandler(this.btnProManager_Click);
            // 
            // btnPotPro
            // 
            this.btnPotPro.Location = new System.Drawing.Point(24, 46);
            this.btnPotPro.Name = "btnPotPro";
            this.btnPotPro.Size = new System.Drawing.Size(133, 47);
            this.btnPotPro.TabIndex = 0;
            this.btnPotPro.Text = "潜在项目管理维护";
            this.btnPotPro.Click += new System.EventHandler(this.btnPotPro_Click);
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(705, 588);
            this.panelMain.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 640);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelMain;
        private DevExpress.XtraEditors.SimpleButton btnPotPro;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnProCheck;
        private DevExpress.XtraEditors.SimpleButton btnSpecialMananger;
        private DevExpress.XtraEditors.SimpleButton btnProManager;
    }
}