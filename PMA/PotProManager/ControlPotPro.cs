using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PMA.GlobalCache;
using PMA.Entity;

namespace PMA.PotProManager
{
    public partial class ControlPotPro : DevExpress.XtraEditors.XtraUserControl
    {
        private EntContract currentCn;
        public ControlPotPro()
        {
            InitializeComponent();
        }

        private void PotPro_Load(object sender, EventArgs e)
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

        private void btn_add_Click(object sender, EventArgs e)
        {
            FrmCreatePotPro frm = new FrmCreatePotPro();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                currentCn = frm.getCurrentCn();
                loadCnInfo();
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string attr, val;
            {
                attr = "cn_name";
                val = tb_search_name.Text.Trim();
            }
          
            currentCn = FrmChoose.getContract(attr, val , false);
            if (null == currentCn)
            {
                return;
            }
            loadCnInfo();
        }

        private void loadCnInfo()
        {
            tb_cn_name.Text = currentCn.Cn_name;
            tb_cn_plan_in.Text = currentCn.Cn_plan_in.ToString();
            tb_cn_pm.Text = currentCn.Cn_pm;
            tb_cn_total_money.Text = currentCn.Cn_total_money.ToString();
            tb_cn_user.Text = currentCn.Cn_user;

            cmb_cn_type.SelectedValue = currentCn.Cn_type;
            cmb_dept.SelectedValue = currentCn.Dept_info;
            dp_sign_date.EditValue = currentCn.Cn_sign_date;

            gridcontrol.DataSource = currentCn.Dt_progress;
            btn_pro_mod.Enabled = true;
            btn_pro_del.Enabled = true;
            btn_add_progress.Enabled = true;
        }

        private void btn_pro_mod_Click(object sender, EventArgs e)
        {
            currentCn.Cn_name = tb_cn_name.Text ;
            currentCn.Cn_plan_in = MyMethod.str2f(tb_cn_plan_in.Text);
            currentCn.Cn_pm = tb_cn_pm.Text ;
            currentCn.Cn_total_money = MyMethod.str2f(tb_cn_total_money.Text);
            currentCn.Cn_user =  tb_cn_user.Text ;

            currentCn.Cn_type = int.Parse(cmb_cn_type.SelectedValue.ToString()) ;
            currentCn.Dept_info = int.Parse(cmb_dept.SelectedValue.ToString());
            currentCn.Cn_sign_date = MyMethod.obj2Date(dp_sign_date.EditValue);

            Db.DbHelper.updateContract(currentCn);
        }

        private void btn_pro_del_Click(object sender, EventArgs e)
        {
            Db.DbHelper.delContract(currentCn);
        }

        private void btn_add_progress_Click(object sender, EventArgs e)
        {
            dgv_pro_progress.AddNewRow();
           /* EntCnProgress newProgress = new EntCnProgress();
            newProgress.Update_time = DateTime.Now.ToString();
            newProgress.Update_content = "";
            currentCn.Lst_pro_progress.Add(newProgress);
            gridcontrol.DataSource = currentCn.Lst_pro_progress;
            * */
        }
    }
}
