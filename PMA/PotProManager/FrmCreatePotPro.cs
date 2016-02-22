using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.GlobalCache;
using PMA.Entity;

namespace PMA.PotProManager
{
    public partial class FrmCreatePotPro : DevExpress.XtraEditors.XtraForm
    {
        EntContract currentCn;
        public FrmCreatePotPro()
        {
            InitializeComponent();
            currentCn = null;
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (tb_cn_name.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("请输入合同名", "提示");
                return;
            }
            if (tb_cn_user.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("请输入用户单位", "提示");
                return;
            }
            currentCn = new EntContract();
            currentCn.Cn_num = "";
            currentCn.Cn_name = tb_cn_name.Text;
            currentCn.Cn_plan_in = MyMethod.str2f(tb_cn_plan_in.Text);
            currentCn.Cn_pm = tb_cn_pm.Text;
            currentCn.Cn_total_money = MyMethod.str2f(tb_cn_total_money.Text);
            currentCn.Cn_user = tb_cn_user.Text;

            currentCn.Cn_type = int.Parse(cmb_cn_type.SelectedValue.ToString());
            currentCn.Dept_info = int.Parse(cmb_dept.SelectedValue.ToString());
            currentCn.Cn_sign_date = MyMethod.obj2Date(dp_sign_date.EditValue);

            Db.DbHelper.insertContract(currentCn);
            this.DialogResult = DialogResult.OK;
        }
        public EntContract getCurrentCn()
        {
            return currentCn;
        }
        private void FrmCreatePotPro_Load(object sender, EventArgs e)
        {
            BindingSource bs_type = new BindingSource();
            bs_type.DataSource = CacheData.dic_cn_type;
            cmb_cn_type.DataSource = bs_type;
            cmb_cn_type.ValueMember = "key";
            cmb_cn_type.DisplayMember = "value";
            cmb_cn_type.DropDownStyle = ComboBoxStyle.DropDownList;


            cmb_dept.DropDownStyle = ComboBoxStyle.DropDownList;
            BindingSource bs_dept = new BindingSource();
            bs_dept.DataSource = CacheData.dic_dept_info;
            cmb_dept.DataSource = bs_dept;
            cmb_dept.ValueMember = "key";
            cmb_dept.DisplayMember = "value";
        }
    }
}
