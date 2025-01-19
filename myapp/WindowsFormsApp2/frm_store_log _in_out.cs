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

namespace tnerhbeauty
{
    public partial class frm_store_log_in_out : Form
    {
        DataClasses1DataContext db;
        public frm_store_log_in_out()
        {
            InitializeComponent();
        }
        store_log_Balance_View _store_log_View;
        private void all_kushufat_Load(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();
            dr_store.IntializeData(db.stores.Where(x => x.is_stop == false).ToList(), "store_name", "id");
            dr_store.SelectedIndex = -1;
            gv.DataSource = new List<store_log_Balance_View>();
            
            gv.Columns[nameof(_store_log_View.store_id)].Visible = false;
            gv.Columns[nameof(_store_log_View.ItemID)].Visible = false;
            gv.Columns[nameof(_store_log_View.DateAdd)].Visible = false;
            gv.Columns[nameof(_store_log_View.code)].HeaderText = "كود الصنف";
            gv.Columns[nameof(_store_log_View.product_name)].HeaderText = "  اسم الصنف";
            gv.Columns[nameof(_store_log_View.ItemQty_in)].HeaderText = "وارد";
            gv.Columns[nameof(_store_log_View.ItemQty_out)].HeaderText = "صادر";
            gv.Columns[nameof(_store_log_View.Balance)].HeaderText = "الرصيد";
            gv.Columns[nameof(_store_log_View.store_name)].HeaderText = "المخزن";
            gv.Columns[nameof(_store_log_View.Balance_sabk)].HeaderText = "رصيد سابق";
            getdata();

        }

        
        string p_name_client = "";
        string p_prodct = "";
        string p_date_from;
       
        public void getdata()
        {
            
            var no_dr_store = dr_store.SelectedIndex == -1 ? true : false;
            var notx_ItemID = ItemID == 0 ? true : false;
            List<store_log_Balance_View> qq = new List<store_log_Balance_View>();
            if (ch_store.Checked)
            {
                qq = db.store_log_Balance_Views.Where(x =>
            (x.ItemID == ItemID || notx_ItemID) &&
            (x.store_id == (int?)dr_store.SelectedValue || no_dr_store)).GroupBy(x => new { x.ItemID, x.store_id })
            .Select(cl => new store_log_Balance_View
            {
                ItemID = cl.First().ItemID,
                code = cl.First().code,
                product_name = cl.First().product_name,
                Balance_sabk = (decimal?)cl.Where(x => x.DateAdd.Date < dt_date_from.Value.Date).Sum(x => (decimal?)x.ItemQty_in - (decimal?)x.ItemQty_out) ?? 0,
                ItemQty_in = (decimal?)cl.Where(x => (x.DateAdd.Date >= dt_date_from.Value.Date)).Sum(x => x.ItemQty_in) ?? 0,
                ItemQty_out = (decimal?)cl.Where(x => (x.DateAdd.Date >= dt_date_from.Value.Date)).Sum(x => x.ItemQty_out) ?? 0,
                Balance = (decimal?)cl.Sum(x => x.ItemQty_in - x.ItemQty_out) ?? 0,
                store_name = cl.First().store_name,
                }).ToList();
                gv.Columns[nameof(_store_log_View.store_name)].Visible = true;
            }
            else
            {
                qq = db.store_log_Balance_Views.Where(x => (x.ItemID == ItemID || notx_ItemID) && (x.store_id == (int?)dr_store.SelectedValue || no_dr_store)).GroupBy(x => new { x.ItemID })
                    .Select(cl => new store_log_Balance_View {
                        ItemID = cl.First().ItemID,
                        code = cl.First().code,
                        product_name = cl.First().product_name,
                        Balance_sabk = (decimal?)cl.Where(x => x.DateAdd.Date < dt_date_from.Value.Date).Sum(x => (decimal?)x.ItemQty_in - (decimal?)x.ItemQty_out) ?? 0,
                        ItemQty_in = (decimal?)cl.Where(x => (x.DateAdd.Date >= dt_date_from.Value.Date)).Sum(x => x.ItemQty_in) ?? 0,
                        ItemQty_out = (decimal?)cl.Where(x => (x.DateAdd.Date >= dt_date_from.Value.Date)).Sum(x => x.ItemQty_out) ?? 0,
                        Balance = (decimal?)cl.Sum(x => x.ItemQty_in - x.ItemQty_out) ?? 0,
                    }).ToList();
                gv.Columns[nameof(_store_log_View.store_name)].Visible = false;
            }
            gv.DataSource = qq.Where(x=> (!ch_zero.Checked || x.Balance != 0)).OrderBy(x => x.ItemID).ToList();
            var _Balance_sabk = qq.Sum(x => (decimal?)x.Balance_sabk) ?? 0;
            var amount_in = qq.Sum(x => (decimal?)x.ItemQty_in) ?? 0;
            var amount_out = qq.Sum(x => (decimal?)x.ItemQty_out) ?? 0;
            var Balance = _Balance_sabk + amount_in - amount_out;
            string s = "";
            if (Balance < 0)
            {
                s = "رصيد زيادة";
                lp_total.ForeColor = Color.Red;
            }
            lb_Balance_sabk.Text = _Balance_sabk.ToString("0.000");
            lp_amunt_in.Text = amount_in.ToString("0.000");
            lp_amunt_out.Text = amount_out.ToString("0.000");
            lp_total.Text = Balance.ToString("0.000") + " " + s;
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
             new ReportDataSource("store_log_Balance_View", gv.DataSource),
            };
            frm_show_report _Report = new frm_show_report(para, "frm_store_log_in_out", ReportDataSource, true);
            _Report.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            getdata();
        }
        private void button3_Click(object sender, EventArgs e)
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