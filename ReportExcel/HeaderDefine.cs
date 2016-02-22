using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportExcel
{
    public class HeaderDefine
    {
        public static string[] GasHeader = new string[] {
        "采集时间",
        "氢气(ppm)",
        "甲烷(ppm)",
        "乙烯(ppm)",
        "乙炔(ppm)",
        "乙烷(ppm)",
        "一氧化碳(ppm)",
        "二氧化碳(ppm)",
        "微水"        
        };

        public static string[] PDHeader = new string[] {
            "设备号",
            "时间",
            "放电量(mV)",
            "放电次数"
         };
        public static string[] BushignHeader = new string[] {
           "设备号",
            "时间",
            "参考电压(kV)",
            "泄漏电流(mA)",
            "介损因数(%)",
            "等值电容(pF)"
         };

        public static string[] CoreHeader = new string[] {
            "时间",            
            "铁心接地电流(A)"
         };
        public static string[] VCHeader = new string[] {
            "设备号",
            "时间",
            "频率(Hz)",
            "功率因素",
            "A相电压(kV)",
            "B相电压(kV)",
            "C相电压(kV)",

            "AB相电压(kV)",
            "BC相电压(kV)",
            "CA相电压(kV)",
            "A相电流(mA)",
            "B相电流(mA)",

            "C相电流(mA)",
            "A相有功()",
            "B相有功",
            "C相有功",
            "总有功",

            "A相无功",
            "B相无功",
            "C相无功",
            "总无功"
         };
        public static string[] RemoteMHeader = new string[] {
            "时间",
            "顶层油温度1",
            "顶层油温度2",
            "顶层油温度3",
            "顶层油温度4",
            "底层油温度1",
            "底层油温度2",
            "环境温度",
            "绕组温度1",
            "绕组温度2",
            "绕组温度3",
            "绕组温度4",
            "铁心故障电流",            
            "铁心接地电流",
            "OLTC油位",
            "储油柜油位",
            "轻瓦斯报警",
            "备用1",
            "备用2",
            "有载分接开关档位"   
         };
        public static string[] RemoteSHeader = new string[] {
             "时间",
            "非电量延时跳闸出口01",
            "非电量延时跳闸出口02",
            "非电量延时跳闸出口03",
            "非电量延时跳闸出口04",
            "非电量延时跳闸出口05",
            "非电量延时跳闸出口06",
            "非电量延时跳闸出口07",
            "非电量延时跳闸出口08",
            "非电量延时跳闸",
            "冷控失电跳闸",
            "非电量2跳闸",
            "非电量3跳闸",
            "非电量4跳闸",
            "本体重瓦斯跳闸",
            "有载重瓦斯跳闸",
            "绕组温度高",
            "压力释放",
            "压力突变",
            "油温高报警",
            "本体轻瓦斯报警",
            "有载轻瓦斯报警",
            "本体油位异常报警",
            "有载油位异常报警",
            "绕组温度高报警",
            "非电量16备用"            
         };
        public static string[] NeutralptHeader = new string[] {
            "设备号",
            "时间",            
            "中性点电流(mA)"
         };
        public static string[] DCMAGHeader = new string[] {
            "设备号",
            "时间",            
            "直流偏磁电流(A)"
         };
        public static string[] NOVBHeader = new string[] {
            "设备号",
            "时间",            
            "振动（g）/噪声(dB)",
            "频率(Hz)"           
         };
    }
}
