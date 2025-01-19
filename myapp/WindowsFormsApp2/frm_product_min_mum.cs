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
using tnerhbeauty;
using System.Runtime.InteropServices;

namespace tnerhbeauty
{
    public partial class frm_product_min_mum : Form
    {
        DataClasses1DataContext db;
        public frm_product_min_mum()
        {
            InitializeComponent();
        }
        product_min_mum_View _product_Min_Mum;
        private void all_kushufat_Load(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();
            gv.DataSource = new List<product_min_mum_View>();
            gv.Columns[nameof(_product_Min_Mum.id)].Visible = false;
            gv.Columns[nameof(_product_Min_Mum.fullname)].HeaderText = " اسم الصنف";
            gv.Columns[nameof(_product_Min_Mum.Balance)].HeaderText = "الرصيد الحالي";
            gv.Columns[nameof(_product_Min_Mum.min_mum)].HeaderText = "الحد الادني";
            gv.Columns[nameof(_product_Min_Mum.want)].HeaderText = "الكمية المطلوبه";
            getdata();
        }
        string p_prodct = "";
        private void bt_search_Click(object sender, EventArgs e)
        {
            getdata();
        }
       public void getdata()
        {
            gv.DataSource = db.product_min_mum_Views.Where(x =>Convert.ToString( x.id).Contains(Convert.ToString( ItemID))).ToList();
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
                tx_prodct.Text = prod.name+" "+prod.code;
            getdata();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ItemID = 0;
            tx_prodct.Text = "";
            getdata();
        }
        private void btn_print_Click(object sender, EventArgs e)
        {
            if (gv.RowCount == 0)
                return;
            ReportDataSource[] ReportDataSource = new ReportDataSource[]
            {
             new ReportDataSource("product_min_mum", gv.DataSource),
            };
            frm_show_report _Report = new frm_show_report(null, "frm_product_min_mum", ReportDataSource, true);
            _Report.Show();
        }       
    }
}

























//List<store_log_Balance_View> Store_log_Balance_View = new List<store_log_Balance_View>();

//var qq = db.store_log_Balance_Views.GroupBy(x => x.ItemID).Select(cl => new store_log_Balance_View
//{

//    ItemID = cl.First().ItemID,
//    code = cl.First().code,
//    product_name = cl.First().product_name,
//    Balance_sabk = (decimal?)cl.Where(x => x.DateAdd.Date < dt_date_from.Value.Date).Sum(x => (decimal?)x.ItemQty_in - (decimal?)x.ItemQty_out) ?? 0,
//    ItemQty_in = (decimal?)cl.Where(x => (x.DateAdd.Date >= dt_date_from.Value.Date) && (x.DateAdd.Date <= dt_date_to.Value.Date)).Sum(x => x.ItemQty_in) ?? 0,
//    ItemQty_out = (decimal?)cl.Where(x => (x.DateAdd.Date >= dt_date_from.Value.Date) && (x.DateAdd.Date <= dt_date_to.Value.Date)).Sum(x => x.ItemQty_out) ?? 0,
//    Balance = (decimal?)cl.Where(x => x.DateAdd.Date < dt_date_to.Value).Sum(x => x.ItemQty_in - x.ItemQty_out) ?? 0,
//}).ToList();

//gv.DataSource = qq;