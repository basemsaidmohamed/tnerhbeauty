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
    public partial class frm_store_log_stores : Form
    {
        DataClasses1DataContext db;
        public frm_store_log_stores()
        {
            InitializeComponent();
        }
        store_log_View _store_log_View;
        private void all_kushufat_Load(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();
            dr_store.IntializeData(db.stores.Where(x => x.is_stop == false).ToList(), "store_name", "id");
            dr_store.SelectedIndex = -1;
            gv.DataSource = new List<store_log_View>();
            gv.Columns[nameof(_store_log_View.id)].Visible = false;
            gv.Columns[nameof(_store_log_View.store_id)].Visible = false;
            gv.Columns[nameof(_store_log_View.ItemID)].Visible = false;
            gv.Columns[nameof(_store_log_View.id_type)].Visible = false;
            gv.Columns[nameof(_store_log_View.Source_Id)].Visible = false;
            gv.Columns[nameof(_store_log_View.user_name)].Visible = false;
            gv.Columns[nameof(_store_log_View.name_invoice_type)].Visible = false;
            gv.Columns[nameof(_store_log_View.ItemQty_in)].Visible = false;
            gv.Columns[nameof(_store_log_View.ItemQty_out)].Visible = false;
            gv.Columns[nameof(_store_log_View.DateAdd)].Visible = false;
            gv.Columns[nameof(_store_log_View.DateAdd)].Visible = false;
            gv.Columns[nameof(_store_log_View.nots)].Visible = false;

            gv.Columns[nameof(_store_log_View.code)].HeaderText = "كود الصنف";
            gv.Columns[nameof(_store_log_View.product_name)].HeaderText = "  اسم الصنف";

            gv.Columns[nameof(_store_log_View.Balance)].HeaderText = "الرصيد";
           
            gv.Columns[nameof(_store_log_View.store_name)].HeaderText = "المخزن";
           
            getdata();

        }
       
        
        string p_name_client = "";
        string p_prodct = "";
        string p_date_from;
       
       
        private void bt_search_Click(object sender, EventArgs e)
        {
            getdata();
        }
       public void getdata()
        {
            var no_dr_store = dr_store.SelectedIndex == -1 ? true : false;
            var notx_ItemID = ItemID == 0 ? true : false;
            List<store_log_View> Store_log_Balance_View = new List<store_log_View>();
            if (ch_store.Checked)
            {
                Store_log_Balance_View = db.store_log_Views.Where(x =>
                (x.ItemID == ItemID || notx_ItemID) &&
                (x.store_id == (int?)dr_store.SelectedValue || no_dr_store)

                ).GroupBy(x => new { x.ItemID,x.store_id }).Select(cl => new store_log_View
                {
                    store_id = cl.First().store_id,
                    ItemID = cl.First().ItemID,
                    code = cl.First().code,
                    product_name = cl.First().product_name,
                    Balance = (decimal?)cl.Sum(x => x.ItemQty_in - x.ItemQty_out) ?? 0,
                    store_name = cl.First().store_name,
                }).OrderBy(x => x.ItemID).ToList();
                gv.Columns[nameof(_store_log_View.store_name)].Visible = true;
            }
            else
            {
                Store_log_Balance_View = db.store_log_Views.Where(x =>
                   (x.ItemID == ItemID || notx_ItemID) &&
                   (x.store_id == (int?)dr_store.SelectedValue || no_dr_store)

                       ).GroupBy(x => new { x.ItemID }).Select(cl => new store_log_View
                       {
                           ItemID = cl.First().ItemID,
                           code = cl.First().code,
                           product_name = cl.First().product_name,
                           Balance = (decimal?)cl.Sum(x => x.ItemQty_in - x.ItemQty_out) ?? 0,                  
                       }).OrderBy(x => x.ItemID).ToList();
                        gv.Columns[nameof(_store_log_View.store_name)].Visible = false;
                    }
            gv.DataSource = Store_log_Balance_View.Where(x => (!ch_zero.Checked || x.Balance != 0)).ToList();

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
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ItemID = 0;
            tx_prodct.Text = "";
        }
        private void btn_print_Click(object sender, EventArgs e)
        {
            if (gv.RowCount == 0)
                return;
            List<ReportParameter> para = new List<ReportParameter>();
            para.Add(new ReportParameter("p_date_from", p_date_from));
            para.Add(new ReportParameter("p_dt_date_to", p_date_from));
            para.Add(new ReportParameter("p_name_client", p_name_client));
            para.Add(new ReportParameter("p_prodct", p_prodct));
            para.Add(new ReportParameter("p_report_name", lp_titel.Text));
            ReportDataSource[] ReportDataSource = new ReportDataSource[]
            {
             new ReportDataSource("store_log_View", gv.DataSource),
            };
            frm_show_report _Report = new frm_show_report(para, "frm_store_log_stores", ReportDataSource, true);
            _Report.Show();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            dr_store.SelectedIndex = -1;
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