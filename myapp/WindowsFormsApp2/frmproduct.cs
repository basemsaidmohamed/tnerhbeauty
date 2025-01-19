using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using tnerhbeauty.Class;
using tnerhbeauty.rport;
using Microsoft.Reporting.WinForms;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using ClosedXML.Excel;
using System.IO;

namespace tnerhbeauty
{
    public partial class frmproduct : Form
    {
        public frmproduct()
        {
            InitializeComponent();
            refrsfgv();
        }
        DataClasses1DataContext db;
        public void refrsfgv()
        {
            db = new DataClasses1DataContext();
            List<product_serch_View> qq = new List<product_serch_View>();
            if (ch_store.Checked)
            {
                gv_product.DataSource = db.product_serch_Views.OrderBy(x => x.name).Where(x => (x.name.Contains(tx_serch.Text.Replace_text()) || x.code.Contains(tx_serch.Text)) && (!ch_zero.Checked || x.Balance != 0)).OrderByDescending(x => x.name.StartsWith(tx_serch.Text.Replace_text())).ToList();
                gv_product.Columns[nameof(product_serch_View.store_name)].Visible = true;
                gv_product.Columns[nameof(product_serch_View.min_mum)].Visible = false;
            }
            else
            {
                gv_product.DataSource = db.product_serch_Views.OrderBy(x => x.name).Where(x => (x.name.Contains(tx_serch.Text.Replace_text()) || x.code.Contains(tx_serch.Text)) && (!ch_zero.Checked || x.Balance != 0)).OrderByDescending(x => x.name.StartsWith(tx_serch.Text.Replace_text())).GroupBy(x => new { x.id }).Select(cl => new product_serch_View
                {
                    id = cl.First().id,
                    fullname = cl.First().fullname,
                    name = cl.First().name,
                    code = cl.First().code,
                    price_sale = cl.First().price_sale,
                    price_sale_100 = cl.First().price_sale_100,
                    price_sale_75 = cl.First().price_sale_75,
                    price_sale_vip2 = cl.First().price_sale_vip2,
                    price_sale_vip1 = cl.First().price_sale_vip1,

                    price_1 = cl.First(). price_1,
                    price_2 = cl.First(). price_2,
                    price_3 = cl.First(). price_3,
                    price_4 = cl.First(). price_4,
                    price_5 = cl.First(). price_5,
                    price_6 = cl.First(). price_6,
                    price_7 = cl.First(). price_7,
                    price_8 = cl.First(). price_8,
                    price_9 = cl.First(). price_9,
                   price_10 = cl.First().price_10,

                    update_price = cl.First().update_price,
                    Balance = (decimal?)cl.Sum(x => x.Balance) ?? 0,
                    store_id = cl.First().store_id,
                    min_mum=cl.First().min_mum,
                    is_stop = cl.First().is_stop,
                    store_name = "",
                }).ToList();
                gv_product.Columns[nameof(product_serch_View.store_name)].Visible = false;
                gv_product.Columns[nameof(product_serch_View.min_mum)].Visible = true;

            }
            gv_product.Columns[nameof(product_serch_View.id)].Visible = false;
            gv_product.Columns[nameof(product_serch_View.fullname)].Visible = false;
            gv_product.Columns[nameof(product_serch_View.update_price)].Visible = false;
            gv_product.Columns[nameof(product_serch_View.store_id)].Visible = false;
            gv_product.Columns[nameof(product_serch_View.name)].HeaderText = "الاسم";
            gv_product.Columns[nameof(product_serch_View.price_sale)].HeaderText = "سعر البيع محل";                                      
            gv_product.Columns[nameof(product_serch_View.price_sale_100)].HeaderText = "سعر البيع  100";
            gv_product.Columns[nameof(product_serch_View.price_sale_75)].HeaderText = "سعر البيع 75";
            gv_product.Columns[nameof(product_serch_View.price_sale_vip2)].HeaderText = "سعر البيع VIP2";
            gv_product.Columns[nameof(product_serch_View.price_sale_vip1)].HeaderText = "سعر البيع VIP1";                                      
            //gv_product.Columns[nameof(product_serch_View.update_price)].HeaderText = "تاريخ تحديث السعر ";
            gv_product.Columns[nameof(product_serch_View.code)].HeaderText = "كود";
            gv_product.Columns[nameof(product_serch_View.is_stop)].HeaderText = "موقوف ";
            gv_product.Columns[nameof(product_serch_View.Balance)].HeaderText = "الرصيد ";
            gv_product.Columns[nameof(product_serch_View.store_name)].HeaderText = "المخزن";
            gv_product.Columns[nameof(product_serch_View.min_mum)].HeaderText = "اقل كمية";
            gv_product.Columns[nameof(product_serch_View.is_stop)].SortMode=DataGridViewColumnSortMode.Automatic;
            gv_product.CurrentCell = null;



            qq = (List<product_serch_View>)gv_product.DataSource;
            lp_price_sale.Text = qq.Sum(x => x.price_sale * x.Balance ).ToString("0.00");
            lp_price_sale_100.Text = qq.Sum(x => x.price_sale_100 * x.Balance ).ToString("0.00");
            lp_price_sale_75.Text = qq.Sum(x => x.price_sale_75 * x.Balance ).ToString("0.00");
            lp_price_sale_vip2.Text = qq.Sum(x => x.price_sale_vip2 * x.Balance ).ToString("0.00");
            lp_price_sale_vip1.Text = qq.Sum(x => x.price_sale_vip1 * x.Balance ).ToString("0.00");
            lp_price_1.Text = qq.Sum(x => x.price_1 * x.Balance ).ToString("0.00");
            lp_price_2.Text = qq.Sum(x => x.price_2 * x.Balance ).ToString("0.00");
            lp_price_3.Text = qq.Sum(x => x.price_3 * x.Balance ).ToString("0.00");
            lp_price_4.Text = qq.Sum(x => x.price_4 * x.Balance ).ToString("0.00");
            lp_price_5.Text = qq.Sum(x => x.price_5 * x.Balance ).ToString("0.00");
            lp_price_6.Text = qq.Sum(x => x.price_6 * x.Balance ).ToString("0.00");
            lp_price_7.Text = qq.Sum(x => x.price_7 * x.Balance ).ToString("0.00");
            lp_price_8.Text = qq.Sum(x => x.price_8 * x.Balance ).ToString("0.00");
            lp_price_9.Text = qq.Sum(x => x.price_9 * x.Balance ).ToString("0.00");
          lp_price_10.Text = qq.Sum(x => x.price_10 * x.Balance ).ToString("0.00");
            lp_total.Text = qq.Sum(x => x.Balance).ToString("0.000");
        }
        private void gv_mariddata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!Session._setting.update_product)
                return;
            if (e.RowIndex < 0)
                return;
            int id = Convert.ToInt32(gv_product.Rows[e.RowIndex].Cells[nameof(product.id)].Value.ToString());
            add_product frm_add_Product = new add_product(id);
            frm_add_Product.ShowDialog();
            db = new DataClasses1DataContext();
            tx_serch_TextChanged(null, null);
        }
        private void tx_serch_TextChanged(object sender, EventArgs e)
        {
            //gv_product.DataSource = db.product_serch_Views.OrderBy(x => x.name).Where(x => (x.name.Contains(tx_serch.Text.Replace_text()) || x.code.Contains(tx_serch.Text)) && (!ch_zero.Checked || x.Balance != 0) ).OrderByDescending(x => x.name.StartsWith(tx_serch.Text.Replace_text()) );
            //gv_product.CurrentCell = null;
            refrsfgv();
        }
        private void btn_print_Click(object sender, EventArgs e)
        {
            if (gv_product.RowCount == 0)
                return;
            DataClasses1DataContext data = new DataClasses1DataContext();
            ReportDataSource[] ReportDataSource = new ReportDataSource[]
            {
             new ReportDataSource("frmproduct", gv_product.DataSource),
            };
            frm_show_report _Report = new frm_show_report(null, "frmproduct", ReportDataSource, true);
            _Report.Show();
        }

        private void ch_zero_CheckedChanged(object sender, EventArgs e)
        {
            refrsfgv();
        }
        private void btn_export_exal_Click(object sender, EventArgs e)
        {
            if (gv_product.Rows.Count <= 0)
                return;
            lb_mas.Text = "  جاري انشاء ملف الاكسيل ...";
            string autosave = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\EasyTransfer";
            if (!Directory.Exists(autosave))
            {
                System.IO.Directory.CreateDirectory(autosave);
            }
            gv_product.MultiSelect = true;
            gv_product.RightToLeft = System.Windows.Forms.RightToLeft.No;
            gv_product.SelectAll();

            Clipboard.SetDataObject(this.gv_product.GetClipboardContent());
            gv_product.MultiSelect = false;
            gv_product.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = false;
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "EasyTransfer";
            worksheet.PasteSpecial();
            worksheet.Columns[2].NumberFormat = "0";
            worksheet.Columns[4].NumberFormat = "@";
            string path = autosave + @"\" + DateTime.Now.Ticks + "Response.xlsx";
            workbook.SaveAs(path, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            app.Quit();
            lb_mas.Text = @"تم حفظ الملف  \" + path + "";
            gv_product.Focus();
            gv_product.CurrentRow.Selected = true;
        }

        private void frmproduct_Load(object sender, EventArgs e)
        {

        }
    }
}
