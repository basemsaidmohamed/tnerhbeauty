using ClosedXML.Excel;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using tnerhbeauty.Class;
using tnerhbeauty.rport;


namespace tnerhbeauty
{
   
    public partial class frm_InvoiceHeader_in : Form
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        const int WM_PARENTNOTIFY = 0x210;
        const int WM_LBUTTONDOWN = 0x201;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDOWN || (m.Msg == WM_PARENTNOTIFY &&
                (int)m.WParam == WM_LBUTTONDOWN))
                if (!tx_ItemName.ClientRectangle.Contains(tx_ItemName.PointToClient(Cursor.Position)) && !gvSerchProduct.ClientRectangle.Contains(gvSerchProduct.PointToClient(Cursor.Position)))
                {
                    gvSerchProduct.Hide();
                    if (Producselct == null || Producselct.fullname != tx_ItemName.Text)
                    {
                        tx_ItemName.Text = "";                        
                        Producselct = null;
                    }
                }
            base.WndProc(ref m);
        }
        product_serch_View Producselct;
        DataClasses1DataContext db;
        DataClasses1DataContext DBDetails;
        InvoiceHeader invoiceHeader;
        bool updateid = false;
        InvoiceDetail invoiceDetail;
        BindingSource bs;
        static List<product_serch_View> dataprodcut;
        static List<store> stores;
        decimal kilo=1;        
       
        public frm_InvoiceHeader_in()
        {
            InitializeComponent();
            
            Initialize_class();
            GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(this, true, null);
            
        }
        public frm_InvoiceHeader_in(int id)
        {
            InitializeComponent();
            
            Initialize_class();
            invoiceHeader = db.InvoiceHeaders.Where(s => s.id == id).FirstOrDefault();
            if(invoiceHeader==null)
                invoiceHeader=new InvoiceHeader();
        }
        void Initialize_class()
        {
            db = new DataClasses1DataContext();
            DBDetails = new DataClasses1DataContext();
            invoiceHeader = new InvoiceHeader();
            bs = new BindingSource();
        }
        public void get_dataprodct()
        {
            dataprodcut = Session.getallprodct.ToList();
            if (dataprodcut.Count == 0)
            {
                MyMessageBox.showMessage("لا يوجد اصناف مسجلة", "يجب اضافة اصناف اولا", "", MessageBoxButtons.RetryCancel);

            }
            Column1.DataSource = dataprodcut;
        }
        private void frm_kushufat_Load(object sender, EventArgs e)
        {
           
            gvSerchProduct.DataSource = new List<product_serch_View>();
            gvSerchProduct.Columns[nameof(product_serch_View.name)].Width = 200;
            gvSerchProduct.Columns[nameof(product_serch_View.id)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_sale)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_sale_100)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_sale_75)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_sale_vip2)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_sale_vip1)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_1)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_2)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_3)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_4)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_5)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_6)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_7)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_8)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_9)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.price_10)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.is_stop)].Visible = false;
            //gvSerchProduct.Columns[nameof(product_serch_View.Balance)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.update_price)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.fullname)].Visible = false;
            gvSerchProduct.Columns[nameof(product_serch_View.min_mum)].Visible = false;
            gvSerchProduct.AutoSize = true;

            ch_kilo.Checked = Properties.Settings.Default.ch_kilo;
            ch_auto_insert.Checked = Properties.Settings.Default.ch_auto_insert;
            ch_not_celar_ItemQty.Checked = Properties.Settings.Default.ch_not_celar_ItemQty;           
            get_dataprodct();
            get_store();
            getdata();
            Initialize_gv_InvoiceDetails();
        }
        void get_store()
        {
            stores = db.stores.ToList();
            dr_store_from.IntializeData(stores.Where(x => x.is_stop == false && x.id_fara == Session.User_login.id_fara).ToList(), "store_name", "id");            
        }
        void Initialize_gv_InvoiceDetails()
        {
            
            Column1.DataPropertyName = "ItemID";
            Column1.DisplayMember = "fullname";
            Column1.ValueMember = "id";

            Column2.DataSource = stores.ToList();
            Column2.DataPropertyName = "store_id";
            Column2.DisplayMember = "store_name";
            Column2.ValueMember = "id";

            gv_InvoiceDetails.AutoGenerateColumns = false;
            gv_InvoiceDetails.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            gv_InvoiceDetails.Columns[nameof(invoiceDetail.id)].Visible = false;
            gv_InvoiceDetails.Columns[nameof(invoiceDetail.store_id)].Visible = false;
            gv_InvoiceDetails.Columns[nameof(invoiceDetail.InvoiceHeaderID)].Visible = false;
            gv_InvoiceDetails.Columns[nameof(invoiceDetail.ItemID)].Visible = false;
            gv_InvoiceDetails.Columns[nameof(invoiceDetail.ItemQty)].HeaderText = "الكمية";
            gv_InvoiceDetails.Columns[nameof(invoiceDetail.Price)].Visible = false;
            gv_InvoiceDetails.Columns[nameof(invoiceDetail.TotalPrice)].Visible = false;
            gv_InvoiceDetails.Columns[nameof(invoiceDetail.Discount)].Visible = false;
            gv_InvoiceDetails.Columns[nameof(invoiceDetail.Total)].Visible = false;
            gv_InvoiceDetails.Columns[Column2.Name].HeaderText = "المخزن";
            gv_InvoiceDetails.Columns[Column2.Name].DisplayIndex = gv_InvoiceDetails.Columns.Count - 2;
            gv_InvoiceDetails.Columns["deleteitem"].DisplayIndex = gv_InvoiceDetails.Columns.Count - 1;
            gv_InvoiceDetails.Columns["deleteitem"].Width = 38;
            gv_InvoiceDetails.CurrentCell = null;
        }
        
        void getdata()
        {
            bs.DataSource = DBDetails.InvoiceDetails.Where(x => x.InvoiceHeaderID == invoiceHeader.id);
            gv_InvoiceDetails.DataSource = bs;            
            tx_Notes.Text = invoiceHeader.Notes;            
            if (invoiceHeader.id != 0)
            {
                lp_titel.Text = "تعديل بيان مشتريات";
                tx_DateAdd.Value = invoiceHeader.DateAdd;
                btn_print.Visible = true;
                updateid = true;
                btn_delete.Visible = Session.User_setting().delete_invoice_sale;
                btn_save.Visible = Session.User_setting().update_invoice_sale;

               
            }
            else
            {
                lp_titel.Text = "بيان مشتريات جديد";               
                btn_save.Visible = Session.User_setting().add_invoice_sale;
                btn_new.Visible = Session.User_setting().add_invoice_sale;

               
            }
            tx_ItemName.Focus();
        }
        void setdata()
        {
            invoiceHeader.id_cient = null;
            invoiceHeader.Discount_type = 0;
            invoiceHeader.Discount_percent = 0;
            invoiceHeader.Discount = 0;
            invoiceHeader.Extra_type = 0;
            invoiceHeader.Extra_percent = 0;
            invoiceHeader.Extra = 0;
            invoiceHeader.Total_product=0;
            invoiceHeader.Net = 0;
            invoiceHeader.Notes = tx_Notes.Text.Replace_text();
            invoiceHeader.DateAdd = tx_DateAdd.Value;
            invoiceHeader.is_agel=true;
            invoiceHeader.id_invoice_type = 2;
            invoiceHeader.id_user = Session.User_login.id;
            invoiceHeader.id_fara = Session.User_login.id_fara;
            invoiceHeader.DateServer = Session.GetDate();
        }
        DataClasses1DataContext db_store_Log;
        bool valid()
        {
            errorProvider1.Clear();
            int error = 0;
            if (dr_store_from.SelectedIndex == -1)
            {
                errorProvider1.SetError(dr_store_from, "يجب اختيار مخزن");
                error++;
            }
            return error == 0;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (gv_InvoiceDetails.Rows.Count <= 0)
            {
                lb_mas.Text = "يجب اضافة صنف ";
                return;
            }

            if (!valid())
                return;
            

            setdata();

            List<store_log> list_store_Log = new List<store_log>();
            db_store_Log = new DataClasses1DataContext();

            if (invoiceHeader.id == 0)
            {
                db.InvoiceHeaders.InsertOnSubmit(invoiceHeader);
            }
            else
            {
                db_store_Log.store_logs.DeleteAllOnSubmit(db_store_Log.store_logs.Where(x => x.Source_Id == invoiceHeader.id).ToList());
                db_store_Log.SubmitChanges();
            }

            db.SubmitChanges();

            for (int i = 0; i < gv_InvoiceDetails.Rows.Count; i++)
                gv_InvoiceDetails.Rows[i].Cells[nameof(invoiceDetail.InvoiceHeaderID)].Value = invoiceHeader.id;

            DBDetails.SubmitChanges();
            
           
            foreach (DataGridViewRow item in gv_InvoiceDetails.Rows)
            {
                list_store_Log.Add(new store_log
                {
                    ItemID = Session.ConvertInt(item.Cells[nameof(invoiceDetail.ItemID)].Value.ToString()),
                    ItemQty_in = Session.Convertdecimal(item.Cells[nameof(invoiceDetail.ItemQty)].Value.ToString()),
                    nots = "مشتريات",
                    DateAdd = invoiceHeader.DateAdd,
                    Source_Id = invoiceHeader.id,
                    id_type = invoiceHeader.id_invoice_type,
                    store_id = Session.ConvertInt(item.Cells[nameof(invoiceDetail.store_id)].Value.ToString()),
                    id_fara = invoiceHeader.id_fara,
                    id_user = invoiceHeader.id_user,
                    
                }) ; 
            }

            db_store_Log.store_logs.InsertAllOnSubmit(list_store_Log);
            db_store_Log.SubmitChanges();

            if (updateid)
            {
                this.Close();
                return;
            }
            btn_new.PerformClick();
            lb_mas.Text = "تم حفظ البيانات بنجاح";
        }
        private void btn_new_Click(object sender, EventArgs e)
        {
            Initialize_class();
            getdata();
            updateid = false;
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {

            string StError = "";
            int CountError = 0;
            List<InvoiceDetail> list = new List<InvoiceDetail>();
            list = DBDetails.InvoiceDetails.Where(x => x.InvoiceHeaderID == invoiceHeader.id).ToList()
             .GroupBy(x => new { x.ItemID, x.store_id }).Select(cl => new InvoiceDetail
             {
                 ItemID = cl.First().ItemID,
                 ItemQty = (decimal?)cl.Sum(x => x.ItemQty) ?? 0,
                 store_id = cl.First().store_id,
             }).ToList();
            foreach (InvoiceDetail item in list.ToList())
            {
                var _prod = db.product_serch_Views.Where(x => (x.id == item.ItemID) && (x.store_id == item.store_id)).FirstOrDefault();
                if (_prod != null)
                {
                    if (item.ItemQty > _prod.Balance)
                    {
                        CountError++;
                        StError += _prod.name + " " + _prod.store_name + " " + "اكبر كمية بيع" + " " + _prod.Balance + "\n";
                    }
                }
            }
            if (CountError > 0)
            {
                MyMessageBox.showMessage("تاكيد", StError, "", MessageBoxButtons.RetryCancel);
                return;
            }


            if (MyMessageBox.showMessage("هل انت متاكد", "هل تريد حذف هذا البيان  .... ؟ ", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            db.InvoiceHeaders.DeleteOnSubmit(invoiceHeader);
            db.SubmitChanges();

            db_store_Log = new DataClasses1DataContext();
            db_store_Log.store_logs.DeleteAllOnSubmit(db_store_Log.store_logs.Where(x => x.Source_Id == invoiceHeader.id).ToList());
            db_store_Log.SubmitChanges();

            this.Close();
        }
        private void btn_print_Click(object sender, EventArgs e)
        {
            List<ReportParameter> para = new List<ReportParameter>();
            para.Add(new ReportParameter("P_titel", "بيان مشتريات"));
            DataClasses1DataContext data = new DataClasses1DataContext();
            ReportDataSource[] ReportDataSource = new ReportDataSource[]
            {
             new ReportDataSource("invoice", data.InvoiceHeaderView_ins.Where(x => x.id == invoiceHeader.id).ToList()),
             new ReportDataSource("InvoiceDetails", data.InvoiceDetails_rep_Views.Where(x => x.InvoiceHeaderID == invoiceHeader.id).ToList()),
            };
            frm_show_report _Report = new frm_show_report(para, "invoice", ReportDataSource, true);
            _Report.Show();
        }
        private void frm_kushufat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                btn_save.PerformClick();
            }
            if (e.KeyCode == Keys.F11)
            {
                btn_add_grid.PerformClick();
            }
            if (e.KeyCode == Keys.F2)
            {
                btn_new.PerformClick();
            }
            if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {
                btn_print.PerformClick();
            }
            if (e.KeyCode == Keys.Escape && updateid)
            {
                this.Close();
            }
        }
        private void tx_ItemName_TextChanged(object sender, EventArgs e)
        {
            if (tx_ItemName.Text != "")
            {
                var data = from pr in db.product_serch_Views.OrderBy(x => x.name).Where(x => (x.name.Contains(tx_ItemName.Text.Replace_text()) || (x.code.Contains(tx_ItemName.Text))) && x.is_stop == false).OrderByDescending(x => x.name.StartsWith(tx_ItemName.Text.Replace_text())).Take(20).ToList().GroupBy(x => x.id)
                           select new product_serch_View
                           {
                               id = pr.First().id,
                               name = pr.First().name,
                               fullname = pr.First().fullname,
                               price_sale = pr.First().price_sale,
                               code = pr.First().code,
                               Balance = pr.Sum(c => c.Balance),
                           };
                gvSerchProduct.DataSource = data.ToList();

                gvSerchProduct.Columns[nameof(product_serch_View.name)].Width = 200;               
                gvSerchProduct.AutoSize = true;

                //gvSerchProduct.DataSource = db.product_serch_Views.OrderBy(x => x.name).Where(x => x.name.Contains(tx_ItemName.Text.Replace_text())|| (x.code.Contains(tx_ItemName.Text))).OrderByDescending(x => x.name.StartsWith(tx_ItemName.Text.Replace_text())).ToList();
                if (gvSerchProduct.Rows.Count == 0)
                    gvSerchProduct.Visible = false;
                else
                    gvSerchProduct.Visible = true;
            }
            else gvSerchProduct.Visible = false;
        }
        void Celar_add_proudct()
        {
            if (ch_not_celar_ItemQty.Checked == false)
                tx_ItemQty.Text = "";
            tx_ItemName.Text = "";
            lb_balance.Text = "";
            gv_InvoiceDetails.CurrentCell = null;
            Producselct = null;
            tx_ItemName.Focus();
        }
    private void ClickGridEnter()
        {
           
            if (gvSerchProduct.CurrentCell != null)
            {
                int index = gvSerchProduct.CurrentCell.RowIndex;
                Producselct = new product_serch_View();
                Producselct = (product_serch_View)gvSerchProduct.Rows[index].DataBoundItem;
                tx_ItemName.Text = Producselct.fullname;
                gvSerchProduct.Visible = false;
                lb_balance.Text = Producselct.Balance.ToString();
                tx_ItemQty.Focus();
                tx_ItemQty.SelectAll();
                if (ch_auto_insert.Checked)
                {
                    btn_add_grid.PerformClick();
                }
            }
        }
        private void gvSerchProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ClickGridEnter();
        }
        private void tx_ItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                SendKeys.Send("{END}");
            if (e.KeyCode == Keys.Escape)
            {
                tx_ItemName.Text = "";
            }
            if (tx_ItemName.Text == "")
                return;
            if (gvSerchProduct.Rows.Count == 0)
                return;

            if (gvSerchProduct.CurrentCell == null)
                gvSerchProduct.CurrentCell = gvSerchProduct[1, 0]; ;

            if (e.KeyCode == Keys.Down)
            {
                int index = gvSerchProduct.CurrentCell.RowIndex;
                if (index != gvSerchProduct.Rows.Count - 1)
                {
                    if (gvSerchProduct.CurrentCell == null)
                        gvSerchProduct.CurrentCell = gvSerchProduct.Rows[0].Cells[nameof(product_serch_View.name)];
                    gvSerchProduct.CurrentCell = gvSerchProduct.Rows[index + 1].Cells[nameof(product_serch_View.name)];
                }
                SendKeys.Send("{END}");
            }
            else if (e.KeyCode == Keys.Up)
            {
                int index = gvSerchProduct.CurrentCell.RowIndex;
                if (index != 0)
                {
                    if (gvSerchProduct.CurrentCell == null)
                        gvSerchProduct.CurrentCell = gvSerchProduct.Rows[0].Cells[nameof(product_serch_View.name)];
                    gvSerchProduct.CurrentCell = gvSerchProduct.Rows[index - 1].Cells[nameof(product_serch_View.name)];
                }
                SendKeys.Send("{END}");
            }
            else if (e.KeyCode == Keys.Enter && gvSerchProduct.CurrentCell != null)
            {
                ClickGridEnter();
            }
        }
        private void gvSerchProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gvSerchProduct.CurrentCell != null)
            {
                ClickGridEnter();
            }
        }
        private bool ValidAddGrid()
        {
            int err = 0;
            //if (tx_ItemQty.Text == "" || tx_ItemQty.Text == "0")
            //    tx_ItemQty.Text = "1";
            errorProvider1.Clear();
            if (dr_store_from.SelectedIndex == -1)
            {
                errorProvider1.SetError(dr_store_from, "يجب اختيار مخزن");
                err += 1;
            }
            if (Session.Convertdecimal(tx_ItemQty.Text) == 0)
            {
                errorProvider1.SetError(tx_ItemQty, "يجب ادخال كمية صحيحة");
                tx_ItemQty.Text = "";
                err += 1;
            }
            if (Producselct == null || Producselct.id == 0)
            {
                errorProvider1.SetError(tx_ItemName, "يجب اختيار صنف ");
                err +=1;
            }
            
          
            return (err == 0);
        }
        private void btn_add_grid_Click(object sender, EventArgs e)
        {
            if (ValidAddGrid() == false)
                return;
            
            bs.Insert(0, new InvoiceDetail
            {
                InvoiceHeaderID = invoiceHeader.id,
                ItemID = Producselct.id,
                ItemQty = (kilo == 1000) ? Convert.ToDecimal((Session.Convertdecimal(tx_ItemQty.Text) / kilo).ToString("0.000")) : Session.Convertdecimal(tx_ItemQty.Text),
                store_id = Session.ConvertInt(dr_store_from.SelectedValue.ToString()),
                
            });
            Celar_add_proudct();
           
        }
        private void Gv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridViewColumn = gv_InvoiceDetails.Columns["deleteitem"];
            if (e.ColumnIndex == gv_InvoiceDetails.Columns.IndexOf(dataGridViewColumn) && e.RowIndex != -1)
            {

                if(chek_befor_delete_row(e.RowIndex))
                if (MyMessageBox.showMessage("تاكيد", "هل متاكد من حذف السجل المحدد", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bs.RemoveAt(e.RowIndex);
                }
                else
                {
                    gv_InvoiceDetails.CurrentCell = null;
                    tx_ItemName.Focus();
                }
            }
        }
        private bool chek_befor_delete_row(int row)
        {
            bool error = true;
            if (invoiceHeader.id != 0)
            {
                var ItemID = Session.ConvertInt(gv_InvoiceDetails.Rows[row].Cells[nameof(invoiceDetail.ItemID)].Value.ToString());
                var store_id = Session.ConvertInt(gv_InvoiceDetails.Rows[row].Cells[nameof(invoiceDetail.store_id)].Value.ToString());
                var ItemQty = Session.Convertdecimal(gv_InvoiceDetails.Rows[row].Cells[nameof(invoiceDetail.ItemQty)].Value.ToString());
                var Balance = db.product_serch_Views.Where(x => (x.id == ItemID) && (x.store_id == store_id)).FirstOrDefault().Balance;
                if (ItemQty > Balance)
                {
                    MyMessageBox.showMessage("خطاء", "لايمكن حذف الكمية المحدده", "", MessageBoxButtons.RetryCancel);
                    error = false;
                }
            }
            return error;
        }
        private void tx_ItemQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void tx_ItemQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Session.ConvertDouble(tx_ItemQty.Text) > 0)
                {
                    btn_add_grid.PerformClick();
                }
            }
        }
        private void tx_Discount_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (Regex.IsMatch((sender as TextBox).Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;                
            }
            // only allow one decimal point
            if (((e.KeyChar == '.') || char.IsDigit(e.KeyChar)) && (sender as TextBox).SelectionLength == (sender as TextBox).Text.Length)
            {
                e.Handled = false;
            }
            else
            if ((e.KeyChar == '.') && (sender as TextBox).Text.IndexOf('.') > -1 )
            {
                e.Handled = true;
            }
        }
        private void gv_InvoiceDetails_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (chek_befor_delete_row(e.Row.Index))
            {
                if (MyMessageBox.showMessage("تاكيد", "هل متاكد من حذف السجل المحدد", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    e.Cancel = false;
                    gv_InvoiceDetails.CurrentCell = null;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else e.Cancel = true;
        }
        private void ch_auto_insert_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_auto_insert.Checked)
            {
                ch_auto_insert.ForeColor = Color.Green;
            }
            else ch_auto_insert.ForeColor = Color.DimGray;
            Properties.Settings.Default.ch_auto_insert = ch_auto_insert.Checked;
            Properties.Settings.Default.Save();
            ck_txqty();
        }
        private void ch_kilo_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_kilo.Checked)
            {
                kilo = 1000;
                ch_kilo.ForeColor = Color.Green;
            }
            else 
            {
                kilo = 1; 
                ch_kilo.ForeColor = Color.DimGray;
            }
            Properties.Settings.Default.ch_kilo = ch_kilo.Checked;
            Properties.Settings.Default.Save();
            ck_txqty();
        }
        private void ch_not_celar_ItemQty_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_not_celar_ItemQty.Checked)
            {
                ch_not_celar_ItemQty.ForeColor = Color.Green;
            }
            else ch_not_celar_ItemQty.ForeColor = Color.DimGray;
            Properties.Settings.Default.ch_not_celar_ItemQty = ch_not_celar_ItemQty.Checked;
            Properties.Settings.Default.Save();
            ck_txqty();
        }
        private void ck_txqty()
        {
            if (tx_ItemName.Text == "")
                tx_ItemName.Focus();
            else
            {
                tx_ItemQty.Focus();
                tx_ItemQty.SelectAll();
            }
            
        }
    }
}
