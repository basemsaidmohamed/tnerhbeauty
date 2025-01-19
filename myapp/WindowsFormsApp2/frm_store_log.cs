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
    public partial class frm_store_log : Form
    {
        DataClasses1DataContext db;
        public frm_store_log()
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
            gv.Columns[nameof(_store_log_View.code)].HeaderText = "كود الصنف";
            gv.Columns[nameof(_store_log_View.product_name)].HeaderText = "  اسم الصنف";
            gv.Columns[nameof(_store_log_View.ItemQty_in)].HeaderText = "وارد";
            gv.Columns[nameof(_store_log_View.ItemQty_out)].HeaderText = "صادر";
            gv.Columns[nameof(_store_log_View.Balance)].HeaderText = "الرصيد";
            gv.Columns[nameof(_store_log_View.DateAdd)].HeaderText = "تاريخ";
            gv.Columns[nameof(_store_log_View.nots)].HeaderText = "ملاحظات";
            gv.Columns[nameof(_store_log_View.name_invoice_type)].HeaderText = "نوع العملية";
            gv.Columns[nameof(_store_log_View.store_name)].HeaderText = "المخزن";
            gv.Columns[nameof(_store_log_View.user_name)].HeaderText = "الموظف";
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
            tb.Visible = false;
             var notx_ItemID = ItemID == 0 ? true : false;
            var no_dr_store = dr_store.SelectedIndex == -1 ? true : false;
            List<store_log_View> List_amount_client_View = new List<store_log_View>();
            decimal _Balance_sabk = 0.000m;
            if (!notx_ItemID)
            {
                var q = db.store_log_Views.Where(x => (x.ItemID == ItemID || notx_ItemID) && (x.store_id == (int?)dr_store.SelectedValue || no_dr_store) && x.DateAdd.Date < dt_date_from.Value.Date).ToList();
                var _amount_in = q.Sum(x => (decimal?)x.ItemQty_in) ?? 0;
                var _amount_out = q.Sum(x => (decimal?)x.ItemQty_out) ?? 0;
                 _Balance_sabk = _amount_in - _amount_out;
                if (_Balance_sabk != 0)
                    List_amount_client_View.Add(new store_log_View
                    {
                        name_invoice_type = "رصيد سابق",
                        //ItemQty_in = _amount_in,
                        //ItemQty_out = _amount_out,
                        Balance = !notx_ItemID ? _Balance_sabk : 0,
                    });                
                lb_Balance_sabk.Text = _Balance_sabk.ToString("0.000");
            }
            var data = db.store_log_Views.Where(x =>
            (x.ItemID == ItemID || notx_ItemID) &&
            (x.DateAdd.Date >= dt_date_from.Value.Date) &&
            (x.store_id == (int?)dr_store.SelectedValue || no_dr_store)
            ).OrderBy(x => x.Source_Id);
            List_amount_client_View.AddRange(data);
            decimal sum = 0;
            if(!notx_ItemID)
            foreach (var row in List_amount_client_View)
            {
                row.Balance = sum += row.Balance;
            }
            gv.DataSource = List_amount_client_View.ToList();
            if(_Balance_sabk!=0)
                gv.Rows[0].DefaultCellStyle.BackColor = Color.Orange;
            gv.CurrentCell = null;
            
            if (!notx_ItemID)
            {
                tb.Visible = true;
                var amount_in = List_amount_client_View.Sum(x => (decimal?)x.ItemQty_in) ?? 0;
                var amount_out = List_amount_client_View.Sum(x => (decimal?)x.ItemQty_out) ?? 0;
                var Balance = _Balance_sabk+amount_in - amount_out;
                string s = "";
                if (Balance < 0)
                {
                    s = "رصيد زيادة";
                    lp_total.ForeColor = Color.Red;
                }

                lp_amunt_in.Text = amount_in.ToString("0.000");
                lp_amunt_out.Text = amount_out.ToString("0.000");
                lp_total.Text = Balance.ToString("0.000") + " " + s;
            }
            if (List_amount_client_View.Count == 300)
                lb_mas.Text += "  # لم يتم استدعاء البيانات بالكامل ";

            p_date_from = null;
           
           
            p_date_from = dt_date_from.Value.ToString();
           
            p_prodct = tx_prodct.Text;
            gv.Columns[nameof(_store_log_View.Balance)].Visible = true;
            if (notx_ItemID)
                gv.Columns[nameof(_store_log_View.Balance)].Visible = false;
        }
        private void gv_kushf_with_marid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int type_id = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[nameof(store_log_View.id_type)].Value.ToString());
            if (type_id == 1)
            {
                if (!Session._setting.update_invoice_pay)
                    return;
                int id = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[nameof(store_log_View.Source_Id)].Value.ToString());
                frm_InvoiceHeader kushufat = new frm_InvoiceHeader(id);
                kushufat.ShowDialog();
            }
            if (type_id == 2)
            {
                if (!Session._setting.update_invoice_sale)
                    return;
                int id = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[nameof(store_log_View.Source_Id)].Value.ToString());
                frm_InvoiceHeader_in kushufat = new frm_InvoiceHeader_in(id);
                kushufat.ShowDialog();
            }
            if (type_id == 3)
            {
                if (!Session._setting.update_invoice_to_stroe)
                    return;
                int id = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[nameof(store_log_View.Source_Id)].Value.ToString());
                frm_InvoiceHeader_store kushufat = new frm_InvoiceHeader_store(id);
                kushufat.ShowDialog();
            }
            bt_search.PerformClick();
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
            para.Add(new ReportParameter("p_report_name", "كشف حساب صنف"));
            ReportDataSource[] ReportDataSource = new ReportDataSource[]
            {
             new ReportDataSource("store_log_View", gv.DataSource),
            };
            frm_show_report _Report = new frm_show_report(para, "frm_store_log", ReportDataSource, true);
            _Report.Show();
        }
        private void button1_Click(object sender, EventArgs e)
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