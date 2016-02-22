using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PMA.ProCheck
{
    public partial class ControlProCheck : DevExpress.XtraEditors.XtraUserControl
    {
        public ControlProCheck()
        {
            InitializeComponent();
            tpBack.Controls.Add(new ControlProBackInfo());
            tpCost.Controls.Add(new ControlProCostInfo());
            tpIncome.Controls.Add(new ControlProIncomeInfo());
            tpPotInfo.Controls.Add(new ControlPotProInfo());
            tpExport.Controls.Add(new ControlProExport());
        }
    }
}
