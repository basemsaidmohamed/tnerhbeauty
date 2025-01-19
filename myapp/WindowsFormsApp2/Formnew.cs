using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;
using tnerhbeauty.Class;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Xml.Linq;
using ClosedXML.Excel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Activities.Statements;


namespace tnerhbeauty
{
    public partial class Formnew : Form
    {
        string end_column = "q";
        int code = 0, name = 1, price = 2, price_sale_100 = 3, price_sale_75 = 4, price_sale_vip2 = 5, price_sale_vip1 = 6, price_1=7, price_2=8, price_3=9, price_4=10, price_5=11, price_6=12, price_7=13, price_8=14, price_9=15, price_10=16, not = 17;

        private void gv_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MyMessageBox.showMessage("تاكيد", "هل متاكد من حذف السجل المحدد", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = false;
                gv.CurrentCell = null;
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void gv_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (valid())
            {
                bt_save.Visible = true;
                dr_open_pro_in_exal.Visible = true;
            }
        }

        bool isimpore;
        public Formnew()
        {
            InitializeComponent();
        }
        private void Formnew_Load(object sender, EventArgs e)
        {
            dr_open_pro_in_exal.SelectedIndex = 0;
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //try
            //{            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "اختار ملف اكسيل ";
            ofd.Filter = "Excel Files|*.xlsx;*.xls;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                emptyall();
                string FileName = Path.GetFileName(ofd.FileName);
                txtPath.Text = ofd.FileName;
                isimpore = true;
                cboSheet.Items.Clear();
                get_data(null);
                gv.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            }
            //}
            //catch
            //{
            //    emptyall();
            //    MyMessageBox.showMessage("تحذير   ", "حدث خطاء اثناء جلب البيانات ربما يكون الملف غير صالح ", "", MessageBoxButtons.RetryCancel);
            //}
        }
        private void emptyall()
        {
            cboSheet.Items.Clear();
            cboSheet.Text = "";
            txtPath.Text = "";
            bt_save.Visible = false;
            dr_open_pro_in_exal.Visible = false;
            gv.DataSource = new DataTable();
        }
        DataTable dt;
        bool valid()
        {
            int error = 0;
            for (int i = 0; i < gv.Rows.Count; i++)
            {
                //string datacode = gv.Rows[i].Cells[code].Value.ToString();
                //if (!Regex.IsMatch(datacode, @"^[(a)(A)]{1}[(r)(R)]{1}[a-zA-Z0-9]{1}[0-9]{4}$"))
                //{
                //    gv.Rows[i].Cells[not].Value = "  كود الصنف غير صحيح ";
                //    gv.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                //    error++;
                //}

                decimal dataprice_sale = Session.Convertdecimal(gv.Rows[i].Cells[price].Value.ToString());
                if (dataprice_sale <= 0)
                {
                    gv.Rows[i].Cells[not].Value += " السعر المحل غير صحيح ";
                    gv.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                    error++;
                }

                decimal dataprice_sale100 = Session.Convertdecimal(gv.Rows[i].Cells[price_sale_100].Value.ToString());
                if (dataprice_sale100 <= 0)
                {
                    gv.Rows[i].Cells[not].Value += " السعر 100 غير صحيح ";
                    gv.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                    error++;
                }

                decimal dataprice_sale75 = Session.Convertdecimal(gv.Rows[i].Cells[price_sale_75].Value.ToString());
                if (dataprice_sale75 <= 0)
                {
                    gv.Rows[i].Cells[not].Value += " السعر 75 غير صحيح ";
                    gv.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                    error++;
                }

                decimal dataprice_sale_vip2 = Session.Convertdecimal(gv.Rows[i].Cells[price_sale_vip2].Value.ToString());
                if (dataprice_sale_vip2 <= 0)
                {
                    gv.Rows[i].Cells[not].Value += " السعر vip2 غير صحيح ";
                    gv.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                    error++;
                }

                decimal dataprice_sale_vip1 = Session.Convertdecimal(gv.Rows[i].Cells[price_sale_vip1].Value.ToString());
                if (dataprice_sale_vip1 <= 0)
                {
                    gv.Rows[i].Cells[not].Value += " السعر vip1 غير صحيح ";
                    gv.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                    error++;
                }

                string dataname = gv.Rows[i].Cells[name].Value.ToString();
                if (string.IsNullOrEmpty(dataname.Trim()))
                {
                    gv.Rows[i].Cells[not].Value += " اسم الصنف  غير صحيح ";
                    gv.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                    error++;
                }

                
                if (Session.Convertdecimal(gv.Rows[i].Cells[price_1].Value.ToString()) <= 0)
                {
                    gv.Rows[i].Cells[not].Value += " السعر price_1 غير صحيح ";
                    gv.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                    error++;
                }


                if (Session.Convertdecimal(gv.Rows[i].Cells[price_2].Value.ToString()) <= 0)
                {
                    gv.Rows[i].Cells[not].Value += " السعر price_2 غير صحيح ";
                    gv.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                    error++;
                }
                if (Session.Convertdecimal(gv.Rows[i].Cells[price_3].Value.ToString()) <= 0)
                {
                    gv.Rows[i].Cells[not].Value += " السعر price_3 غير صحيح ";
                    gv.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                    error++;
                }
                if (Session.Convertdecimal(gv.Rows[i].Cells[price_4].Value.ToString()) <= 0)
                {
                    gv.Rows[i].Cells[not].Value += " السعر price_4 غير صحيح ";
                    gv.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                    error++;
                }
                if (Session.Convertdecimal(gv.Rows[i].Cells[price_5].Value.ToString()) <= 0)
                {
                    gv.Rows[i].Cells[not].Value += " السعر price_5 غير صحيح ";
                    gv.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                    error++;
                }
                if (Session.Convertdecimal(gv.Rows[i].Cells[price_6].Value.ToString()) <= 0)
                {
                    gv.Rows[i].Cells[not].Value += " السعر price_6 غير صحيح ";
                    gv.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                    error++;
                }
                if (Session.Convertdecimal(gv.Rows[i].Cells[price_7].Value.ToString()) <= 0)
                {
                    gv.Rows[i].Cells[not].Value += " السعر price_7 غير صحيح ";
                    gv.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                    error++;
                }
                if (Session.Convertdecimal(gv.Rows[i].Cells[price_8].Value.ToString()) <= 0)
                {
                    gv.Rows[i].Cells[not].Value += " السعر price_8 غير صحيح ";
                    gv.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                    error++;
                }
                if (Session.Convertdecimal(gv.Rows[i].Cells[price_9].Value.ToString()) <= 0)
                {
                    gv.Rows[i].Cells[not].Value += " السعر price_9 غير صحيح ";
                    gv.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                    error++;
                }
                if (Session.Convertdecimal(gv.Rows[i].Cells[price_10].Value.ToString()) <= 0)
                {
                    gv.Rows[i].Cells[not].Value += " السعر price_10 غير صحيح ";
                    gv.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                    error++;
                }
            }
            return error == 0;
        }
        private void errorimport(string mas)
        {
            gv.DataSource = new DataTable();
            lb_mas.Text = mas;
        }
        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isimpore)
            {
                get_data(cboSheet.Text);
            }
            isimpore = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            gv.MultiSelect = true;
            gv.SelectAll();
            DataObject dataObj = gv.GetClipboardContent();
            Clipboard.SetDataObject(dataObj, true);
            gv.MultiSelect = false;

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "Response.xls";
            savefile.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(savefile.FileName, false, Encoding.GetEncoding("windows-1256"));
                sw.WriteLine(Clipboard.GetText());
                sw.Close();
                sw.Dispose();
            }
        }
        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length != 1)
                {
                    lb_mas.Text = "يجب اضافة ملف اكسيل واحد فقط";
                    return;
                }
                emptyall();
                string FileName = Path.GetFileName(files[0]);
                txtPath.Text = files[0];
                isimpore = true;
                get_data(null);
            }
        }
        private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
        private void bt_save_Click(object sender, EventArgs e)
        {
            if (MyMessageBox.showMessage("معلومات هامة ", "سيتم تحديث الاسعار بتاريخ اليوم هل متاكد من الاسنمرار .. ؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                for (int i = 0; i < gv.Rows.Count; i++)
                {

                    string dataname = gv.Rows[i].Cells[name].Value.ToString().Replace_text();
                    string datacode = gv.Rows[i].Cells[code].Value.ToString();
                    decimal dataprice_sale = Session.Convertdecimal(gv.Rows[i].Cells[price].Value.ToString());
                    decimal dataprice_sale_100 = Session.Convertdecimal(gv.Rows[i].Cells[price_sale_100].Value.ToString());
                    decimal dataprice_sale_75 = Session.Convertdecimal(gv.Rows[i].Cells[price_sale_75].Value.ToString());
                    decimal dataprice_sale_vip2 = Session.Convertdecimal(gv.Rows[i].Cells[price_sale_vip2].Value.ToString());
                    decimal dataprice_sale_vip1 = Session.Convertdecimal(gv.Rows[i].Cells[price_sale_vip1].Value.ToString());

                    decimal dataprice_1  = Session.Convertdecimal(gv.Rows[i].Cells[price_1 ].Value.ToString());
                    decimal dataprice_2  = Session.Convertdecimal(gv.Rows[i].Cells[price_2 ].Value.ToString());
                    decimal dataprice_3  = Session.Convertdecimal(gv.Rows[i].Cells[price_3 ].Value.ToString());
                    decimal dataprice_4  = Session.Convertdecimal(gv.Rows[i].Cells[price_4 ].Value.ToString());
                    decimal dataprice_5  = Session.Convertdecimal(gv.Rows[i].Cells[price_5 ].Value.ToString());
                    decimal dataprice_6  = Session.Convertdecimal(gv.Rows[i].Cells[price_6 ].Value.ToString());
                    decimal dataprice_7  = Session.Convertdecimal(gv.Rows[i].Cells[price_7 ].Value.ToString());
                    decimal dataprice_8  = Session.Convertdecimal(gv.Rows[i].Cells[price_8 ].Value.ToString());
                    decimal dataprice_9  = Session.Convertdecimal(gv.Rows[i].Cells[price_9 ].Value.ToString());
                    decimal dataprice_10 = Session.Convertdecimal(gv.Rows[i].Cells[price_10].Value.ToString());

                    string q = "IF NOT EXISTS(SELECT 1 FROM product WHERE product.code = N'" + datacode + "' )";
                    string insert = q + "INSERT INTO product (code, name,price_buy, price_sale,price_sale_100,price_sale_75,price_sale_vip2,price_sale_vip1,price_1, price_2, price_3, price_4, price_5, price_6, price_7, price_8, price_9, price_10, update_price, category, is_stop)VALUES(N'" + datacode + "', N'" + dataname + "'," + dataprice_sale + " ," + dataprice_sale + "," + dataprice_sale_100 + "," + dataprice_sale_75 + "," + dataprice_sale_vip2 + "," + dataprice_sale_vip1 + "," + dataprice_1 + "," + dataprice_2 + "," + dataprice_3 + "," + dataprice_4 + "," + dataprice_5 + "," + dataprice_6 + "," + dataprice_7 + "," + dataprice_8 + "," + dataprice_9 + "," + dataprice_10 + ", GETDATE(), 1, 0) else ";
                    if (dr_open_pro_in_exal.SelectedIndex == 1)
                        db.ExecuteCommand(insert + "UPDATE product SET price_sale =" + dataprice_sale + " ,price_sale_100 =" + dataprice_sale_100 + " ,price_sale_75 =" + dataprice_sale_75 + " ,price_sale_vip2 =" + dataprice_sale_vip2 + " ,price_sale_vip1 =" + dataprice_sale_vip1 + ",price_1 =" + dataprice_1 + " ,price_2 =" + dataprice_2 + ",price_3 =" + dataprice_3 + ",price_4 =" + dataprice_4 + ",price_5 =" + dataprice_5 + ",price_6 =" + dataprice_6 + ",price_7 =" + dataprice_7 + ",price_8 =" + dataprice_8 + ",price_9 =" + dataprice_9 + ",price_10 =" + dataprice_10 + ", update_price = GETDATE(),is_stop = 0 WHERE (code = N'" + datacode + "')", "");
                    else
                        db.ExecuteCommand(insert + "UPDATE product SET price_sale =" + dataprice_sale + " ,price_sale_100 =" + dataprice_sale_100 + " ,price_sale_75 =" + dataprice_sale_75 + " ,price_sale_vip2 =" + dataprice_sale_vip2 + " ,price_sale_vip1 =" + dataprice_sale_vip1 + " ,price_1 =" + dataprice_1 + " ,price_2 =" + dataprice_2 + ",price_3 =" + dataprice_3 + ",price_4 =" + dataprice_4 + ",price_5 =" + dataprice_5 + ",price_6 =" + dataprice_6 + ",price_7 =" + dataprice_7 + ",price_8 =" + dataprice_8 + ",price_9 =" + dataprice_9 + ",price_10 =" + dataprice_10 + ", update_price = GETDATE() WHERE (code = N'" + datacode + "')", "");
                }
                db.SubmitChanges();
                emptyall();
                MyMessageBox.showMessage("معلومات", "تم تحديث الاسعار بنجاح", "", MessageBoxButtons.OK);
            }
            else MyMessageBox.showMessage("معلومات", "تم الغاء التحديث ", "", MessageBoxButtons.RetryCancel);
        }
        private void get_data(string sheetname)
        {
            try
            {

                bt_save.Visible = false;
                dr_open_pro_in_exal.Visible = false;
                gv.DataSource = new DataTable();
                dt = new DataTable();


                GetDatabyOLEDB(sheetname);
            if (dt.Rows.Count == 0)
                GetDataFromExcel(sheetname);

            gv.DataSource = dt;
            if (dt.Rows.Count > 0 && dt.Columns.Count == not)
            {
                dt.Columns.Add();
                gv.DataSource = null;
                gv.DataSource = dt;
                gv.Columns[code].HeaderText = "كود";
                gv.Columns[name].HeaderText = "اسم الصنف";
                gv.Columns[price].HeaderText = "سعر المحل";
                gv.Columns[price_sale_100].HeaderText = "سعر 100";
                gv.Columns[price_sale_75].HeaderText = "سعر 75";
                gv.Columns[price_sale_vip2].HeaderText = "سعر VIP2";
                gv.Columns[price_sale_vip1].HeaderText = "سعر VIP1";
                gv.Columns[price_1 ].HeaderText = "price_1 ";
                gv.Columns[price_2 ].HeaderText = "price_2 ";
                gv.Columns[price_3 ].HeaderText = "price_3 ";
                gv.Columns[price_4 ].HeaderText = "price_4 ";
                gv.Columns[price_5 ].HeaderText = "price_5 ";
                gv.Columns[price_6 ].HeaderText = "price_6 ";
                gv.Columns[price_7 ].HeaderText = "price_7 ";
                gv.Columns[price_8 ].HeaderText = "price_8 ";
                gv.Columns[price_9 ].HeaderText = "price_9 ";
                gv.Columns[price_10].HeaderText = "price_10";
                gv.Columns[not].HeaderText = "ملاحظات";
                if (valid())
                {
                    bt_save.Visible = true;
                    dr_open_pro_in_exal.Visible = true;
                }
            }
            else
            {
                gv.DataSource = new DataTable();
                errorimport("صفحة ربما لا تحتوي علي بيانات وايضا يجب ان يكون الصفحة تحتوي على 17 اعمدة هي  الكود-اسم الصنف-السعر-سعر100-سعر75-سعر-سعر  بنفس الترتيب ");
            }

            }
            catch
            {
                errorimport("برجاء التاكد من  الملف و الصفحة ");
                gv.DataSource = new DataTable();
            }
        }
        private void GetDatabyOLEDB(dynamic sheetname)
        {
            try
            {
                string Extension = Path.GetExtension(txtPath.Text);
                string conStr = "";
                if (Extension == ".xls")
                    conStr = String.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source={0};Extended Properties=\'Excel 8.0;HDR=Yes;IMEX=1'", txtPath.Text);
                else
                    conStr = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source={0};Extended Properties='Excel 12.0;HDR=Yes;IMEX=1'", txtPath.Text);
                OleDbConnection connExcel = new OleDbConnection(conStr);
                OleDbCommand cmdExcel = new OleDbCommand();
                OleDbDataAdapter oda = new OleDbDataAdapter();
                cmdExcel.Connection = connExcel;
                connExcel.Open();
                DataTable dtExcelSchema = new DataTable();

                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                if (dtExcelSchema.Rows.Count > 0)
                {
                    if (sheetname == null)
                    {
                        foreach (DataRow table in dtExcelSchema.Rows)
                        {
                            cboSheet.Items.Add(table["TABLE_NAME"].ToString().Replace("'", "").Replace("$", ""));
                        }
                        cboSheet.SelectedIndex = 0;
                    }
                    string SheetName = sheetname == null ? dtExcelSchema.Rows[0]["TABLE_NAME"].ToString() : sheetname + "$";
                    cmdExcel.CommandText = "select * from [" + SheetName + "A1:" + end_column + "]";
                    oda.SelectCommand = cmdExcel;
                    oda.Fill(dt);
                    connExcel.Close();
                }
            }
            catch { }
        }
        private void GetDataFromExcel(dynamic worksheet)
        {
            try { 
            //Save the uploaded Excel file.

            //Open the Excel file using ClosedXML.
            using (XLWorkbook workBook = new XLWorkbook(txtPath.Text))
            {
                if (worksheet == null)
                {
                    cboSheet.Items.Clear();
                    foreach (IXLWorksheet sheet in workBook.Worksheets)
                    {
                        cboSheet.Items.Add(sheet.Name);
                    }
                    cboSheet.SelectedIndex = 0;
                }
                //Read the first Sheet from Excel file.
                IXLWorksheet workSheet = workBook.Worksheet(cboSheet.Text);




                //Create a new DataTable.

                //Loop through the Worksheet rows.
                bool firstRow = true;
                foreach (IXLRow row in workSheet.Rows())
                {
                    //Use the first row to add columns to DataTable.
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells("a", end_column))
                        {
                            if (!string.IsNullOrEmpty(cell.Value.ToString()))
                            {
                                dt.Columns.Add(cell.FormulaR1C1.ToString());
                            }
                            else
                            {
                                break;
                            }
                        }
                        firstRow = false;
                    }
                    else
                    {
                        if (dt.Columns.Count == 0)
                            return;
                        int i = 0;
                        DataRow toInsert = dt.NewRow();
                        foreach (IXLCell cell in row.Cells(1, dt.Columns.Count))
                        {
                            try
                            {
                                toInsert[i] = cell.Value.ToString();
                            }
                            catch 
                            {

                            }
                            i++;
                        }
                        dt.Rows.Add(toInsert);
                    }
                }
            }
        } catch{}

        }
    }
    
}