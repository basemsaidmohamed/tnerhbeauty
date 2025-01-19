using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using tnerhbeauty.Class;
using tnerhbeauty.rport;
using Microsoft.Reporting.WinForms;
namespace tnerhbeauty
{
    public partial class all_prodcut_get_sale : Form
    {
        DataClasses1DataContext db;
        string p_prodct = "";
        string p_date_from;
        string p_date_to;
        public all_prodcut_get_sale()
        {
            InitializeComponent();
        }
        private void all_kushufat_Load(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();
            getdata();
            gv.Columns[nameof(prodcut_get_View.id)].Visible = false;
            gv.Columns[nameof(prodcut_get_View.ItemID)].Visible = false;
            gv.Columns[nameof(prodcut_get_View.Client_name)].Visible = false;
            gv.Columns[nameof(prodcut_get_View.DateAdd)].Visible = false;
            gv.Columns[nameof(prodcut_get_View.id_cient)].Visible = false;
            gv.Columns[nameof(prodcut_get_View.is_agel)].Visible = false;
            gv.Columns[nameof(prodcut_get_View.code)].HeaderText = "كود الصنف";
            gv.Columns[nameof(prodcut_get_View.product_name)].HeaderText = "  اسم الصنف";
            gv.Columns[nameof(prodcut_get_View.ItemQty)].HeaderText = " اجمالي الكمية";
            gv.Columns[nameof(prodcut_get_View.Total)].HeaderText = "اجمالي السعر ";
            p_date_from = dt_date_from.Value.ToString();
            p_date_to = dt_date_to.Value.ToString();
        }
       
        private void bt_search_Click(object sender, EventArgs e)
        {
            getdata();
        }
       public void getdata()
        {
            string itm = "%";
            if (ItemID != 0)
                itm = ItemID.ToString();
            var q = db.ExecuteQuery<prodcut_get_View>(Session.quarygetallprodcutsale(dt_date_from.Value.Date.ToString("MM/dd/yyyy"), dt_date_to.Value.Date.ToString("MM/dd/yyyy"), itm)).Where(x => x.Total > 0).OrderBy(x => x.product_name).ToList();
            gv.DataSource = q;
            gv.CurrentCell = null;
            int count_gv = gv.Rows.Count;
            lb_mas.Text = " عدد  :  " + count_gv + " # ";
            lb_mas.Text += " اجمالي  السعر  :   " + Session.Convertdecimal(gv.Rows.Cast<DataGridViewRow>().Sum(t => Session.Convertdecimal(t.Cells[nameof(prodcut_get_View.Total)].Value.ToString())).ToString()).ToString("0.00") + " # ";
            lb_mas.Text += " اجمالي  الكمية   :   " + Session.Convertdecimal(gv.Rows.Cast<DataGridViewRow>().Sum(t => Session.Convertdecimal(t.Cells[nameof(prodcut_get_View.ItemQty)].Value.ToString())).ToString()).ToString("0.000");
            if (count_gv == 300)
                lb_mas.Text += "  # لم يتم استدعاء البيانات بالكامل ";

            p_date_from = null;
            p_date_to = null;
            p_prodct = tx_prodct.Text;
            if (dt_date_from.Checked)
                p_date_from = dt_date_from.Value.ToString();
            if (dt_date_to.Checked)
                p_date_to = dt_date_to.Value.ToString();
        }
        private void btn_print_Click(object sender, EventArgs e)
        {
            if (gv.RowCount == 0)
                return;
            List<ReportParameter> para = new List<ReportParameter>();
            para.Add(new ReportParameter("p_date_from", p_date_from));
            para.Add(new ReportParameter("p_dt_date_to", p_date_to));
            para.Add(new ReportParameter("p_prodct", p_prodct));
            ReportDataSource[] ReportDataSource = new ReportDataSource[]
            {
             new ReportDataSource("prodcut_get_View", gv.DataSource),
            };
            frm_show_report _Report = new frm_show_report(para, "all_prodcut_get_2", ReportDataSource, true);
            _Report.Show();
        }
        int ItemID = 0;
        private void bt_product_Click(object sender, EventArgs e)
        {
            selct_prodct _selct_prodct = new selct_prodct();
            _selct_prodct.ShowDialog();
            if (_selct_prodct.retrnval() == 0)
            {
                ItemID = 0;
                tx_prodct.Text = "";
                return;
            }
            ItemID = _selct_prodct.retrnval();
            product prod = db.products.Where(x => x.id == ItemID).FirstOrDefault();
            if (prod != null)
            {
                tx_prodct.Text = prod.name +" "+prod.code;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ItemID = 0;
            tx_prodct.Text = "";
        }
    }
}
