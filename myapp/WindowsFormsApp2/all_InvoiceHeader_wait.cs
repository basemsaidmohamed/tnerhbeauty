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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace tnerhbeauty
{
    public partial class all_InvoiceHeader_wait : Form
    {
        int id = 0;
        DataClasses1DataContext db;
        public all_InvoiceHeader_wait()
        {
            InitializeComponent();
        }       
        private void all_kushufat_Load(object sender, EventArgs e)
        {
            btn_new.Visible = Session._setting.add_invoice_pay;
            db = new DataClasses1DataContext();
            getdata();
            //gv.Columns[nameof(InvoiceHeaderView.id)].Visible = false;
            gv.Columns[nameof(InvoiceHeaderView.id_cient)].Visible = false;
            gv.Columns[nameof(InvoiceHeaderView.id_invoice_type)].Visible = false;
            gv.Columns[nameof(InvoiceHeaderView.id_fara)].Visible = false;
            gv.Columns[nameof(InvoiceHeaderView.id_user)].Visible = false;
            gv.Columns[nameof(InvoiceHeaderView.name_invoice_type)].Visible = false;
            //gv.Columns[nameof(InvoiceHeaderView.name_fara)].Visible = false;
            //gv.Columns[nameof(InvoiceHeaderView.user_name)].Visible = false;
            gv.Columns[nameof(InvoiceHeaderView.name)].HeaderText = "  اسم العميل";
            gv.Columns[nameof(InvoiceHeaderView.Total_product)].Visible = false;
            gv.Columns[nameof(InvoiceHeaderView.Discount)].Visible = false;
            gv.Columns[nameof(InvoiceHeaderView.Extra)].Visible = false;
            gv.Columns[nameof(InvoiceHeaderView.Net)].Visible = false;
            gv.Columns[nameof(InvoiceHeaderView.Notes)].HeaderText = "ملاحظات ";
            gv.Columns[nameof(InvoiceHeaderView.is_agel)].Visible = false;
            gv.Columns[nameof(InvoiceHeaderView.DateAdd)].HeaderText = "تاريخ ";
            //gv.Columns[nameof(InvoiceHeaderView.name_invoice_type)].HeaderText = "العملية";
            gv.Columns[nameof(InvoiceHeaderView.name_fara)].HeaderText = "الفرع";
            gv.Columns[nameof(InvoiceHeaderView.user_name)].HeaderText = "الموظف";
        }
        public void getdata()
        {
            
            var notx_id =  string.IsNullOrWhiteSpace(tx_id.Text);
            var notx_id_cient = id == 0 ? true : false;
            gv.DataSource = db.InvoiceHeaderViews.Where(x =>
            (x.id_invoice_type == 4) &&
            (x.id_fara == Session.User_login.id_fara) &&
            (x.id_user == Session.User_login.id) &&
            (x.id_cient == id || notx_id_cient) &&
            (x.DateAdd.Date >= dt_date_from.Value.Date) &&
            (x.DateAdd.Date <= dt_date_to.Value.Date)&&
            (x.Notes.Contains(tx_nots.Text))&&
            (Convert.ToString(x.id)==(tx_id.Text)|| notx_id)
            ).OrderByDescending(x => x.id).ToList();
            gv.CurrentCell = null;
            lb_mas.Text = " عدد  :  " + gv.Rows.Count + " --- ";
            lb_mas.Text += " اجمالي  مبلغ الصافي  :   " + Session.Convertdecimal(gv.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDouble(t.Cells[nameof(InvoiceHeaderView.Net)].Value)).ToString()).ToString("0.00");
            p_name_client = tx_name.Text;
            p_date_from = dt_date_from.Value.ToString();
            p_date_to = dt_date_to.Value.ToString();
        }
        
        private void bt_aladawia_Click(object sender, EventArgs e)
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
        string p_date_from;
        string p_date_to;
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
            int id_invoice = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[nameof(InvoiceHeader.id)].Value.ToString());
            db = new DataClasses1DataContext();
            int id_type = db.InvoiceHeaders.Where(x=>x.id== id_invoice).FirstOrDefault().id_invoice_type;
            if (id_type == 4)
            {
                frm_InvoiceHeader_add_wait kushufat = new frm_InvoiceHeader_add_wait(id_invoice);
                kushufat.ShowDialog();
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
             new ReportDataSource("InvoiceHeaderView", gv.DataSource),
            };
            frm_show_report _Report = new frm_show_report(para, "all_InvoiceHeader", ReportDataSource, true);
            _Report.Show();
        }
        private void btn_new_Click(object sender, EventArgs e)
        {
            if (gv.SelectedRows.Count > 0) {
                int rowindex = gv.CurrentRow.Index;
                int id_invoice = Convert.ToInt32(gv.Rows[rowindex].Cells[nameof(InvoiceHeader.id)].Value.ToString());
                frm_InvoiceHeader_update_wait kushufat = new frm_InvoiceHeader_update_wait(id_invoice);
                kushufat.ShowDialog();
                bt_search.PerformClick();
            }
            else MyMessageBox.showMessage("معلومات", "يجب اختيار فاتورة اولا", "", MessageBoxButtons.RetryCancel);
        }
    }
}
