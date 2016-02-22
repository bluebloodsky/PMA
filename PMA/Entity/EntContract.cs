using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PMA.Entity
{
    public class EntContract
    {
        public long Id{get;set;}
        public string Cn_num { get; set; }
        public string Cn_name { get; set; }
        public string Cn_user { get; set; }
        public int Cn_nature { get; set; }
        public int Cn_type { get; set; }
        public int Dept_info { get; set; }
        public string Cn_pm { get; set; }
        public float Cn_total_money { get; set; }
        public DateTime Cn_sign_date { get; set; }
        public float Cn_plan_in { get; set; }
        public float Cn_total_bill { get; set; }
        public float Cn_has_bill { get; set; }
        public DateTime Cn_plan_cmpl_date{ get; set; }
        public DateTime Cn_plan_close_date{ get; set; }

        public DateTime Cn_plan_back_date1{ get; set; }
        public float Cn_plan_back_money1{ get; set; }
        public DateTime Cn_plan_back_date2{ get; set; }
        public float Cn_plan_back_money2{ get; set; }
        public DateTime Cn_plan_back_date3{ get; set; }
        public float Cn_plan_back_money3{ get; set; }

        public float Cn_back_money{ get; set; }
        public float Cn_back_rate{ get; set; }
        public float Cn_in{ get; set; }
        public float Cn_in_rate{ get; set; }

        public DateTime Cn_plan_out_date1{ get; set; }
        public float Cn_plan_out_money1{ get; set; }
        public DateTime Cn_plan_out_date2{ get; set; }
        public float Cn_plan_out_money2{ get; set; }
        public DateTime Cn_plan_out_date3{ get; set; }
        public float Cn_plan_out_money3{ get; set; }

        public DateTime Cn_nxt_in_date{ get; set; }
        public float Cn_nxt_in_money{ get; set; }

        public float Cn_plan_gpr{ get; set; }
        public float Cn_real_gpr{ get; set; }
        public float Cn_sale_gpr{ get; set; }
        public float Cn_co_cost{ get; set; }
        public float Cn_acc_cost { get; set; }
        public float Cn_acc_cfm_cost { get; set; }
        public float Cn_real_cost { get; set; }
        public float Cn_plan_cost { get; set; }

        public DataTable Dt_progress { get; set; }
        public List<EntCnProgress> Lst_pro_progress { get; set; }
        public void AddProgress(EntCnProgress ent)
        {
            if (null == Lst_pro_progress)
            {
                Lst_pro_progress = new List<EntCnProgress>();
            }
            Lst_pro_progress.Add(ent);
        }
        public Dictionary<int, float> Dic_cn_cost{get ; set ; }
    }
    public class EntCnProgress
    {
        public string Update_time { get; set; }
        public string Update_content { get; set; }
    }
    public class EntCnCost
    {
        public int Cost_para_id { get; set; }
        public float Cost_val { get; set; }
    }
    public class EntCostPara
    {
        public int Cost_para_id { get; set; }
        public int Group_id { get; set; }
        public string Cost_para_name { get; set; }
        public int Cost_link_id { get; set; }        
    }
    /*
    public class EntCnNature
    {
        public int Cn_nature_id { get; set; }
        public string Cn_nature_name { get; set; }
    }
    public class EntCnType
    {
        public int Cn_type_id { get; set; }
        public string Cn_type_name { get; set; }
    }
    public class EntDeptInfo
    {
        public int Dept_id { get; set; }
        public string Dept_name { get; set; }
    }
    */
    public class CnAttr
    {
        public string AttrName { get; set; }
        public string AttrDesc { get; set; }
    }
}
