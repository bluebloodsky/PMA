using System;
using System.Collections.Generic; 
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Isoms.Entity;
using System.IO;
using System.Configuration;
using Isoms.GlobalCache;
using System.Threading;

namespace ReportExcel
{
    public partial class FrmDataOut : Form
    {
        public FrmDataOut()
        {
            InitializeComponent();
        }

        RadioButton selRaButton;
        EnumIEDType selectedIED;
        //Thread threadPrint;
        /// <summary>
        /// 将datatable数据导入到excel表中，表头由HeaderDefine提供
        /// </summary>
        /// <param name="dt"></param>
        public void print(object obj)
        {
            DataTable dt = (DataTable)obj;
            if (dt == null)
            {
                this.BeginInvoke(new EventHandler(delegate
                {
                    this.richTextBoxShown.AppendText("数据库读取错误\n");
                    this.richTextBoxShown.ScrollToCaret();
                    this.btnOut.Enabled = true;
                }));
                return;
            }
            if (dt.Rows.Count == 0)
            {
                this.BeginInvoke(new EventHandler(delegate
                {
                    this.richTextBoxShown.AppendText("读取数据为空，请重新选择时间段！\n");
                    this.richTextBoxShown.ScrollToCaret();
                    this.btnOut.Enabled = true;
                }));
                return;
            }          
                           
            string strName = textBoxPath.Text;
            string[] dir = strName.Split('\\');
            string directory = strName.Substring(0, strName.Length - dir[dir.Length - 1].Length - 1);
            if (!Directory.Exists(directory))
            {
                try
                {
                    Directory.CreateDirectory(directory);
                }
                catch
                {
                    this.BeginInvoke(new EventHandler(delegate
                    {
                        this.richTextBoxShown.AppendText("目录错误！\n");
                        this.richTextBoxShown.ScrollToCaret();
                        this.btnOut.Enabled = true;
                    }));
                    return;
                }
            }
            if (strName.Length != 0)
            {
                if (dt.Rows.Count == 0)
                    return;
                // toolStripProgressBar1.Visible = true; 
                System.Reflection.Missing miss = System.Reflection.Missing.Value;
                //实例化一个Excel.Application对象 
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Application.Workbooks.Add(true);
                excel.Visible = false;//若是true，则在导出的时候会显示EXcel界面。 
                if (excel == null)
                {
                    this.BeginInvoke(new EventHandler(delegate
                        {
                            this.richTextBoxShown.AppendText("EXCEL无法启动！\n");
                            this.richTextBoxShown.ScrollToCaret();

                        }));
                    return;
                }
                
                #region 数据导出
                Microsoft.Office.Interop.Excel.Workbooks books = (Microsoft.Office.Interop.Excel.Workbooks)excel.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook book = (Microsoft.Office.Interop.Excel.Workbook)(books.Add(miss));
                Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;
                sheet.Name = "test";
                try
                {
                    //生成Excel中列头名称 
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        switch (selectedIED)
                        {
                            case EnumIEDType.Gas:
                                excel.Cells[1, i + 1] = HeaderDefine.GasHeader[i];
                                break;
                            case EnumIEDType.PD:
                                excel.Cells[1, i + 1] = HeaderDefine.PDHeader[i];
                                break;
                            case EnumIEDType.Capacitive:
                                excel.Cells[1, i + 1] = HeaderDefine.BushignHeader[i];
                                break;
                            case EnumIEDType.Core:
                                excel.Cells[1, i + 1] = HeaderDefine.CoreHeader[i];
                                break;
                            case EnumIEDType.VC:
                                excel.Cells[1, i + 1] = HeaderDefine.VCHeader[i];
                                break;
                            case EnumIEDType.REMOTE_M:
                                excel.Cells[1, i + 1] = HeaderDefine.RemoteMHeader[i];
                                break;
                            case EnumIEDType.REMOTE_S:
                                excel.Cells[1, i + 1] = HeaderDefine.RemoteSHeader[i];
                                break;
                            case EnumIEDType.DCMAG:
                                excel.Cells[1, i + 1] = HeaderDefine.DCMAGHeader[i];
                                break;
                            case EnumIEDType.NEUTRALPT:
                                excel.Cells[1, i + 1] = HeaderDefine.NeutralptHeader[i];
                                break;
                            case EnumIEDType.NOVB:
                                excel.Cells[1, i + 1] = HeaderDefine.NOVBHeader[i];
                                break;
                        }
                        // excel.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;//输出DataGridView列头名 
                    }
                    this.BeginInvoke(new EventHandler(delegate
                    {
                        this.richTextBoxShown.AppendText("正在进行断路器数据导出,共需导出" + dt.Rows.Count + "行\n");
                        this.richTextBoxShown.ScrollToCaret();
                        this.progressBar1.Value = 0;

                    }));
                    if (dt.Rows.Count > 0)
                    {
                        int k = 1;
                        for (int i = 0; i < dt.Rows.Count; i++)//控制Excel中行，上下的距离，就是可以到Excel最下的行数，比数据长了报错，比数据短了会显示不完 
                        {

                            for (int j = 0; j < dt.Columns.Count; j++)//控制Excel中列，左右的距离，就是可以到Excel最右的列数，比数据长了报错，比数据短了会显示不完 
                            {
                                string str;
                                if(selectedIED==EnumIEDType.REMOTE_S&&j>0)
                                    str= getStatus(dt.Rows[i][j]); 
                                else
                                    str = dt.Rows[i][j].ToString();
                                    excel.Cells[i + 2, j + 1] = str;//i控制行，从Excel中第2行开始输出第一行数据，j控制列，从Excel中第1列输出第1列数据，"'" +是以string形式保存，所以遇到数字不会转成16进制 
                            }

                            if (i > k * dt.Rows.Count / 50 || i == dt.Rows.Count - 1)
                            {
                                this.BeginInvoke(new EventHandler(delegate
                                {
                                    this.progressBar1.Value = (i + 1) * 100 / dt.Rows.Count > 100 ? 100 : (i + 1) * 100 / dt.Rows.Count;
                                }));

                                k++;
                            }
                        }
                    }
                    //sheet.SaveAs(strName, miss, miss, miss, miss, miss, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, miss, miss, miss);
                    sheet.SaveAs(strName);
                    book.Close(false, miss, miss);
                    books.Close();
                    excel.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(book);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(books);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                    if (!this.IsDisposed)//
                    {
                        this.BeginInvoke(new EventHandler(delegate
                        {
                            this.richTextBoxShown.AppendText("数据已经成功导出!\n");
                            this.richTextBoxShown.ScrollToCaret();
                            btnOut.Enabled = true;
                        }));
                    }
                    // toolStripProgressBar1.Value = 0; 
                    //System.Diagnostics.Process.Start(strName);
                    #endregion
                }
                catch (Exception ex)
                {
                    if (!this.IsDisposed&&this.IsHandleCreated)//
                    {
                        this.Invoke(new EventHandler(delegate
                        {
                            this.richTextBoxShown.AppendText("错误提示:" + ex.Message + "\n");
                            this.richTextBoxShown.ScrollToCaret();
                            btnOut.Enabled = true;
                        }));
                    }
                }
                finally
                {
                    //释放excel进程
                    if(excel!=null)
                         System.GC.Collect(System.GC.GetGeneration(excel));
                }
        }
           
           
        }

        private string getStatus(object obj)
        {
            int status=int.Parse(obj.ToString());
            return status == 0?"关":"开";

        }       

        /// <summary>
        /// 选择文件导出路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDirection_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "导出Excel (*.xlsx)|*.xlsx";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.FileName = selRaButton.Text + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            saveFileDialog.Title = "导出文件保存路径";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            { 
               textBoxPath.Text = saveFileDialog.FileName;
            }   
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IsoConfig.InitConfig();
            dateTimeBegin.Value = DateTime.Now.AddDays(-7);
            dateTimeEnd.Value = DateTime.Now;
            selRaButton = radioButtonGas;
            textBoxPath.Text = "d:\\data\\" + selRaButton.Text + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            //threadPrint = new Thread(new ParameterizedThreadStart(print));
        }

        /// <summary>
        /// 选择导出量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb =(RadioButton)sender;
            if (rb.Checked)
             {
                 selRaButton = rb;                

                 textBoxPath.Text = "d:\\data\\" + selRaButton.Text + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
             }          
           
        }

        private void getSelIED()
        {
            switch (selRaButton.TabIndex)
            {
                case 0:
                    selectedIED = EnumIEDType.Gas;
                    break;
                case 1:
                    selectedIED = EnumIEDType.PD;
                    break;
                case 2:
                    selectedIED = EnumIEDType.Capacitive;
                    break;
                case 3:
                    selectedIED = EnumIEDType.Core;
                    break;
                case 4:
                    selectedIED = EnumIEDType.VC;
                    break;
                case 5:
                    selectedIED = EnumIEDType.REMOTE_M;
                    break;
                case 6:
                    selectedIED = EnumIEDType.REMOTE_S;
                    break;
                case 7:
                    selectedIED = EnumIEDType.NEUTRALPT;
                    break;
                case 8:
                    selectedIED = EnumIEDType.DCMAG;
                    break;
                case 9:
                    selectedIED = EnumIEDType.NOVB;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 获取导出数据
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataTable()
        {
            getSelIED();
            this.BeginInvoke(new EventHandler(delegate
            {
                this.richTextBoxShown.AppendText("正在读取数据库，请稍后...\n");
                this.richTextBoxShown.ScrollToCaret();
            }));   
            //string sqlconn = ConfigurationManager.AppSettings["IsoConnectString"];
            //SqlConnection cn = new SqlConnection(sqlconn);          
            DateTime dtBegin = dateTimeBegin.Value;
            DateTime dtEnd = dateTimeEnd.Value;
            DataTable dt = new DataTable();

            switch (selectedIED)
            { 
                case EnumIEDType.Gas:
                    dt = HistoryDataHelper.getGasHistory(dtBegin, dtEnd);
                    break;
                case EnumIEDType.Capacitive:
                    dt = HistoryDataHelper.getBushingHistory(dtBegin, dtEnd);
                    break;
                case EnumIEDType.PD:
                    dt = HistoryDataHelper.getPDHistory(dtBegin, dtEnd);
                    break;
                case EnumIEDType.Core:
                    dt = HistoryDataHelper.getCoreHistory(dtBegin, dtEnd);
                    break;
                case EnumIEDType.VC:
                    dt = HistoryDataHelper.getVCHistory(dtBegin, dtEnd);
                    break;
                case EnumIEDType.REMOTE_M:
                    dt = HistoryDataHelper.getRemoteMHistory(dtBegin, dtEnd);
                    break;
                case EnumIEDType.REMOTE_S:
                    dt = HistoryDataHelper.getRemoteSHistory(dtBegin, dtEnd);
                    break;
                case EnumIEDType.NEUTRALPT:
                    dt = HistoryDataHelper.getNEUTRALPTHistory(dtBegin, dtEnd);
                    break;
                case EnumIEDType.DCMAG:
                    dt = HistoryDataHelper.getDCMAGHistory(dtBegin, dtEnd);
                    break;
                case EnumIEDType.NOVB:
                    dt = HistoryDataHelper.getNOVBHistory(dtBegin, dtEnd);
                    break;

            }
            return dt;
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            btnOut.Enabled = false;
            //if(threadPrint==null)
            Thread threadPrint = new Thread(new ParameterizedThreadStart(print));
            threadPrint.Start(GetDataTable());            
        }
    }
} 


