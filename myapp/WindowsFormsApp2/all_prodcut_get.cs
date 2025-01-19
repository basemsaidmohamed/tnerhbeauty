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
    public partial class all_prodcut_get : Form
    {
        DataClasses1DataContext db;
        public all_prodcut_get()
        {
            InitializeComponent();
        }
        private void all_kushufat_Load(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();
            gv.DataSource=new List<prodcut_get_View>();
            gv.Columns[nameof(prodcut_get_View.id)].Visible = false;
            gv.Columns[nameof(prodcut_get_View.id_cient)].Visible = false;
            gv.Columns[nameof(prodcut_get_View.ItemID)].Visible = false;

            gv.Columns[nameof(prodcut_get_View.Client_name)].HeaderText = "اسم العميل";
            gv.Columns[nameof(prodcut_get_View.code)].HeaderText = "كود الصنف";
            gv.Columns[nameof(prodcut_get_View.product_name)].HeaderText = "  اسم الصنف";
            gv.Columns[nameof(prodcut_get_View.ItemQty)].HeaderText = "الكمية";
            gv.Columns[nameof(prodcut_get_View.Total)].HeaderText = "السعر";
            gv.Columns[nameof(prodcut_get_View.DateAdd)].HeaderText = "تاريخ الفاتورة";
            gv.Columns[nameof(prodcut_get_View.is_agel)].HeaderText = "اجل";
            dr_report.SelectedIndex = 0;
getdata();
            
        }
        int id = 0;
        private void bt_serch_client_Click(object sender, EventArgs e)
        {
            selct_sick _selct_Sick = new selct_sick();
            _selct_Sick.ShowDialog();
            if (_selct_Sick.retrnval() == 0)
            {
                id = 0;
                tx_name.Text ="";
                return;
            }
            id = _selct_Sick.retrnval();
            Client selctmarid = db.Clients.Where(x => x.id == id).FirstOrDefault();
            if(selctmarid!=null)
            tx_name.Text = selctmarid.name;
        }
        string p_name_client = "";
        string p_prodct = "";
        string p_date_from;
        string p_date_to;
        string p_report_name = "";
        string reportname="";
        int reportselct = 0;
        private void bt_search_Click(object sender, EventArgs e)
        {
            getdata();

        }
       public void getdata()
        {
            gv.Columns[nameof(prodcut_get_View.DateAdd)].Visible = false;
            gv.Columns[nameof(prodcut_get_View.is_agel)].Visible = false;
            //gv.Columns[nameof(prodcut_get_View.Client_name)].Visible = false;
            
            var notx_id = id == 0 ? true : false;
            var notx_ItemID = ItemID == 0 ? true : false;
            var q = db.prodcut_get_Views.Where(x =>
            (x.ItemID == ItemID || notx_ItemID) &&
            (x.id_cient == id || notx_id) &&
            (x.DateAdd.Date >= dt_date_from.Value.Date) &&
            (x.DateAdd.Date <= dt_date_to.Value.Date));

            if (dr_report.SelectedIndex == 0)
            {
                gv.DataSource = q.OrderByDescending(x => x.id).Take(300).ToList();
                gv.Columns[nameof(prodcut_get_View.DateAdd)].Visible = true;
                gv.Columns[nameof(prodcut_get_View.is_agel)].Visible = true;
                gv.Columns[nameof(prodcut_get_View.Client_name)].Visible = true;
                reportname = "all_prodcut_get";
            }
            
            if (dr_report.SelectedIndex == 1)
            {
                gv.DataSource = q.GroupBy(x => new { x.id_cient, x.ItemID }).Select(cl => new prodcut_get_View
                 {
                    Client_name = cl.First().Client_name,
                    ItemID = cl.First().ItemID,
                    product_name = cl.First().product_name,
                    //id = cl.Count(c => c.id!=null),
                    ItemQty = cl.Sum(c => c.ItemQty),
                    Total = cl.Sum(c => c.Total),
                    code = cl.First().code,
                }).ToList();
                //if(notx_id)


                gv.Columns[nameof(prodcut_get_View.Client_name)].Visible = true;
                //gv.Columns[nameof(prodcut_get_View.id)].Visible = true;
                //gv.Columns[nameof(prodcut_get_View.id)].HeaderText = "عدد الفواتير";
                reportname = "all_prodcut_get_1";
            }
            if (dr_report.SelectedIndex == 2)
            {
                gv.DataSource = q.GroupBy(x => new { x.ItemID }).Select(cl => new prodcut_get_View
                {
                    Client_name = !notx_id ? cl.First().Client_name : "",
                    ItemID = cl.First().ItemID,
                    product_name = cl.First().product_name,
                    ItemQty = cl.Sum(c => c.ItemQty),
                    Total = cl.Sum(c => c.Total),
                    code = cl.First().code,
                }).ToList();
                reportname = "all_prodcut_get_2";

            }

            gv.CurrentCell = null;
            int count_gv = gv.Rows.Count;
            lb_mas.Text = " عدد  :  " + count_gv + " # ";
            lb_mas.Text += " اجمالي  السعر  :   " + Session.Convertdecimal(gv.Rows.Cast<DataGridViewRow>().Sum(t => Session.Convertdecimal(t.Cells[nameof(prodcut_get_View.Total)].Value.ToString())).ToString()).ToString("0.00") + " # ";
            lb_mas.Text += " اجمالي  الكمية   :   " + Session.Convertdecimal(gv.Rows.Cast<DataGridViewRow>().Sum(t => Session.Convertdecimal(t.Cells[nameof(prodcut_get_View.ItemQty)].Value.ToString())).ToString()).ToString("0.000");
            if (count_gv == 300)
                lb_mas.Text += "  # لم يتم استدعاء البيانات بالكامل ";



            p_date_from = null;
            p_date_to = null;
            p_name_client = tx_name.Text;
            p_report_name = dr_report.Text;
            p_date_from = dt_date_from.Value.ToString();
            p_date_to = dt_date_to.Value.ToString();
            p_prodct = tx_prodct.Text;
            reportselct = dr_report.SelectedIndex;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            id = 0;
            tx_name.Text = "";
        }       
        private void gv_kushf_with_marid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (reportselct == 0)
            {
                int id = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[0].Value.ToString());
                frm_InvoiceHeader kushufat = new frm_InvoiceHeader(id);
                kushufat.ShowDialog();
                bt_search.PerformClick();
            }
            //if (reportselct == 1)
            //{
            //    ItemID = Session.ConvertInt(gv.Rows[e.RowIndex].Cells[nameof(prodcut_get_View.ItemID)].Value.ToString());
            //    string prod_name = gv.Rows[e.RowIndex].Cells[nameof(prodcut_get_View.product_name)].Value.ToString();
            //    string prod_code = gv.Rows[e.RowIndex].Cells[nameof(prodcut_get_View.code)].Value.ToString();

            //    tx_prodct.Text = prod_name + " " + prod_code;

            //    id = Session.ConvertInt(gv.Rows[e.RowIndex].Cells[nameof(prodcut_get_View.id_cient)].Value.ToString()); ;
            //    tx_name.Text = gv.Rows[e.RowIndex].Cells[nameof(prodcut_get_View.Client_name)].Value.ToString();
            //    dr_report.SelectedIndex = 0;
            //    getdata();
            //}
            //if (reportselct == 2)
            //{
            //    ItemID = Session.ConvertInt(gv.Rows[e.RowIndex].Cells[nameof(prodcut_get_View.ItemID)].Value.ToString());
            //    string prod_name = gv.Rows[e.RowIndex].Cells[nameof(prodcut_get_View.product_name)].Value.ToString();
            //    string prod_code = gv.Rows[e.RowIndex].Cells[nameof(prodcut_get_View.code)].Value.ToString();

            //    tx_prodct.Text = prod_name + " " + prod_code;

            //    //id = 0; ;
            //    //tx_name.Text = "";
            //    dr_report.SelectedIndex = 1;
            //    getdata();
            //}

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
            para.Add(new ReportParameter("p_dt_date_to", p_date_to));
            para.Add(new ReportParameter("p_name_client", p_name_client));
            para.Add(new ReportParameter("p_prodct", p_prodct));
            para.Add(new ReportParameter("p_report_name", p_report_name));
            ReportDataSource[] ReportDataSource = new ReportDataSource[]
            {
             new ReportDataSource("prodcut_get_View", gv.DataSource),
            };
            frm_show_report _Report = new frm_show_report(para, reportname, ReportDataSource, true);
            _Report.Show();
        }
    }
}
