using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PMA.Entity;
using PMA.Db;

namespace PMA.GlobalCache
{
    class CacheData
    {
        public static List<EntCostPara> lst_plan_cost_para;
        public static List<EntCostPara> lst_real_cost_para;
        public static Dictionary<int, string> dic_cn_type;
        public static Dictionary<int, string> dic_cn_nature;
        public static Dictionary<int, string> dic_dept_info;

        public static Dictionary<string, string> dic_column;
        public static Dictionary<int, List<string>> dic_table;

        //public static List<int> months;

        public const int CHOOSE_EXPORT = 1;
        public const int SHOW_EXPORT = 2;
        public const int BACK_EXPORT = 3;
        public const int IN_EXPORT = 4;
        public const int SIGN_EXPORT = 5;
        public const int OUT_EXPORT = 6;
        public const int NUM_EXPORT = 7;
        public const int COST_EXPORT = 8;
        public const int PLAN_EXPORT = 9;

        public static void InitCacheData()
        {
            #region 成本要素信息
            lst_plan_cost_para = new List<EntCostPara>();
            lst_real_cost_para = new List<EntCostPara>();
            DataTable dt_cost_para = DbHelper.GetTableInfo("cost_para_tbl");
            if (null != dt_cost_para && dt_cost_para.Rows.Count > 0)
            {
                foreach (DataRow dr in dt_cost_para.Rows)
                {
                    EntCostPara cost_para = new EntCostPara();
                    cost_para.Cost_para_id = int.Parse(dr["cost_para_id"].ToString());
                    cost_para.Group_id = int.Parse(dr["group_id"].ToString());
                    cost_para.Cost_para_name = dr["cost_para_name"].ToString();
                    cost_para.Cost_link_id = int.Parse(dr["cost_link_id"].ToString());
                    if (cost_para.Group_id == 0)
                    {
                        lst_plan_cost_para.Add(cost_para);
                    }
                    else
                    {
                        lst_real_cost_para.Add(cost_para);
                    }
                }
            }

            #endregion
            #region 合同性质信息
            dic_cn_nature = new Dictionary<int, string>();
            DataTable dt_cn_nature = DbHelper.GetTableInfo("cn_nature_tbl");
            if (null != dt_cn_nature && dt_cn_nature.Rows.Count > 0)
            {
                foreach (DataRow dr in dt_cn_nature.Rows)
                {
                    int cn_nature_id = int.Parse(dr["cn_nature_id"].ToString());
                    string cn_nature_name = dr["cn_nature_name"].ToString();
                    dic_cn_nature.Add(cn_nature_id, cn_nature_name);
                }
            }

            #endregion
            #region 合同类型信息
            dic_cn_type = new Dictionary<int, string>();
            DataTable dt_cn_type = DbHelper.GetTableInfo("cn_type_tbl");
            if (null != dt_cn_type && dt_cn_type.Rows.Count > 0)
            {
                foreach (DataRow dr in dt_cn_type.Rows)
                {                  
                    int cn_type_id = int.Parse(dr["cn_type_id"].ToString());
                    string cn_type_name = dr["cn_type_name"].ToString();
                    dic_cn_type.Add(cn_type_id, cn_type_name);
                }
            }

            #endregion

            #region 部门信息
            dic_dept_info = new Dictionary<int, string>();
            DataTable dt_dept_info = DbHelper.GetTableInfo("dept_info_tbl");
            if (null != dt_dept_info && dt_dept_info.Rows.Count > 0)
            {
                foreach (DataRow dr in dt_dept_info.Rows)
                {                   
                    int dept_id = int.Parse(dr["dept_id"].ToString());
                    string dept_name = dr["dept_name"].ToString();
                    dic_dept_info.Add(dept_id, dept_name);
                }
            }
            #endregion
            #region 字段映射信息
            dic_column = new Dictionary<string, string>();
            DataTable column_map_info = DbHelper.GetTableInfo("cn_map_tbl");
            if (null != column_map_info && column_map_info.Rows.Count > 0)
            {
                foreach (DataRow dr in column_map_info.Rows)
                {
                    dic_column.Add(dr["attr_name"].ToString(), dr["attr_desc"].ToString());
                }
            }
            #endregion

            #region 表信息
            dic_table = new Dictionary<int, List<string>>();
            DataTable dt_info = DbHelper.GetTableInfo("cn_table_column_tbl");
            if (null != dt_info && dt_info.Rows.Count > 0)
            {
                foreach (DataRow dr in dt_info.Rows)
                {
                    int key = Convert.ToInt16(dr["table_id"].ToString());
                    if (dic_table.ContainsKey(key))
                    {
                        List<string> lstVal = dic_table[key];
                        lstVal.Add(dr["attr_name"].ToString());
                        dic_table[key] = lstVal;
                    }
                    else
                    {
                        List<string> lstVal = new List<string>();
                        lstVal.Add(dr["attr_name"].ToString());
                        dic_table.Add(key, lstVal);
                    }
                }
            }
            #endregion

          /*  months = new List<int>();
            for (int i = 0; i < 12; i++)
            {
                months.Add(i + 1);
            }
           * */
        }
    }
}
