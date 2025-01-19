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
    public partial class all_user : Form
    {
        DataClasses1DataContext db;
        public all_user()
        {
            InitializeComponent();
        }       
        public void getdata()
        {
            db = new DataClasses1DataContext();
            var data = db.user_Views.OrderBy(x => x.user_name).Where(
              x => (x.user_name.Contains(tx_serch.Text.Replace_text())
              || x.tel.Contains(tx_serch.Text)
              || Convert.ToString(x.id) == tx_serch.Text
              ) ).OrderByDescending(x => x.user_name.StartsWith(tx_serch.Text.Replace_text())).ToList();
            gv.DataSource = data;
            gv.CurrentCell = null;
        }
        private void gv_mariddata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            int id = Convert.ToInt32(gv.Rows[e.RowIndex].Cells[nameof( user_View.id)].Value.ToString());
            add_user add_new = new add_user(id);
            add_new.ShowDialog();
            getdata();
        }
        private void all_marid_Load(object sender, EventArgs e)
        {
            
            db = new DataClasses1DataContext();
            user_View _user;
            gv.DataSource=new List<user_View>();
            gv.Columns[nameof(_user.is_stop)].SortMode = DataGridViewColumnSortMode.Automatic;
            gv.Columns[nameof(_user.id)].Visible = false;
            gv.Columns[nameof(_user.id_fara)].Visible = false;
            gv.Columns[nameof(_user.password)].Visible = false;
            gv.Columns[nameof(_user.id_setting)].Visible = false;
            gv.Columns[nameof(_user.user_name)].HeaderText = "اسم الموظف";
            gv.Columns[nameof(_user.tel)].HeaderText = "التليفون";
            gv.Columns[nameof(_user.adress)].HeaderText = "العنوان ";
            gv.Columns[nameof(_user.is_stop)].HeaderText = "موقوف ";
            gv.Columns[nameof(_user.name_fara)].HeaderText = "الفرع";
            gv.Columns[nameof(_user.name_setting)].HeaderText = "نموذج الصلاحيات";
            getdata();
        }
        private void bt_search_Click(object sender, EventArgs e)
        {
            getdata();
        }
    }
}
