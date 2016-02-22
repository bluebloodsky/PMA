namespace PMA.ProCheck
{
    partial class ControlProCheck
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tpPotInfo = new DevExpress.XtraTab.XtraTabPage();
            this.tpIncome = new DevExpress.XtraTab.XtraTabPage();
            this.tpBack = new DevExpress.XtraTab.XtraTabPage();
            this.tpCost = new DevExpress.XtraTab.XtraTabPage();
            this.tpExport = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tpPotInfo;
            this.xtraTabControl1.Size = new System.Drawing.Size(460, 425);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpPotInfo,
            this.tpIncome,
            this.tpBack,
            this.tpCost,
            this.tpExport});
            // 
            // tpPotInfo
            // 
            this.tpPotInfo.Name = "tpPotInfo";
            this.tpPotInfo.Size = new System.Drawing.Size(454, 396);
            this.tpPotInfo.Text = "待签合同进展";
            // 
            // tpIncome
            // 
            this.tpIncome.Name = "tpIncome";
            this.tpIncome.Size = new System.Drawing.Size(454, 396);
            this.tpIncome.Text = "可确认收入";
            // 
            // tpBack
            // 
            this.tpBack.Name = "tpBack";
            this.tpBack.Size = new System.Drawing.Size(454, 396);
            this.tpBack.Text = "可回款信息";
            // 
            // tpCost
            // 
            this.tpCost.Name = "tpCost";
            this.tpCost.Size = new System.Drawing.Size(454, 396);
            this.tpCost.Text = "成本信息";
            // 
            // tpExport
            // 
            this.tpExport.Name = "tpExport";
            this.tpExport.Size = new System.Drawing.Size(454, 396);
            this.tpExport.Text = "导出总报表";
            // 
            // ProCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "ProCheck";
            this.Size = new System.Drawing.Size(460, 425);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tpPotInfo;
        private DevExpress.XtraTab.XtraTabPage tpIncome;
        private DevExpress.XtraTab.XtraTabPage tpBack;
        private DevExpress.XtraTab.XtraTabPage tpCost;
        private DevExpress.XtraTab.XtraTabPage tpExport;
    }
}
