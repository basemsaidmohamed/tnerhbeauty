using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
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
    public partial class all_fara : Form
    {
        DataClasses1DataContext db;
        public all_fara()
        {
            InitializeComponent();
           
        }       
        public void getdata()
        {
            db = new DataClasses1DataContext();
            var data = db.faras.OrderBy(x => x.name_fara).Where(
              x => (x.name_fara.Contains(tx_serch.Text.Replace_text())
              || x.tel.Contains(tx_serch.Text)
              || Convert.ToString(x.id) == tx_serch.Text
              ) ).OrderByDescending(x => x.name_fara.StartsWith(tx_serch.Text.Replace_text()));
            gv.DataSource = data;
            gv.CurrentCell = null;
        }
        private void gv_mariddata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            int id = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[nameof(fara.id)].Value.ToString());
            add_fara kushufat = new add_fara(id);
            kushufat.ShowDialog();
            getdata();
        }
        private void all_marid_Load(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();
            fara _fara;
            gv.DataSource=new List<fara>();
            gv.Columns[nameof(_fara.is_stop)].SortMode = DataGridViewColumnSortMode.Automatic;
            gv.Columns[nameof(_fara.id)].Visible = false;
            gv.Columns[nameof(_fara.tel)].HeaderText = "التليفون";
            gv.Columns[nameof(_fara.adress)].HeaderText = "العنوان ";
            gv.Columns[nameof(_fara.is_stop)].HeaderText = "موقوف ";
            gv.Columns[nameof(_fara.name_fara)].HeaderText = "اسم الفرع";
            gv.Columns[nameof(_fara.id_user)].HeaderText = "رقم الموظف";
            getdata();
        }
        private void bt_search_Click(object sender, EventArgs e)
        {
            getdata();
        }
    }
}
