using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PMA.Entity;
using PMA.GlobalCache;

namespace PMA.Db
{
    class DbHelper
    {      
        public static bool insertContract(EntContract cn)
        {
            try
            {
                string sql = string.Format(@"insert into cn_info_tbl (
                                            cn_num
                                            ,cn_name
                                            ,cn_user
                                            ,cn_nature
                                            ,cn_type
                                            ,dept_info
                                            ,cn_pm
                                            ,cn_total_money
                                            ,cn_sign_date
                                            ,cn_plan_in
                                            ,cn_plan_cmpl_date
                                            ,cn_plan_close_date
                                            ,cn_plan_back_date1
                                            ,cn_plan_back_money1
                                            ,cn_plan_back_date2
                                            ,cn_plan_back_money2
                                            ,cn_plan_back_date3
                                            ,cn_plan_back_money3) 
                                            values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)");
                WhnrContext.Db.ExecuteNonQuery(sql
                    , cn.Cn_num
                    , cn.Cn_name
                    , cn.Cn_user
                    , cn.Cn_nature
                    , cn.Cn_type
                    , cn.Dept_info
                    , cn.Cn_pm
                    , cn.Cn_total_money
                    , MyMethod.date2str(cn.Cn_sign_date)
                    , cn.Cn_plan_in
                    , MyMethod.date2str(cn.Cn_plan_cmpl_date)
                    , MyMethod.date2str(cn.Cn_plan_close_date)
                    , MyMethod.date2str(cn.Cn_plan_back_date1)
                    , cn.Cn_plan_back_money1
                    , MyMethod.date2str(cn.Cn_plan_back_date2)
                    , cn.Cn_plan_back_money2
                    , MyMethod.date2str(cn.Cn_plan_back_date3)
                    , cn.Cn_plan_back_money3);
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }

        }

        public static void updateCost(EntContract cn)
        {
            try
            {
                string sql_del_cost = string.Format("delete from cn_cost_tbl where cn_id = {0}", cn.Id);
                WhnrContext.Db.ExecuteNonQuery(sql_del_cost);
                string sql_update_cn = string.Format(@"update cn_info_tbl set cn_plan_gpr = {1}
                    ,cn_real_gpr = {2}
                    ,cn_sale_gpr = {3}
                    ,cn_co_cost = {4}
                    ,cn_acc_cost = {5}
                    ,cn_acc_cfm_cost = {6}
                    ,cn_real_cost = {7} 
                    ,cn_plan_cost = {8} 
                     where id = {0}"
                    , cn.Id
                    , cn.Cn_plan_gpr 
                    , cn.Cn_real_gpr 
                    , cn.Cn_sale_gpr
                    , cn.Cn_co_cost 
                    , cn.Cn_acc_cost 
                    , cn.Cn_acc_cfm_cost
                    , cn.Cn_real_cost
                    , cn.Cn_plan_cost
                    );
                WhnrContext.Db.ExecuteNonQuery(sql_update_cn);
                string sql_insert_cost = string.Format(@"insert into cn_cost_tbl(cn_id , cost_para_id ,cost_val ) values (?,?,?)");
                foreach (int key in cn.Dic_cn_cost.Keys)
                {
                    WhnrContext.Db.ExecuteNonQuery(sql_insert_cost, cn.Id, key, cn.Dic_cn_cost[key]);
                }

            }
            catch (System.Exception ex)
            {
            	
            }
        }

        public static DataTable GetLstCnByMonth(List<string> search_reason , int month)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("select * from cn_info_tbl where ");
                sb.Append(string.Format(" DATEPART(m,{0})={1}" , search_reason[0] , month));
                for (int i = 1; i < search_reason.Count; i++)
                {
                    sb.Append(string.Format(" or DATEPART(m,{0})={1}", search_reason[i], month));        
                }
                string sql = sb.ToString();
                DataTable dt = WhnrContext.Db.GetDataTable(sql);
                return dt;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        public static DataTable GetLstCnByDate(List<string> search_reason, DateTime date)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("select * from cn_info_tbl where ");
                sb.Append(string.Format(" {0}='{1}'", search_reason[0], MyMethod.date2str(date)));
                for (int i = 1; i < search_reason.Count; i++)
                {
                    sb.Append(string.Format(" or {0}='{1}'", search_reason[i], MyMethod.date2str(date)));
                }
                string sql = sb.ToString();
                DataTable dt = WhnrContext.Db.GetDataTable(sql);
                return dt;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static bool updateContract(EntContract cn)
        {
            try
            {
                string sql = string.Format(@"update cn_info_tbl set
                                            cn_num = ?
                                            ,cn_name = ?
                                            ,cn_user = ?
                                            ,cn_nature = ?
                                            ,cn_type = ?
                                            ,dept_info = ?
                                            ,cn_pm = ?
                                            ,cn_total_money = ?
                                            ,cn_sign_date = ?
                                            ,cn_plan_in = ?
,cn_total_bill = ?
,cn_has_bill = ?

                                            ,cn_plan_cmpl_date = ?
                                            ,cn_plan_close_date = ?
                                            ,cn_plan_back_date1 = ?
                                            ,cn_plan_back_money1 = ?
                                            ,cn_plan_back_date2 = ?
                                            ,cn_plan_back_money2 = ?
                                            ,cn_plan_back_date3 = ?
                                            ,cn_plan_back_money3 = ? 
,cn_back_money = ?
,cn_back_rate = ?
,cn_in = ?
,cn_in_rate = ?
,cn_plan_out_date1 = ?
,cn_plan_out_money1 = ?
,cn_plan_out_date2 = ?
,cn_plan_out_money2 = ?
,cn_plan_out_date3 = ?
,cn_plan_out_money3 = ?
,cn_nxt_in_date = ?
,cn_nxt_in_money = ?
where id = ?");
                WhnrContext.Db.ExecuteNonQuery(sql
                    , cn.Cn_num
                    , cn.Cn_name
                    , cn.Cn_user
                    , cn.Cn_nature
                    , cn.Cn_type
                    , cn.Dept_info
                    , cn.Cn_pm
                    , cn.Cn_total_money
                    , MyMethod.date2str(cn.Cn_sign_date)
                    , cn.Cn_plan_in
                    , cn.Cn_total_bill
                    , cn.Cn_has_bill
                    , MyMethod.date2str(cn.Cn_plan_cmpl_date)
                    , MyMethod.date2str(cn.Cn_plan_close_date)
                    , MyMethod.date2str(cn.Cn_plan_back_date1)
                    , cn.Cn_plan_back_money1
                    , MyMethod.date2str(cn.Cn_plan_back_date2)
                    , cn.Cn_plan_back_money2
                    , MyMethod.date2str(cn.Cn_plan_back_date3)
                    , cn.Cn_plan_back_money3
                    , cn.Cn_back_money
                    , cn.Cn_back_rate
                    , cn.Cn_in
                    , cn.Cn_in_rate
                    , MyMethod.date2str(cn.Cn_plan_out_date1)
                    , cn.Cn_plan_out_money1
                    , MyMethod.date2str(cn.Cn_plan_out_date2)
                    , cn.Cn_plan_out_money2
                    , MyMethod.date2str(cn.Cn_plan_out_date3)
                    , cn.Cn_plan_out_money3
                    , MyMethod.date2str(cn.Cn_nxt_in_date)
                    , cn.Cn_nxt_in_money
                    , cn.Id);
                return true;
            }
            catch
            {
                return false;
                
            }
        }

        public static bool delContract(EntContract cn)
        {
            try
            {
                string sql = string.Format(@"delete from cn_info_tbl  where id = ?");
                WhnrContext.Db.ExecuteNonQuery(sql                   
                    , cn.Id);
                sql = string.Format(@"delete from cn_cost_tbl  where cn_id = ?");
                WhnrContext.Db.ExecuteNonQuery(sql
                   , cn.Id);
                sql = string.Format(@"delete from pot_cn_pro_tbl  where cn_id = ?");
                WhnrContext.Db.ExecuteNonQuery(sql
                   , cn.Id);
                return true;
            }
            catch
            {
                return false;

            }
        }
        /// <summary>
        /// 获取简单信息，主要供选择
        /// </summary>
        /// <param name="attr"></param>
        /// <param name="val"></param>
        /// <param name="hasNumber">有无合同号，即合同是否已签订</param>
        /// <returns></returns>
        public static DataTable GetLstSimpleCnByAttrLike(string attr, string val , bool hasNumber)
        {
            try
            {
                List<string> str_columns = CacheData.dic_table[CacheData.CHOOSE_EXPORT];
                StringBuilder sb = new StringBuilder();
                sb.Append("select id ");
                foreach(string str_col in str_columns)
                {
                    sb.Append(",");
                    sb.Append(str_col);
                }
                sb.Append(" from cn_info_tbl where ").Append(attr).Append(" like '%").Append(val).Append("%'");

                if (hasNumber)
                {
                    sb.Append(" and cn_num!=''");
                }
                else
                {
                    sb.Append(" and cn_num=''");
                }
                string sql = sb.ToString();
                DataTable dt = WhnrContext.Db.GetDataTable(sql);
                return dt;
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }
        /// <summary>
        /// 获取合同详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hasNumber"></param>
        /// <returns></returns>
        public static void getEntConstById(long id , out EntContract ent)
        {
            string sql_cn = string.Format("select * from cn_info_tbl where id = {0}", id);
            DataTable dt_cn = WhnrContext.Db.GetDataTable(sql_cn);
            if (null == dt_cn || dt_cn.Rows.Count == 0)
            {
                ent = null;
                return;
            }
            ent = new EntContract();
            ent.Id = id;
            {
                DataRow dr = dt_cn.Rows[0];
                ent.Cn_num = dr["cn_num"].ToString().Trim();
                ent.Cn_name = dr["cn_name"].ToString().Trim();
                ent.Cn_user = dr["cn_user"].ToString().Trim();
                ent.Cn_nature = int.Parse(dr["cn_nature"].ToString());
                ent.Cn_type = int.Parse(dr["cn_type"].ToString());
                ent.Dept_info = int.Parse(dr["dept_info"].ToString());
                ent.Cn_pm = dr["cn_pm"].ToString().Trim();
                ent.Cn_total_money = MyMethod.str2f(dr["cn_total_money"].ToString());
                ent.Cn_sign_date = MyMethod.str2Date(dr["cn_sign_date"].ToString());
                ent.Cn_plan_in = MyMethod.str2f(dr["cn_plan_in"].ToString());
                ent.Cn_total_bill = MyMethod.str2f(dr["cn_total_bill"].ToString());
                ent.Cn_has_bill = MyMethod.str2f(dr["cn_has_bill"].ToString());
                ent.Cn_plan_cmpl_date = MyMethod.str2Date(dr["cn_plan_cmpl_date"].ToString());
                ent.Cn_plan_close_date = MyMethod.str2Date(dr["cn_plan_close_date"].ToString());

                ent.Cn_plan_back_date1 = MyMethod.str2Date(dr["cn_plan_back_date1"].ToString());
                ent.Cn_plan_back_money1 = MyMethod.str2f(dr["cn_plan_back_money1"].ToString());
                ent.Cn_plan_back_date2 = MyMethod.str2Date(dr["cn_plan_back_date2"].ToString());
                ent.Cn_plan_back_money2 = MyMethod.str2f(dr["cn_plan_back_money2"].ToString());
                ent.Cn_plan_back_date3 = MyMethod.str2Date(dr["cn_plan_back_date3"].ToString());
                ent.Cn_plan_back_money3 = MyMethod.str2f(dr["cn_plan_back_money3"].ToString());

                ent.Cn_back_money = MyMethod.str2f(dr["cn_back_money"].ToString());
                ent.Cn_back_rate = MyMethod.str2f(dr["cn_back_rate"].ToString());
                ent.Cn_in = MyMethod.str2f(dr["cn_in"].ToString());
                ent.Cn_in_rate = MyMethod.str2f(dr["cn_in_rate"].ToString());

                ent.Cn_plan_out_date1 = MyMethod.str2Date(dr["cn_plan_out_date1"].ToString());
                ent.Cn_plan_out_money1 = MyMethod.str2f(dr["cn_plan_out_money1"].ToString());
                ent.Cn_plan_out_date2 = MyMethod.str2Date(dr["cn_plan_out_date2"].ToString());
                ent.Cn_plan_out_money2 = MyMethod.str2f(dr["cn_plan_out_money2"].ToString());
                ent.Cn_plan_out_date3 = MyMethod.str2Date(dr["cn_plan_out_date3"].ToString());
                ent.Cn_plan_out_money3 = MyMethod.str2f(dr["cn_plan_out_money3"].ToString());
                ent.Cn_nxt_in_date = MyMethod.str2Date(dr["cn_nxt_in_date"].ToString());
                ent.Cn_nxt_in_money = MyMethod.str2f(dr["cn_nxt_in_money"].ToString());

                ent.Cn_plan_gpr = MyMethod.str2f(dr["cn_plan_gpr"].ToString());
                ent.Cn_real_gpr = MyMethod.str2f(dr["cn_real_gpr"].ToString());
                ent.Cn_sale_gpr = MyMethod.str2f(dr["cn_sale_gpr"].ToString());
                ent.Cn_co_cost = MyMethod.str2f(dr["cn_co_cost"].ToString());
                ent.Cn_acc_cost = MyMethod.str2f(dr["cn_acc_cost"].ToString());
                ent.Cn_acc_cfm_cost = MyMethod.str2f(dr["cn_acc_cfm_cost"].ToString());
                ent.Cn_real_cost = MyMethod.str2f(dr["cn_real_cost"].ToString());
                ent.Cn_plan_cost = MyMethod.str2f(dr["cn_plan_cost"].ToString());
            }
            if (ent.Cn_num == "") //待签合同，查看进度信息
            {
                string sql_cn_pro = string.Format("select Update_time ,Update_content  from pot_cn_pro_tbl where cn_id = {0}", id);
               // DataTable dt_cn_pro = WhnrContext.Db.GetDataTable(sql_cn_pro);
                ent.Dt_progress = WhnrContext.Db.GetDataTable(sql_cn_pro);
                /*if (null == dt_cn_pro || dt_cn_pro.Rows.Count == 0)
                {
                    return;
                }
                foreach (DataRow dr in dt_cn_pro.Rows)
                {
                    EntCnProgress cn_pro = new EntCnProgress();
                    cn_pro.Update_time = dr["update_time"].ToString();
                    cn_pro.Update_content = dr["update_content"].ToString();
                    ent.AddProgress(cn_pro);
                }
                 * */
            }
            else
            { 
            
            }

        }
        public static DataTable GetLstCnByAttrLike(string attr, string val)
        {
            try
            {
                string sql = string.Format("select * from cn_info_tbl where {0} like '%{1}%'" , attr , val);
                DataTable dt = WhnrContext.Db.GetDataTable(sql);
                return dt;
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }
        public static DataTable GetLstCnByDept(int dept_id)
        {
            try
            {
                string sql = string.Format("select * from cn_info_tbl where dept_info = ?");
                DataTable dt = WhnrContext.Db.GetDataTable(sql , dept_id );
                return dt;
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }
        public static DataTable GetLstCnByNum(string[] lst_num)
        {
            try
            {
                if (lst_num.Length == 0)
                {
                    return null;
                }
                StringBuilder sb = new StringBuilder();
                sb.Append("select * from cn_info_tbl where cn_num = '");
                sb.Append(lst_num[0].Trim());
                sb.Append("'");
                for (int i = 1; i < lst_num.Length; i++ )
                {
                    if (lst_num[i].Trim() != "")
                    {
                        sb.Append(" or cn_num ='");
                        sb.Append(lst_num[i].Trim());
                        sb.Append("'");

                    }                   
                }
                string sql = sb.ToString();
                DataTable dt = WhnrContext.Db.GetDataTable(sql);
                return dt;
            }
            catch (System.Exception ex)
            {
                return null;
            }


        }

        public static DataTable GetLstCnCostByCnId(long cn_id )
        {
            try
            {
                /*
                string sql = string.Format(@"select a.cost_para_id ,a.cost_val ,b.cost_para_name from cn_cost_tbl as a ,cost_para_tbl as b
 where a.cn_id = {0} and a.cost_para_id = b.cost_para_id and a.cost_para_id in(select cost_para_id from cost_para_tbl where group_id = 0)", cn_id, group_id);
                */
                string sql = string.Format(@"select a.cost_para_id , b.cost_para_name , a.cost_val ,  b.group_id from cn_cost_tbl as a ,cost_para_tbl as b
                 where cn_id = {0} and a.cost_para_id = b.cost_para_id", cn_id);
                DataTable dt = WhnrContext.Db.GetDataTable(sql);
                return dt;
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }

        public static DataTable GetLstCnCostByCostId(int cost_para_id)
        {
            try
            {
                /*
                string sql = string.Format(@"select a.cost_para_id ,a.cost_val ,b.cost_para_name from cn_cost_tbl as a ,cost_para_tbl as b
 where a.cn_id = {0} and a.cost_para_id = b.cost_para_id and a.cost_para_id in(select cost_para_id from cost_para_tbl where group_id = 0)", cn_id, group_id);
                */
                string sql = string.Format(@"select b.cn_num , a.cost_val from cn_cost_tbl as a ,cn_info_tbl as b
                 where a.cost_para_id = {0} and a.cn_id = b.id", cost_para_id);
                DataTable dt = WhnrContext.Db.GetDataTable(sql);
                return dt;
            }
            catch (System.Exception ex)
            {
                return null;
            }

        }

        public static DataTable GetUserInfo(string userName)
        {
            try
            {
                string sql = string.Format(@"select * from user_info_tbl where user_name=?");
                DataTable dt = WhnrContext.Db.GetDataTable(sql, userName);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        //获取数据库某个表所有信息
        public static DataTable GetTableInfo(string tableName)
        {
            try
            {
                string sql = string.Format("select * from {0}" , tableName);
                DataTable dt = WhnrContext.Db.GetDataTable(sql);
                return dt;
            }
            catch
            {
                return null;
            }
        }
    }

}
