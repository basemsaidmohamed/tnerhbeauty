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
    public partial class selct_prodct : Form
    {
        DataClasses1DataContext db;
        int id = 0;
        public selct_prodct()
        {
            InitializeComponent();
            db = new DataClasses1DataContext();
            datagrid1.DataSource = db.product_serch_Views.OrderBy(x => x.name).Where(x => x.name.Contains(tx_serch.Text.Replace_text()) || x.code.Contains(tx_serch.Text)).OrderByDescending(x => x.name.StartsWith(tx_serch.Text.Replace_text())).GroupBy(x => new { x.id }).Select(pr => new product_serch_View{
                id = pr.First().id,
                
                name = pr.First().name,
                fullname = pr.First().fullname,
                price_sale = pr.First().price_sale,
                code = pr.First().code,
                Balance = pr.Sum(c => c.Balance),

            }).Take(20).ToList();


            datagrid1.Columns[nameof(product_serch_View.id)].Visible = false;
            datagrid1.Columns[nameof(product_serch_View.price_sale_100)].Visible = false;
            datagrid1.Columns[nameof(product_serch_View.price_sale_75)].Visible = false;
            datagrid1.Columns[nameof(product_serch_View.price_sale_vip1)].Visible = false;
            datagrid1.Columns[nameof(product_serch_View.price_sale_vip2)].Visible = false;
            datagrid1.Columns[nameof(product_serch_View.price_1)].Visible = false;
            datagrid1.Columns[nameof(product_serch_View.price_2)].Visible = false;
            datagrid1.Columns[nameof(product_serch_View.price_3)].Visible = false;
            datagrid1.Columns[nameof(product_serch_View.price_4)].Visible = false;
            datagrid1.Columns[nameof(product_serch_View.price_5)].Visible = false;
            datagrid1.Columns[nameof(product_serch_View.price_6)].Visible = false;
            datagrid1.Columns[nameof(product_serch_View.price_7)].Visible = false;
            datagrid1.Columns[nameof(product_serch_View.price_8)].Visible = false;
            datagrid1.Columns[nameof(product_serch_View.price_9)].Visible = false;
            datagrid1.Columns[nameof(product_serch_View.price_10)].Visible = false;
            datagrid1.Columns[nameof(product_serch_View.fullname)].Visible = false;
            datagrid1.Columns[nameof(product_serch_View.is_stop)].Visible = false;
            datagrid1.Columns[nameof(product_serch_View.store_id)].Visible = false;
            datagrid1.Columns[nameof(product_serch_View.store_name)].Visible = false;
            //datagrid1.Columns[nameof(product_serch_View.Balance)].Visible = false;
            datagrid1.Columns[nameof(product_serch_View.update_price)].Visible = false;
            datagrid1.Columns[nameof(product_serch_View.code)].HeaderText = "الكود";
            datagrid1.Columns[nameof(product_serch_View.name)].HeaderText = "اسم الصتف";
            datagrid1.Columns[nameof(product_serch_View.price_sale)].HeaderText = "سعر محل";

            //datagrid1.Columns[nameof(product_serch_View.code)].Visible = false;
            //datagrid1.Columns[nameof(product_serch_View.name)].Visible = false;
        }
        public int retrnval()
        {
            return id;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (datagrid1.CurrentCell != null)
                id = Convert.ToInt32(datagrid1.Rows[datagrid1.CurrentCell.RowIndex].Cells["id"].Value.ToString());
            else id = 0;
            retrnval();
            this.Close();
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

            db = new DataClasses1DataContext();
            datagrid1.DataSource = db.product_serch_Views.OrderBy(x => x.name).Where(x => x.name.Contains(tx_serch.Text.Replace_text()) || x.code.Contains(tx_serch.Text)).OrderByDescending(x => x.name.StartsWith(tx_serch.Text.Replace_text())).GroupBy(x => new { x.id }).Select(pr => new product_serch_View
            {
                id = pr.First().id,

                name = pr.First().name,
                fullname = pr.First().fullname,
                price_sale = pr.First().price_sale,
                code = pr.First().code,
                Balance = pr.First().Balance,

            }).ToList();
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
