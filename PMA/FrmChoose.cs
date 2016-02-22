using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.Entity;
using PMA.Db;
using PMA.GlobalCache;

namespace PMA
{
    public partial class FrmChoose : DevExpress.XtraEditors.XtraForm
    {
        public long Cn_id { get; set; }
        public FrmChoose()
        {
            InitializeComponent();
            
            dgv.GroupPanelText = "请选择合同";
            dgv.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            dgv.OptionsBehavior.Editable = false;
            dgv.OptionsMenu.EnableColumnMenu = false;
            dgv.OptionsMenu.EnableGroupPanelMenu = false;

            List<string> str_columns = CacheData.dic_table[CacheData.CHOOSE_EXPORT];

            DevExpress.XtraGrid.Columns.GridColumn id_column = new DevExpress.XtraGrid.Columns.GridColumn();
            id_column.FieldName = "id";
            id_column.Visible = false;
            dgv.Columns.Add(id_column);

            foreach (string str_colum in str_columns)
            {
                DevExpress.XtraGrid.Columns.GridColumn grid_column = new DevExpress.XtraGrid.Columns.GridColumn();
                grid_column.Caption = CacheData.dic_column[str_colum];
                grid_column.FieldName = str_colum;
                grid_column.Visible = true;
                grid_column.VisibleIndex = dgv.Columns.Count;

                grid_column.OptionsFilter.AllowAutoFilter = false;
                grid_column.OptionsFilter.AllowFilter = false;
                grid_column.OptionsFilter.ImmediateUpdateAutoFilter = false;

                dgv.Columns.Add(grid_column);
            }
        }

        private void bindData(DataTable dt)
        {
            gridControl1.DataSource = dt;
        }

        public static EntContract getContract(string attr, string val, bool hasNumber)
        {
            DataTable dt = DbHelper.GetLstSimpleCnByAttrLike(attr, val, false);
            if (null == dt || dt.Rows.Count == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("找不到合同","提示");
                return null;
            }
            long cn_id = -1;
            EntContract cn =null;
            if (dt.Rows.Count > 1)
            {
                FrmChoose frm = new FrmChoose();
                frm.bindData(dt);
                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    cn_id = frm.Cn_id;
                }
            }
            if (-1 != cn_id)
            {
                DbHelper.getEntConstById(cn_id , out cn);                
            }
            return cn;                 
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            int row = dgv.FocusedRowHandle;
            Cn_id = long.Parse(dgv.GetRowCellValue(row, dgv.Columns["id"]).ToString());
        }
    }
}
