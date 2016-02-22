using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Isoms.Entity;

namespace ReportExcel
{
    public class HistoryDataHelper
    {
        public static DataTable getGasHistory(DateTime dtBegin, DateTime dtEnd)
        {
            try
            {
                string sql = string.Format(
                @"SELECT Data_time, GAS_H2, GAS_CH4,GAS_C2H4,GAS_C2H2,GAS_C2H6, GAS_CO,
        GAS_CO2,Water_Vapor_Content
                FROM GAS_DATA
                WHERE (Data_Time >= ?) AND (Data_Time <= ?) 
                ORDER BY DATA_TIME"
                );
                DataTable dt = IsoContext.IsoDb.GetDataTable(sql, dtBegin, dtEnd);
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        dr["GAS_H2"] = float.Parse(dr["GAS_H2"].ToString()).ToString("F0");
                        dr["GAS_CO"] = float.Parse(dr["GAS_CO"].ToString()).ToString("F0");
                        dr["GAS_CH4"] = float.Parse(dr["GAS_CH4"].ToString()).ToString("F0");
                        dr["GAS_C2H4"] = float.Parse(dr["GAS_C2H4"].ToString()).ToString("F1");
                        dr["GAS_C2H6"] = float.Parse(dr["GAS_C2H6"].ToString()).ToString("F1");
                        dr["GAS_C2H2"] = float.Parse(dr["GAS_C2H2"].ToString()).ToString("F1");
                        dr["GAS_CO2"] = float.Parse(dr["GAS_H2"].ToString()).ToString("F0");
                        dr["Water_Vapor_Content"] = float.Parse(dr["Water_Vapor_Content"].ToString()).ToString("F0");
                    }
                    catch {
                        
                    }

                }
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static DataTable getBushingHistory(DateTime dtBegin, DateTime dtEnd)
        {
            try
            {
                string sql = string.Format(
@"SELECT  Remark,Data_Time,Vol, leakA,LosFact,EquCa             
FROM     B_DATA a,B_SIGNAL_PARAMETER b
WHERE     (a.Data_Time > ?) AND (a.Data_Time < ?) and (a.Signal_ID=b.Signal_ID)
ORDER BY Data_Time DESC"
                    );
                DataTable dt = IsoContext.IsoDb.GetDataTable(sql, dtBegin, dtEnd);
                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 2; i < 6; i++)
                    {
                        try
                        {
                            dr["Vol"] = float.Parse(dr["Vol"].ToString()).ToString("F3");
                            dr["leakA"] = float.Parse(dr["leakA"].ToString()).ToString("F3");
                            dr["LosFact"] = float.Parse(dr["LosFact"].ToString()).ToString("F3");
                            dr["EquCa"] = float.Parse(dr["EquCa"].ToString()).ToString("F3");
                        }
                        catch
                        { }
                    }                    
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static DataTable getPDHistory(DateTime dtBegin, DateTime dtEnd)
        {
            try
            {
                string sql = string.Format(
@"SELECT  Remark,Data_Time,Chan_peak *1000 as Chan_peak,PlsNum                
FROM     HVM_DATA a,HVM_SIGNAL_PARAMETER b
WHERE     (a.Data_Time > ?) AND (a.Data_Time < ?) and (a.Signal_ID=b.Signal_ID)
ORDER BY Data_Time"
                    );
                DataTable dt = IsoContext.IsoDb.GetDataTable(sql, dtBegin, dtEnd);
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        dr["Chan_peak"] = float.Parse(dr["Chan_peak"].ToString()).ToString("F0");                       
                    }
                    catch (Exception ex) { }
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static DataTable getCoreHistory(DateTime dtBegin, DateTime dtEnd)
        {
            try
            {
                string sql = string.Format(
                        @"SELECT  Data_Time,Amp               
                        FROM     CORE_DATA
                        WHERE     (Data_Time > ?) AND (Data_Time < ?) 
                        ORDER BY Data_Time"
                    );
                DataTable dt = IsoContext.IsoDb.GetDataTable(sql, dtBegin, dtEnd);
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        dr["Amp"] = float.Parse(dr["Amp"].ToString()).ToString("F3");
                    }
                    catch { }
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static DataTable getVCHistory(DateTime dtBegin, DateTime dtEnd)
        {
            try
            {
                string sql = string.Format(
                @"SELECT  b.Signal_Project_Name ,a.*            
                FROM     VC_DATA a,VC_SIGNAL_PARAMETER b
                WHERE     (a.Data_Time > ?) AND (a.Data_Time < ?) and (a.Signal_ID=b.Signal_ID)
                ORDER BY Data_Time"
                    );
                DataTable dt = IsoContext.IsoDb.GetDataTable(sql, dtBegin, dtEnd);
                dt.Columns.RemoveAt(1);
                dt.Columns.RemoveAt(1);
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                         for (int i = 2; i < 20; i++)
                         {                        
                            dr[i] = float.Parse(dr[i].ToString()).ToString("F2");                       
                         }
                    }
                    catch { }
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static DataTable getRemoteMHistory(DateTime dtBegin, DateTime dtEnd)
        {
            try
            {
                string sql = string.Format(
@"SELECT  *                
FROM     REMOTE_M_DATA
WHERE     (Data_Time > ?) AND (Data_Time < ?) 
ORDER BY Data_Time"
                    );
                DataTable dt = IsoContext.IsoDb.GetDataTable(sql, dtBegin, dtEnd);
                dt.Columns.RemoveAt(0);
                dt.Columns.RemoveAt(0);
                for (int i = 0; i < 13; i++)
                {
                    dt.Columns.RemoveAt(dt.Columns.Count-1);
                }
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        for (int i = 2; i < 20; i++)
                        {
                            dr[i] = float.Parse(dr[i].ToString()).ToString("F2");
                        }
                    }
                    catch { }
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            };
        }

        public static DataTable getRemoteSHistory(DateTime dtBegin, DateTime dtEnd)
        {
            try
            {
                string sql = string.Format(
@"SELECT  *               
FROM   Remote_S_DATA
WHERE     (Data_Time > ?) AND (Data_Time < ?) 
ORDER BY Data_Time"
                    );
                DataTable dt = IsoContext.IsoDb.GetDataTable(sql, dtBegin, dtEnd);
                dt.Columns.RemoveAt(0);
                dt.Columns.RemoveAt(0);                
                for (int i = 0; i < 7; i++)
                {
                    dt.Columns.RemoveAt(dt.Columns.Count - 1);
                }                
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static DataTable getNEUTRALPTHistory(DateTime dtBegin, DateTime dtEnd)
        {
            try
            {
                string sql = string.Format(
                    @"SELECT  b.Remark ,a.Data_Time,Amp          
                    FROM     NEUTRALPT_DATA a,NEUTRALPT_SIGNAL_PARAMETER b
                    WHERE     (a.Data_Time > ?) AND (a.Data_Time < ?) and (a.Signal_ID=b.Signal_ID)
                    ORDER BY Data_Time"
                    );
                DataTable dt = IsoContext.IsoDb.GetDataTable(sql, dtBegin, dtEnd);
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        dr["Amp"] = float.Parse(dr["Amp"].ToString()).ToString("F3");
                    }
                    catch { }
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static DataTable getDCMAGHistory(DateTime dtBegin, DateTime dtEnd)
        {
            try
            {
                string sql = string.Format(
                @"SELECT  b.Remark ,a.Data_Time,Amp           
                FROM     DCMAG_DATA a,DCMAG_SIGNAL_PARAMETER b
                WHERE     (a.Data_Time > ?) AND (a.Data_Time < ?) and (a.Signal_ID=b.Signal_ID)
                ORDER BY Data_Time"
                    );
                DataTable dt = IsoContext.IsoDb.GetDataTable(sql, dtBegin, dtEnd);
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        dr["Amp"] = float.Parse(dr["Amp"].ToString()).ToString("F2");
                    }
                    catch
                    { }
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static DataTable getNOVBHistory(DateTime dtBegin, DateTime dtEnd)
        {
            try
            {
                string sql = string.Format(
                @"SELECT  b.Remark,a.Data_Time,Amp,a.Hz         
                FROM     NOVB_DATA a,NOVB_SIGNAL_PARAMETER b
                WHERE     (a.Data_Time > ?) AND (a.Data_Time < ?) and (a.Signal_ID=b.Signal_ID)
                ORDER BY Data_Time"
                    );
                DataTable dt = IsoContext.IsoDb.GetDataTable(sql, dtBegin, dtEnd);
                foreach (DataRow dr in dt.Rows)
                {
                    try
                    {
                        dr["Amp"] = float.Parse(dr["Amp"].ToString()).ToString("F3");
                        dr["Hz"] = float.Parse(dr["Amp"].ToString()).ToString("F1");
                    }
                    catch { }
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
     
    }
}
