using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.GlobalCache;

namespace PMA
{
    public partial class FrmMain : Form
    {
        PotProManager.ControlPotPro control_pp;
        ProManager.ControlProManager control_pm;
        SpecialManager.ControlSpecialManager control_sm;
        ProCheck.ControlProCheck control_pc;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            CacheData.InitCacheData();
            control_pp = new PotProManager.ControlPotPro();
            control_pp.Dock = DockStyle.Fill;
            control_pm = new ProManager.ControlProManager();
            control_pm.Dock = DockStyle.Fill;
            control_sm = new SpecialManager.ControlSpecialManager();
            control_sm.Dock = DockStyle.Fill;
            control_pc = new ProCheck.ControlProCheck();
            control_pc.Dock = DockStyle.Fill;
        }

        private void btnPotPro_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            panelMain.Controls.Add(control_pp);
        }

        private void btnProManager_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            panelMain.Controls.Add(control_pm);
        }

        private void btnSpecialMananger_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            panelMain.Controls.Add(control_sm);
        }

        private void btnProCheck_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();
            panelMain.Controls.Add(control_pc);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
