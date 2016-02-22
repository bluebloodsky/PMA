namespace ReportExcel
{
    partial class FrmDataOut
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOut = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonNOVB = new System.Windows.Forms.RadioButton();
            this.radioButtonDCMAG = new System.Windows.Forms.RadioButton();
            this.radioButtonNeutralpt = new System.Windows.Forms.RadioButton();
            this.radioButtonRemoteS = new System.Windows.Forms.RadioButton();
            this.radioButtonRemoteM = new System.Windows.Forms.RadioButton();
            this.radioButtonVC = new System.Windows.Forms.RadioButton();
            this.radioButtonCore = new System.Windows.Forms.RadioButton();
            this.radioButtonBushing = new System.Windows.Forms.RadioButton();
            this.radioButtonPD = new System.Windows.Forms.RadioButton();
            this.radioButtonGas = new System.Windows.Forms.RadioButton();
            this.dateTimeBegin = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDirection = new System.Windows.Forms.Button();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel4 = new System.Windows.Forms.Panel();
            this.richTextBoxShown = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOut
            // 
            this.btnOut.Location = new System.Drawing.Point(454, 11);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(75, 23);
            this.btnOut.TabIndex = 1;
            this.btnOut.Text = "导出";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.radioButtonNOVB);
            this.panel1.Controls.Add(this.radioButtonDCMAG);
            this.panel1.Controls.Add(this.radioButtonNeutralpt);
            this.panel1.Controls.Add(this.radioButtonRemoteS);
            this.panel1.Controls.Add(this.radioButtonRemoteM);
            this.panel1.Controls.Add(this.radioButtonVC);
            this.panel1.Controls.Add(this.radioButtonCore);
            this.panel1.Controls.Add(this.radioButtonBushing);
            this.panel1.Controls.Add(this.radioButtonPD);
            this.panel1.Controls.Add(this.radioButtonGas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(138, 432);
            this.panel1.TabIndex = 6;
            this.panel1.Visible = false;
            // 
            // radioButtonNOVB
            // 
            this.radioButtonNOVB.AutoSize = true;
            this.radioButtonNOVB.Location = new System.Drawing.Point(12, 320);
            this.radioButtonNOVB.Name = "radioButtonNOVB";
            this.radioButtonNOVB.Size = new System.Drawing.Size(71, 16);
            this.radioButtonNOVB.TabIndex = 9;
            this.radioButtonNOVB.Text = "振动噪声";
            this.radioButtonNOVB.UseVisualStyleBackColor = true;
            this.radioButtonNOVB.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonDCMAG
            // 
            this.radioButtonDCMAG.AutoSize = true;
            this.radioButtonDCMAG.Location = new System.Drawing.Point(12, 285);
            this.radioButtonDCMAG.Name = "radioButtonDCMAG";
            this.radioButtonDCMAG.Size = new System.Drawing.Size(71, 16);
            this.radioButtonDCMAG.TabIndex = 8;
            this.radioButtonDCMAG.Text = "直流偏磁";
            this.radioButtonDCMAG.UseVisualStyleBackColor = true;
            this.radioButtonDCMAG.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonNeutralpt
            // 
            this.radioButtonNeutralpt.AutoSize = true;
            this.radioButtonNeutralpt.Location = new System.Drawing.Point(12, 250);
            this.radioButtonNeutralpt.Name = "radioButtonNeutralpt";
            this.radioButtonNeutralpt.Size = new System.Drawing.Size(59, 16);
            this.radioButtonNeutralpt.TabIndex = 7;
            this.radioButtonNeutralpt.Text = "中性点";
            this.radioButtonNeutralpt.UseVisualStyleBackColor = true;
            this.radioButtonNeutralpt.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonRemoteS
            // 
            this.radioButtonRemoteS.AutoSize = true;
            this.radioButtonRemoteS.Location = new System.Drawing.Point(13, 218);
            this.radioButtonRemoteS.Name = "radioButtonRemoteS";
            this.radioButtonRemoteS.Size = new System.Drawing.Size(59, 16);
            this.radioButtonRemoteS.TabIndex = 6;
            this.radioButtonRemoteS.Text = "遥信量";
            this.radioButtonRemoteS.UseVisualStyleBackColor = true;
            this.radioButtonRemoteS.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonRemoteM
            // 
            this.radioButtonRemoteM.AutoSize = true;
            this.radioButtonRemoteM.Location = new System.Drawing.Point(12, 185);
            this.radioButtonRemoteM.Name = "radioButtonRemoteM";
            this.radioButtonRemoteM.Size = new System.Drawing.Size(59, 16);
            this.radioButtonRemoteM.TabIndex = 5;
            this.radioButtonRemoteM.Text = "遥测量";
            this.radioButtonRemoteM.UseVisualStyleBackColor = true;
            this.radioButtonRemoteM.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonVC
            // 
            this.radioButtonVC.AutoSize = true;
            this.radioButtonVC.Location = new System.Drawing.Point(12, 153);
            this.radioButtonVC.Name = "radioButtonVC";
            this.radioButtonVC.Size = new System.Drawing.Size(71, 16);
            this.radioButtonVC.TabIndex = 4;
            this.radioButtonVC.Text = "电压电流";
            this.radioButtonVC.UseVisualStyleBackColor = true;
            this.radioButtonVC.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonCore
            // 
            this.radioButtonCore.AutoSize = true;
            this.radioButtonCore.Checked = true;
            this.radioButtonCore.Location = new System.Drawing.Point(12, 119);
            this.radioButtonCore.Name = "radioButtonCore";
            this.radioButtonCore.Size = new System.Drawing.Size(95, 16);
            this.radioButtonCore.TabIndex = 3;
            this.radioButtonCore.TabStop = true;
            this.radioButtonCore.Text = "铁心接地电流";
            this.radioButtonCore.UseVisualStyleBackColor = true;
            this.radioButtonCore.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonBushing
            // 
            this.radioButtonBushing.AutoSize = true;
            this.radioButtonBushing.Location = new System.Drawing.Point(13, 88);
            this.radioButtonBushing.Name = "radioButtonBushing";
            this.radioButtonBushing.Size = new System.Drawing.Size(71, 16);
            this.radioButtonBushing.TabIndex = 2;
            this.radioButtonBushing.Text = "套管绝缘";
            this.radioButtonBushing.UseVisualStyleBackColor = true;
            this.radioButtonBushing.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonPD
            // 
            this.radioButtonPD.AutoSize = true;
            this.radioButtonPD.Location = new System.Drawing.Point(13, 53);
            this.radioButtonPD.Name = "radioButtonPD";
            this.radioButtonPD.Size = new System.Drawing.Size(71, 16);
            this.radioButtonPD.TabIndex = 1;
            this.radioButtonPD.Text = "局部放电";
            this.radioButtonPD.UseVisualStyleBackColor = true;
            this.radioButtonPD.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButtonGas
            // 
            this.radioButtonGas.AutoSize = true;
            this.radioButtonGas.Location = new System.Drawing.Point(13, 19);
            this.radioButtonGas.Name = "radioButtonGas";
            this.radioButtonGas.Size = new System.Drawing.Size(59, 16);
            this.radioButtonGas.TabIndex = 0;
            this.radioButtonGas.Text = "油色谱";
            this.radioButtonGas.UseVisualStyleBackColor = true;
            this.radioButtonGas.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // dateTimeBegin
            // 
            this.dateTimeBegin.CustomFormat = "yyyy/MM/dd HH:mm";
            this.dateTimeBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeBegin.Location = new System.Drawing.Point(94, 13);
            this.dateTimeBegin.Name = "dateTimeBegin";
            this.dateTimeBegin.Size = new System.Drawing.Size(133, 21);
            this.dateTimeBegin.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dateTimeEnd);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dateTimeBegin);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(138, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(619, 55);
            this.panel2.TabIndex = 8;
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.CustomFormat = "yyyy/MM/dd HH:mm";
            this.dateTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeEnd.Location = new System.Drawing.Point(345, 13);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(148, 21);
            this.dateTimeEnd.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "结束时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "开始时间";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btnDirection);
            this.panel3.Controls.Add(this.textBoxPath);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btnOut);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(138, 55);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(619, 49);
            this.panel3.TabIndex = 9;
            // 
            // btnDirection
            // 
            this.btnDirection.Location = new System.Drawing.Point(373, 11);
            this.btnDirection.Name = "btnDirection";
            this.btnDirection.Size = new System.Drawing.Size(75, 23);
            this.btnDirection.TabIndex = 2;
            this.btnDirection.Text = "浏览";
            this.btnDirection.UseVisualStyleBackColor = true;
            this.btnDirection.Click += new System.EventHandler(this.btnDirection_Click);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(104, 13);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(246, 21);
            this.textBoxPath.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "导出路径";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(105, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(302, 23);
            this.progressBar1.Step = 5;
            this.progressBar1.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.progressBar1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(138, 104);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(619, 33);
            this.panel4.TabIndex = 12;
            // 
            // richTextBoxShown
            // 
            this.richTextBoxShown.BackColor = System.Drawing.Color.White;
            this.richTextBoxShown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxShown.Location = new System.Drawing.Point(138, 137);
            this.richTextBoxShown.Name = "richTextBoxShown";
            this.richTextBoxShown.ReadOnly = true;
            this.richTextBoxShown.Size = new System.Drawing.Size(619, 295);
            this.richTextBoxShown.TabIndex = 13;
            this.richTextBoxShown.Text = "";
            // 
            // FrmDataOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(757, 432);
            this.Controls.Add(this.richTextBoxShown);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmDataOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "数据导出";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimeBegin;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDirection;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonRemoteS;
        private System.Windows.Forms.RadioButton radioButtonRemoteM;
        private System.Windows.Forms.RadioButton radioButtonVC;
        private System.Windows.Forms.RadioButton radioButtonCore;
        private System.Windows.Forms.RadioButton radioButtonBushing;
        private System.Windows.Forms.RadioButton radioButtonPD;
        private System.Windows.Forms.RadioButton radioButtonGas;
        private System.Windows.Forms.RadioButton radioButtonDCMAG;
        private System.Windows.Forms.RadioButton radioButtonNeutralpt;
        private System.Windows.Forms.RadioButton radioButtonNOVB;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RichTextBox richTextBoxShown;

    }
}

