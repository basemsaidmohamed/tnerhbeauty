using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using tnerhbeauty.Class;
using tnerhbeauty.rport;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace tnerhbeauty
{
    public partial class all_client : Form
    {
        DataClasses1DataContext db;
        public all_client()
        {
            InitializeComponent();
           
        }       
        public void getdata()
        {
            db = new DataClasses1DataContext();
            var data = db.client_Views.OrderBy(x => x.name).Where(
              x => (x.name.Contains(tx_serch.Text.Replace_text())
              || x.tel.Contains(tx_serch.Text)
              || Convert.ToString(x.id) == tx_serch.Text
              )
              && x.Balance_type.Contains(dr_Balance_type.SelectedValue.ToString())
               && (!ch_zero.Checked|| x.Balance!=0)
              ).OrderByDescending(x => x.name.StartsWith(tx_serch.Text.Replace_text()));
            gv.DataSource = data.ToList();
            gv.CurrentCell = null;
            var amunt_out = data.Where(x => (decimal?)x.Balance < 0).Sum(x => (decimal?)x.Balance );
            var amunt_in = data.Where(x => (decimal?)x.Balance > 0).Sum(x => (decimal?)x.Balance );

            lp_amunt_out.Text = amunt_out.ToString();
            lp_amunt_in.Text = amunt_in.ToString();
            lp_total.Text = (amunt_in+amunt_out).ToString();

            //lb_mas.Text = 
        }
        private void gv_mariddata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            int id = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[nameof( client_View.id)].Value.ToString());
            add_client kushufat = new add_client(id);
            kushufat.ShowDialog();
            getdata();
        }
        private void all_marid_Load(object sender, EventArgs e)
        {
           
            db = new DataClasses1DataContext();
            gv.DataSource=new List<client_View>();
            gv.Columns[nameof(client_View.is_stop)].SortMode = DataGridViewColumnSortMode.Automatic;
            gv.Columns[nameof(client_View.id)].Visible = false;
            gv.Columns[nameof(client_View.list_price)].Visible = false;
            gv.Columns[nameof(client_View.id_fara)].Visible = false;
            gv.Columns[nameof(client_View.id_user)].Visible = false;
            gv.Columns[nameof(client_View.name)].HeaderText = "  اسم العميل";
            gv.Columns[nameof(client_View.tel)].HeaderText = "التليفون";
            gv.Columns[nameof(client_View.adress)].HeaderText = "العنوان ";
            gv.Columns[nameof(client_View.DateServer)].HeaderText = "تاريخ الاضافة";
            gv.Columns[nameof(client_View.nots)].HeaderText = "ملاحظات ";
            gv.Columns[nameof(client_View.is_stop)].HeaderText = "موقوف ";
            gv.Columns[nameof(client_View.name_row)].HeaderText = "الاسعار";
            gv.Columns[nameof(client_View.Balance)].HeaderText = "الرصيد";
            gv.Columns[nameof(client_View.Balance_type)].HeaderText = "العميل";
            gv.Columns[nameof(client_View.name_fara)].HeaderText = "فرع";
            gv.Columns[nameof(client_View.user_name)].HeaderText = "الموظف";
            var items = new[] {
                new { Text = "جميع الارصدة", Value = "" },
                new { Text = "عليه مبلغ", Value = "علية" },
                new { Text = "له مبلغ", Value = "له" },
                };
            dr_Balance_type.DataSource = items;
            dr_Balance_type.DisplayMember = "Text";
            dr_Balance_type.ValueMember = "Value";
            getdata();
        }
        private void bt_search_Click(object sender, EventArgs e)
        {
            getdata();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            if (gv.RowCount == 0)
                return;
            ReportDataSource[] ReportDataSource = new ReportDataSource[]
            {
             new ReportDataSource("all_client", gv.DataSource),
            };
            frm_show_report _Report = new frm_show_report(null, "all_client", ReportDataSource, true);
            _Report.Show();
        }
    }
}
