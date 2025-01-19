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
    public partial class all_InvoiceHeader_in : Form
    {
        DataClasses1DataContext db;
        public all_InvoiceHeader_in()
        {
            InitializeComponent();
        }
        InvoiceHeaderView_in invoiceHeaderView_ins;
        private void all_kushufat_Load(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();
            getdata();
            gv.Columns[nameof(invoiceHeaderView_ins.id)].Visible = false;
            gv.Columns[nameof(invoiceHeaderView_ins.name_invoice_type)].Visible = false;
            gv.Columns[nameof(invoiceHeaderView_ins.id_invoice_type)].Visible = false;
            gv.Columns[nameof(invoiceHeaderView_ins.id_fara)].Visible = false;
            gv.Columns[nameof(invoiceHeaderView_ins.id_user)].Visible = false;
            gv.Columns[nameof( invoiceHeaderView_ins .id)].HeaderText = "رقم الفاتورة ";
            gv.Columns[nameof( invoiceHeaderView_ins .Notes)].HeaderText = "ملاحظات ";
            gv.Columns[nameof(invoiceHeaderView_ins.DateAdd)].HeaderText = "تاريخ ";
            //gv.Columns[nameof(invoiceHeaderView_ins.nots_store)].HeaderText = "نوع العملية";
            //gv.Columns[nameof(invoiceHeaderView_ins.name_invoice_type)].HeaderText = "العملية";
            gv.Columns[nameof(invoiceHeaderView_ins.user_name)].HeaderText = "الموظف";
            gv.Columns[nameof(invoiceHeaderView_ins.name_fara)].HeaderText = "فرع";
        }
        string p_date_from;
        string p_date_to;
        public void getdata()
        {
            db = new DataClasses1DataContext();
            gv.DataSource = db.InvoiceHeaderView_ins.Where(x => x.id_invoice_type==2&&
            (x.id_fara == Session.User_login.id_fara) &&
            (x.DateAdd.Date >= dt_date_from.Value.Date) &&
            (x.DateAdd.Date <= dt_date_to.Value.Date)&&
            (x.Notes.Contains(tx_nots.Text)) 
            ).OrderByDescending(x => x.id).ToList();
            gv.CurrentCell = null;            
            p_date_from = dt_date_from.Value.ToString();
            p_date_to = dt_date_to.Value.ToString();
        }
        private void bt_search_Click(object sender, EventArgs e)
        {
            getdata();
        }
        private void gv_kushf_with_marid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            int id = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[0].Value.ToString());            
            frm_InvoiceHeader_in kushufat = new frm_InvoiceHeader_in(id);
            kushufat.ShowDialog();
            getdata();
        }
        private void btn_print_Click(object sender, EventArgs e)
        {
            if (gv.RowCount == 0)
                return;
            List<ReportParameter> para = new List<ReportParameter>();
            para.Add(new ReportParameter("p_date_from", p_date_from));
            para.Add(new ReportParameter("p_dt_date_to", p_date_to));
            ReportDataSource[] ReportDataSource = new ReportDataSource[]
            {
             new ReportDataSource("InvoiceHeaderView", gv.DataSource),
            };
            frm_show_report _Report = new frm_show_report(para, "all_InvoiceHeader", ReportDataSource, true);
            _Report.Show();
        }
    }
}
