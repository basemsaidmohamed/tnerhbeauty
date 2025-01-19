using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tnerhbeauty.Class;

namespace tnerhbeauty
{
    public partial class selct_sick : Form
    {
        DataClasses1DataContext db;
        int id = 0;
        public selct_sick()
        {
            InitializeComponent();
            db = new DataClasses1DataContext();
            datagrid1.DataSource = db.client_Views.OrderByDescending(x => x.id).Where(x => x.is_stop == false).ToList().Select(x=> new { x.id, x.name,x.tel,x.name_row}).ToList();
            datagrid1.Columns[nameof(client_View.id)].Visible = false;
            //datagrid1.Columns[nameof(client_View.adress)].Visible = false;
            //datagrid1.Columns[nameof(client_View.is_stop)].Visible = false;
            //datagrid1.Columns[nameof(client_View.DateServer)].Visible = false;
            //datagrid1.Columns[nameof(client_View.nots)].Visible = false;
            //datagrid1.Columns[nameof(client_View.list_price)].Visible = false;
            //datagrid1.Columns[nameof(client_View.Balance)].Visible = false;
            //datagrid1.Columns[nameof(client_View.Balance_type)].Visible = false;

            datagrid1.Columns[nameof(client_View.name)].HeaderText = "اسم العميل";
            datagrid1.Columns[nameof(client_View.tel)].HeaderText = "تليفون";
            datagrid1.Columns[nameof(client_View.name_row)].HeaderText = "قائمة الاسعار";
        }
        public int retrnval()
        {
           
            return id;
        }
        private void datagrid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
             id = Convert.ToInt32(datagrid1.Rows[e.RowIndex].Cells["id"].Value.ToString());
            retrnval();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            datagrid1.DataSource = db.client_Views.OrderBy(x => x.name).Where( x => x.name.Contains(tx_serch.Text.Replace_text()) || x.tel.Contains(tx_serch.Text) && x.is_stop == false).OrderByDescending(x => x.name.StartsWith(tx_serch.Text.Replace_text())).ToList();
            datagrid1.CurrentCell = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {           
            this.Close();
        }

        private void selct_sick_Load(object sender, EventArgs e)
        {
            tx_serch.Focus();
        }
    }
}
