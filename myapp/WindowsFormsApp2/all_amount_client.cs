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
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace tnerhbeauty
{
    public partial class all_amount_client : Form
    {
        string typename = "add_amount_client";
        DataClasses1DataContext db;
        amount_client_View _amount_client_View;
        string p_name_client = "";
        string p_date_from;
        string p_date_to;
        public all_amount_client()
        {
            InitializeComponent();
        }
        private void all_kushufat_Load(object sender, EventArgs e)
        {
            
            db = new DataClasses1DataContext();
            getdata();
            gv.Columns[nameof(_amount_client_View.id)].Visible = false;
            gv.Columns[nameof(_amount_client_View.id_client)].Visible = false;
            gv.Columns[nameof(_amount_client_View.id_type)].Visible = false;
            gv.Columns[nameof(_amount_client_View.Source_Id)].Visible = false;
            gv.Columns[nameof(_amount_client_View.type)].Visible = false;
            gv.Columns[nameof(_amount_client_View.Balance)].Visible = false;


            gv.Columns[nameof(_amount_client_View.name_client)].HeaderText = "اسم العميل";
            gv.Columns[nameof(_amount_client_View.name_type)].HeaderText = "نوع العمليه";
            gv.Columns[nameof(_amount_client_View.amount_in)].HeaderText = "مبلغ وارد";
            gv.Columns[nameof(_amount_client_View.amount_out)].HeaderText = "  مبلغ صادر";
            gv.Columns[nameof(_amount_client_View.nots)].HeaderText = "ملاحظات";
            gv.Columns[nameof(_amount_client_View.DateAdd)].HeaderText = "تاريخ ";
            gv.Columns[nameof(_amount_client_View.user_name)].HeaderText = "الموظف ";
            gv.Columns[nameof(_amount_client_View.name_fara)].HeaderText = "الفرع ";
            //List<amount_client_type> ts = new List<amount_client_type>();
            //ts = Session.Amount_client_type;

            //ts.Insert(0, new amount_client_type() { id = -1, name = "" });
            dr_type.IntializeData(Session.Amount_client_type.Where(x => x.type == typename).ToList());


            dr_type.SelectedIndex = -1;
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

        private void bt_search_Click(object sender, EventArgs e)
        {
            getdata();
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

            int souceid = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[nameof(_amount_client_View.Source_Id)].Value.ToString());
            if (souceid == 0)
            {
                int id = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[nameof(_amount_client_View.id)].Value.ToString());
                add_amount_client _add_amount_client = new add_amount_client(id);
                _add_amount_client.ShowDialog();
            }
            else
            {
                frm_InvoiceHeader _frm_InvoiceHeader = new frm_InvoiceHeader(souceid);
                _frm_InvoiceHeader.ShowDialog();
            }
            bt_search.PerformClick();
        }
        
        private void btn_print_Click(object sender, EventArgs e)
        {
            if (gv.RowCount == 0)
                return;
            List<ReportParameter> para = new List<ReportParameter>();
            para.Add(new ReportParameter("p_date_from", p_date_from));
            para.Add(new ReportParameter("p_dt_date_to", p_date_to));
            para.Add(new ReportParameter("p_name_client", p_name_client));
            ReportDataSource[] ReportDataSource = new ReportDataSource[]
            {
             new ReportDataSource("all_amount_client", gv.DataSource),
             
            };
            frm_show_report _Report = new frm_show_report(para, "all_amount_client", ReportDataSource, true);
            _Report.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dr_type.SelectedIndex = -1;
        }
        public void getdata()
        {
            var notx_id = id == 0 ? true : false;
            var no_dr_type = dr_type.SelectedIndex == -1 ? true : false;


            gv.DataSource = db.amount_client_Views.Where(x => x.type == typename &&
            (x.nots.Contains(tx_nots.Text.Replace_text())) &&
            (no_dr_type || x.id_type == (int?)dr_type.SelectedValue) &&
            (x.id_client == id || notx_id) &&
            ( x.DateAdd.Date >= dt_date_from.Value.Date) &&
            ( x.DateAdd.Date <= dt_date_to.Value.Date)).OrderByDescending(x => x.id).Take(300).ToList();



            gv.CurrentCell = null;
            int count_gv = gv.Rows.Count;
            lb_mas.Text = " عدد  :  " + count_gv + " # ";
            lb_mas.Text += " اجمالي  المبالغ الوارده  :   " + Session.Convertdecimal(gv.Rows.Cast<DataGridViewRow>().Sum(t => Session.Convertdecimal(t.Cells[nameof(_amount_client_View.amount_in)].Value.ToString())).ToString()).ToString("0.00") + " # ";
            lb_mas.Text += " اجمالي  المبلغ الصادرة   :   " + Session.Convertdecimal(gv.Rows.Cast<DataGridViewRow>().Sum(t => Session.Convertdecimal(t.Cells[nameof(_amount_client_View.amount_out)].Value.ToString())).ToString()).ToString("0.00");
            if (count_gv == 300)
                lb_mas.Text += "  # لم يتم استدعاء البيانات بالكامل ";
            p_date_from = null;
            p_date_to = null;
            p_name_client = tx_name.Text;
            if (dt_date_from.Checked)
                p_date_from = dt_date_from.Value.ToString();
            if (dt_date_to.Checked)
                p_date_to = dt_date_to.Value.ToString();
        }
    }
}
