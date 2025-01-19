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
    public partial class all_store : Form
    {
        DataClasses1DataContext db;
        public all_store()
        {
            InitializeComponent();
           
        }       
        public void getdata()
        {
            db = new DataClasses1DataContext();
            var data = db.store_Views.OrderBy(x => x.store_name).Where(
              x => (x.store_name.Contains(tx_serch.Text.Replace_text())
              || x.tel.Contains(tx_serch.Text)
              || Convert.ToString(x.id) == tx_serch.Text
              ) ).OrderByDescending(x => x.store_name.StartsWith(tx_serch.Text.Replace_text())).ToList();
            gv.DataSource = data;
            gv.CurrentCell = null;
        }
        private void gv_mariddata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            int id = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[nameof( store.id)].Value.ToString());
            add_store kushufat = new add_store(id);
            kushufat.ShowDialog();
            getdata();
        }
        private void all_marid_Load(object sender, EventArgs e)
        {
            
            db = new DataClasses1DataContext();
            store_View store;
            gv.DataSource=new List<store_View>();
            gv.Columns[nameof(store.is_stop)].SortMode = DataGridViewColumnSortMode.Automatic;
            gv.Columns[nameof(store.id)].Visible = false;
            gv.Columns[nameof(store.id_fara)].Visible = false;
            gv.Columns[nameof(store.id_user)].Visible = false;
            gv.Columns[nameof(store.store_name)].HeaderText = "  اسم المخزن";
            gv.Columns[nameof(store.tel)].HeaderText = "التليفون";
            gv.Columns[nameof(store.adress)].HeaderText = "العنوان ";
            gv.Columns[nameof(store.is_stop)].HeaderText = "موقوف ";
            gv.Columns[nameof(store.user_name)].HeaderText = "اسم الموظف";
            gv.Columns[nameof(store.name_fara)].HeaderText = "اسم الفرع";
            getdata();
        }
        private void bt_search_Click(object sender, EventArgs e)
        {
            getdata();
        }
    }
}
