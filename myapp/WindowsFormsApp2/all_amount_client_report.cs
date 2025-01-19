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
    public partial class all_amount_client_report : Form
    {

        DataClasses1DataContext db;
        amount_client_View _amount_client_View;
       
        public all_amount_client_report()
        {
            InitializeComponent();
        }
        private void all_kushufat_Load(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();
            gv.DataSource = new List<amount_client_View>();
            gv.Columns[nameof(_amount_client_View.id)].Visible = false;
            gv.Columns[nameof(_amount_client_View.id_client)].Visible = false;
            gv.Columns[nameof(_amount_client_View.id_type)].Visible = false;
            gv.Columns[nameof(_amount_client_View.Source_Id)].Visible = false;
            gv.Columns[nameof(_amount_client_View.type)].Visible = false;
            gv.Columns[nameof(_amount_client_View.name_client)].Visible = false;


            gv.Columns[nameof(_amount_client_View.name_client)].HeaderText = "اسم العميل";
            gv.Columns[nameof(_amount_client_View.name_type)].HeaderText = "نوع العمليه";
            gv.Columns[nameof(_amount_client_View.amount_in)].HeaderText = "مبلغ وارد";
            gv.Columns[nameof(_amount_client_View.amount_out)].HeaderText = "مبلغ صادر";
            gv.Columns[nameof(_amount_client_View.Balance)].HeaderText = "الرصيد";
            gv.Columns[nameof(_amount_client_View.nots)].HeaderText = "ملاحظات";
            gv.Columns[nameof(_amount_client_View.DateAdd)].HeaderText = "تاريخ";
            gv.Columns[nameof(_amount_client_View.user_name)].HeaderText = "الموظف";
            gv.Columns[nameof(_amount_client_View.name_fara)].HeaderText = "الفرع ";
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
            if (tx_name.Text == "")
            {
                MyMessageBox.showMessage("معلومات", "يجب اختيار عميل", "", MessageBoxButtons.RetryCancel);               
                return;
            }
            lb_Balance_sabk.ForeColor = Color.Black ;
            string st = "";
            string s = "";
            List<amount_client_View> List_amount_client_View = new List<amount_client_View>();

            var q = db.amount_client_Views.Where(x => x.id_client == id && x.DateAdd.Date < dt_date_from.Value.Date).ToList();
            var _amount_in = q.Sum(x => (decimal?)x.amount_in) ?? 0;
            var _amount_out = q.Sum(x => (decimal?)x.amount_out) ?? 0;
            var _Balance_sabk = _amount_in - _amount_out;
            if (_Balance_sabk!= 0)
            {
                List_amount_client_View.Add(new amount_client_View
                {
                    name_type = "رصيد سابق",
                    //amount_in = _amount_in,
                    //amount_out = _amount_out,
                    Balance = _Balance_sabk,
                });
                
            }



            var data = db.amount_client_Views.Where(x =>
            (x.id_client == id) &&
            (x.DateAdd.Date >= dt_date_from.Value.Date)).OrderBy
            (x => x.DateAdd).ToList();



            List_amount_client_View.AddRange(data);

            decimal sum = 0;
            foreach (var row in List_amount_client_View)
            {
                row.Balance = sum += row.Balance;
            }

            gv.DataSource = List_amount_client_View;
            gv.CurrentCell = null;
            
            if (_Balance_sabk != 0)
            {
                gv.Rows[0].DefaultCellStyle.BackColor = Color.Orange;
                if (_Balance_sabk < 0)
                {
                    st = "عليه";
                    lb_Balance_sabk.ForeColor = Color.Red;
                }
                if (_Balance_sabk > 0)
                {
                    st = "له";
                    lb_Balance_sabk.ForeColor = Color.Green;
                }
            }
            lb_Balance_sabk.Text = _Balance_sabk.ToString("0.00") + " " + st;

            int count_gv = List_amount_client_View.Count;
            var amount_in = List_amount_client_View.Sum(x => (decimal?)x.amount_in) ?? 0;
            var amount_out = List_amount_client_View.Sum(x => (decimal?)x.amount_out) ?? 0;
            var Balance = (_Balance_sabk+amount_in) - amount_out;

           
            if (Balance < 0)
            {
                s = "عليه";
                lp_total.ForeColor = Color.Red;
            }
            if (Balance > 0)
            {
                s = "له";
                lp_total.ForeColor = Color.Green;
            }
           

           


            lp_amunt_in.Text = amount_in.ToString("0.00");
            lp_amunt_out.Text = amount_out.ToString("0.00");
            lp_total.Text = Balance.ToString("0.00")+" "+s;
           
        }
        private void gv_kushf_with_marid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            int id = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[nameof(_amount_client_View.id)].Value.ToString());
            if(id == 0) return;
            int souceid = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[nameof(_amount_client_View.Source_Id)].Value.ToString());
            if (souceid == 0)
            {
                
                add_amount_client _add_amount_client = new add_amount_client(id);
                _add_amount_client.ShowDialog();
                bt_search.PerformClick();
            }
            else
            {
                frm_InvoiceHeader _frm_InvoiceHeader = new frm_InvoiceHeader(souceid);
                _frm_InvoiceHeader.ShowDialog();
                bt_search.PerformClick();
            }
            
        }
        
        private void btn_print_Click(object sender, EventArgs e)
        {
            if (gv.RowCount == 0)
                return;
            List<ReportParameter> para = new List<ReportParameter>();
            para.Add(new ReportParameter("p_date_from", dt_date_from.Value.ToString()));
            para.Add(new ReportParameter("p_dt_date_to", dt_date_from.Value.ToString()));
            para.Add(new ReportParameter("p_name_client", tx_name.Text));
            ReportDataSource[] ReportDataSource = new ReportDataSource[]
            {
             new ReportDataSource("all_amount_client", gv.DataSource),
            };
            frm_show_report _Report = new frm_show_report(para, "all_amount_client_report", ReportDataSource, true);
            _Report.Show();
        }

       
    }
}
