using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using Microsoft.Office.Interop;
using PMA.Entity;

namespace PMA
{
    class ExcelExport
    {
        private ExcelExport()
        { }
        private static ExcelExport _instance = null;

        public static ExcelExport Instance
        {
            get
            {
                if (_instance == null) _instance = new ExcelExport();
                return _instance;
            }
        }
       
        /// <summary>
        /// DataTable直接导出Excel,此方法会把DataTable的数据用Excel打开,再自己手动去保存到确切的位置
        /// </summary>
        /// <param name="dt">要导出Excel的DataTable</param>
        /// <returns></returns>
        public void DoExport(System.Data.DataTable dt , List<CnAttr> lst , string filName)
        {
            Application excel;

            _Workbook workBook;

            _Worksheet workSheet;

            object misValue = System.Reflection.Missing.Value;

            excel = new Application();

            workBook = excel.Workbooks.Add(misValue);

            workSheet = (_Worksheet)workBook.ActiveSheet;  
  
            for (int j = 0; j < lst.Count; j++ )
            {
                excel.Cells[1, j + 1] = lst[j].AttrDesc;
                //设置表格内容居中对齐  
                workSheet.get_Range(excel.Cells[1, j + 1],

                  excel.Cells[1 , j + 1]).HorizontalAlignment =

                  XlVAlign.xlVAlignCenter;  
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < lst.Count; j++)
                {
                    excel.Cells[2 + i, j + 1] = dt.Rows[i][lst[j].AttrName];

                    //设置表格内容居中对齐  
                    workSheet.get_Range(excel.Cells[2 + i, j + 1],

                      excel.Cells[2 + i, j + 1]).HorizontalAlignment =

                      XlVAlign.xlVAlignCenter;  

                }
            }
            excel.Visible = false;

            workBook.SaveAs(filName , XlFileFormat.xlWorkbookNormal, misValue,

                misValue, misValue, misValue, XlSaveAsAccessMode.xlExclusive,

                misValue, misValue, misValue, misValue, misValue);

            workBook.Close(true, misValue, misValue);

            excel.Quit();

            PublicMethod.Kill(excel);//调用kill当前excel进程  

            releaseObject(workSheet);

            releaseObject(workBook);

            releaseObject(excel);  
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }  

    }
    public class PublicMethod
    {
        [System.Runtime.InteropServices.DllImport("User32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

        public static void Kill(Microsoft.Office.Interop.Excel.Application excel)
        {
            try
            {
                IntPtr t = new IntPtr(excel.Hwnd);

                int k = 0;

                GetWindowThreadProcessId(t, out k);

                System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);

                p.Kill();
            }
            catch
            { }
        }
    }  
}
