using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PMA.ProManager
{
    public partial class ControlProManager : DevExpress.XtraEditors.XtraUserControl
    {
        public ControlProManager()
        {
            InitializeComponent();
        }
   
        private void btn_add_Click(object sender, EventArgs e)
        {
            FrmCreatePro frm = new FrmCreatePro();
            frm.ShowDialog();
        }
    }
}
