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
    public partial class all_setting : Form
    {
        DataClasses1DataContext db;
        setting _setting;
        public all_setting()
        {
            InitializeComponent();
        }
        public void getdata()
        {
            db = new DataClasses1DataContext();
            var data = db.settings.OrderBy(x => x.name).Where(
              x => (x.name.Contains(tx_serch.Text.Replace_text())
              )).OrderByDescending(x => x.name.StartsWith(tx_serch.Text.Replace_text())).ToList();
            
            gv.DataSource = data.Select(x => new { x.id, x.name,x.id_user,x.DateServer }).ToList();
            gv.CurrentCell = null;
        }
        private void gv_mariddata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            int id = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[nameof(_setting.id)].Value.ToString());
            add_setting add_new = new add_setting(id);
            add_new.ShowDialog();
            getdata();
        }
        private void all_marid_Load(object sender, EventArgs e)
        {
           
            db = new DataClasses1DataContext();
            gv.DataSource=new List<setting>();

            gv.Columns[nameof(_setting.id)].Visible = false;
            gv.Columns[nameof(_setting.id_user)].HeaderText = "رقم الموظف";
            gv.Columns[nameof(_setting.name)].HeaderText = "اسم نموذج الصلاحيات";
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
